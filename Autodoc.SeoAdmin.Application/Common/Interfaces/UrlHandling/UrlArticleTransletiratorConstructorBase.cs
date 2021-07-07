using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling
{
    public abstract class UrlArticleTransletiratorConstructorBase : IUrlTransletiratorConstructor<RawSeoModelArticle>
    {
        private IUrlTransletiratorConstructor<RawSeoModelArticle> _nextHandler;
        protected string delimeter = "id";
        public IUrlTransletiratorConstructor<RawSeoModelArticle> SetNext (IUrlTransletiratorConstructor<RawSeoModelArticle> handler)
        {
            _nextHandler = handler;

            return handler;
        }

        public virtual IEnumerable<UrlCombinationModel> Handle (RawSeoModelArticle request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}
