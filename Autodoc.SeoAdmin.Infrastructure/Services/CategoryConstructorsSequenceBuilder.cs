using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Domain.Entities;
using Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors;

namespace Autodoc.SeoAdmin.Infrastructure.Services
{
    public class CategoryConstructorsSequenceBuilder : IConstructorsSequenceBuilder<RawSeoModel>
    {
        public IUrlTransletiratorConstructor<RawSeoModel> BuildChain ()
        {           
            var categoryUrlConstructor = new UrlCategoryConstructor();
            var categoryBrandConstructor = new UrlCategoryBrandConstructor();
            var categoryMarkConstructor = new UrlCategoryMarkConstructor();
            var categoryMarkSerieBrandContructor = new UrlCategoryMarkSerieBrandConstructor();
            var categoryMarkSerieConstuctor = new UrlCategoryMarkSerieConstructor();

            categoryUrlConstructor
                    .SetNext(categoryMarkSerieBrandContructor)
                    .SetNext(categoryMarkSerieConstuctor)
                    .SetNext(categoryMarkConstructor)
                    .SetNext(categoryBrandConstructor);

            return categoryUrlConstructor;
        }
    }
}
