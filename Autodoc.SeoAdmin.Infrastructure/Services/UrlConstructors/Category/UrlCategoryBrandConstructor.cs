using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    //category/vozdushnyj-filtr-id349-3/bosch-id27--1000
    //category/akb-id711-3/bosch-id27--1004
    //category/led-avtolampy-id759-3/bosch-id27--1005
    //category/tormoznaya-zhidkost-id45-3/bosch-id27--1006

    public class UrlCategoryBrandConstructor : UrlCategoryTransletiratorConstructorBase
    {       
        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (request.SupplierId.HasValue && !request.MarkId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}{delimeter}{request.SupplierId}--{request.SupplierNodeSuffix}",
                        KindTypeUrl = request.KindTypeUrlId,                        
                        TransliteratedUrl =
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}" +
                        $"/{Transliteration.PerfomTransliteration(request.SupplierName)}-{delimeter}{request.SupplierId}--{request.SupplierNodeSuffix}"
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
