using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors
{
    public class UrlCategoryMarkConstructor : UrlCategoryTransletiratorConstructorBase
    {
        public override IEnumerable<UrlCombinationModel> Handle (RawSeoModel request)
        {
            if (request.MarkId.HasValue && !request.SerieId.HasValue && !request.SupplierId.HasValue)
            {
                return new List<UrlCombinationModel>() {
                    new UrlCombinationModel()
                    {
                        SeoParamId = request.Id,
                        HashCode = $"{delimeter}{request.NodeId}-{(int)_constructedPageType}{delimeter}{request.MarkId}--{request.MarkPointer}",
                        KindTypeUrl = request.KindTypeUrlId,                        
                        TransliteratedUrl = 
                        $"{firstUrlSegment}" +
                        $"/{Transliteration.PerfomTransliteration(request.NodeName)}-{delimeter}{request.NodeId}-{(int)_constructedPageType}" +
                        $"/{Transliteration.PerfomTransliteration(request.MarkName)}-{delimeter}{request.MarkId}--{request.MarkPointer}", 
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
