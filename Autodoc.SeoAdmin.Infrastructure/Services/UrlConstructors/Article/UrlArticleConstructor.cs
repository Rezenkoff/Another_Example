using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using Autodoc.SeoAdmin.Domain.Enum;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlArticleConstructor : UrlArticleTransletiratorConstructorBase
    {
        private PageTypes _constructedPageType = PageTypes.Article;
        protected string firstUrlSegment = "product";


        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModelArticle request)
        {
            return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        LinkingStatus = LinkingStatus.Active,
                        GenerationStatus = GenerationStatus.Generated,
                        HashCode= $"{delimeter}{request.ArticleId}-{(int)_constructedPageType}-{request.NodeId}",
                        TransliteratedUrl =
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.ArticleName.ToLower())}-{delimeter}{request.ArticleId}-{(int)_constructedPageType}-{request.NodeId}"
                    }
            };
        }
    }
}

