using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlCategoryConstructor : UrlCategoryTransletiratorConstructorBase
    {
        //category/vozdushnyj-filtr-id349-3
        
        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (!request.ArticleId.HasValue && !request.SupplierId.HasValue && !request.MarkId.HasValue && !request.SerieId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}",
                        KindTypeUrl = request.KindTypeUrlId,                         
                        TransliteratedUrl = $"{firstUrlSegment}/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}"
                    }
                };
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
