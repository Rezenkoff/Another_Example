using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Domain.Entities;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class ArticleConstructorsSequenceBuilder : IConstructorsSequenceBuilder<RawSeoModelArticle>
    {
        public IUrlTransletiratorConstructor<RawSeoModelArticle> BuildChain ()
        {
            var articleUrlConstructor = new UrlArticleConstructor();

            return articleUrlConstructor;
        }
    }
}
