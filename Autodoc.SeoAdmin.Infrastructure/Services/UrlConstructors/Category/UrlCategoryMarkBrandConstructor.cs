using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlCategoryMarkBrandConstructor : UrlCategoryTransletiratorConstructorBase
    {
        //category/vozdushnyj-filtr-id349-3/bmw-id16--2000/ashika-id1331--1000

        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (request.SupplierId.HasValue && request.MarkId.HasValue && !request.SerieId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}{delimeter}{request.MarkPointer}{delimeter}{request.SupplierId}--{request.SupplierNodeSuffix}",
                        KindTypeUrl = request.KindTypeUrlId,                        
                        TransliteratedUrl = 
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}" +
                        $"/{Transliteration.PerfomTransliteration(request.MarkName)}-{delimeter}{request.MarkPointer}" +
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
