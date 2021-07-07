using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using Autodoc.SeoAdmin.Domain.Enum;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling
{
    public abstract class UrlCategoryTransletiratorConstructorBase : IUrlTransletiratorConstructor<RawSeoModel>
    {
        protected PageTypes _constructedPageType = PageTypes.Category;
        private IUrlTransletiratorConstructor<RawSeoModel> _nextHandler;
        protected string delimeter = "id";
        protected string firstUrlSegment = "category";

        public IUrlTransletiratorConstructor<RawSeoModel> SetNext (IUrlTransletiratorConstructor<RawSeoModel> handler)
        {
            _nextHandler = handler;

            return handler;
        }

        public virtual IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
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
