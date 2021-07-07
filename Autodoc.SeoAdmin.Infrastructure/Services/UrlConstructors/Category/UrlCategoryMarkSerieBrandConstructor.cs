using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlCategoryMarkSerieBrandConstructor : UrlCategoryTransletiratorConstructorBase
    {
        //category/toplivnyj-filtr-id333-3/bmw-id16--2000/x3-id27--2001/bosch-id27--1000
       
        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (request.MarkId.HasValue && request.SerieId.HasValue && request.SupplierId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}{delimeter}{request.MarkId}--{request.MarkPointer}{delimeter}{request.SerieId}--{request.SeriePointer}{delimeter}{request.SupplierId}--{request.SupplierNodeSuffix}",
                        KindTypeUrl = request.KindTypeUrlId,                         
                        TransliteratedUrl =
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}" +
                        $"/{Transliteration.PerfomTransliteration(request.MarkName)}-{delimeter}{request.MarkId}--{request.MarkPointer}" +
                        $"/{Transliteration.PerfomTransliteration(request.SerieName)}-{delimeter}{request.SerieId}--{request.SeriePointer}" +
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
