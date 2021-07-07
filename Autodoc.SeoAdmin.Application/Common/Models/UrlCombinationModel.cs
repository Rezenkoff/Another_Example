using Autodoc.SeoAdmin.Domain.Enum;
using System;

namespace Autodoc.SeoAdmin.Application.Common.Models
{
    public class UrlCombinationModel
    {
        public string HashCode { get; set; }
        public int KindTypeUrl { get; set; }
        public int SeoParamId { get; set; }
        public string TransliteratedUrl { get; set; }
        public DateTime LastAccess { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Deleted { get; set; }
        public LinkingStatus LinkingStatus { get; set; }
        public GenerationStatus GenerationStatus { get; set; }

    }
}
