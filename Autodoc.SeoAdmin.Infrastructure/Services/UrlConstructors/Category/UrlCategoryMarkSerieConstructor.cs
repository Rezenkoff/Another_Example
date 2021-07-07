using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlCategoryMarkSerieConstructor : UrlCategoryTransletiratorConstructorBase
    {
        //category/toplivnyj-filtr-id333-3/bmw-id16--2000/x3-id27--2001/

        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (request.MarkId.HasValue && request.SerieId.HasValue && !request.SupplierId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}{delimeter}{request.MarkId}--{request.MarkPointer}{delimeter}{request.SerieId}--{request.SeriePointer}",
                        SeoParamId = request.Id,
                        KindTypeUrl = request.KindTypeUrlId,                       
                        TransliteratedUrl = 
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}" +
                        $"/{Transliteration.PerfomTransliteration(request.MarkName)}-{delimeter}{request.MarkId}--{request.MarkPointer}" +
                        $"/{Transliteration.PerfomTransliteration(request.SerieName)}-{delimeter}{request.SerieId}--{request.SeriePointer}"
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
