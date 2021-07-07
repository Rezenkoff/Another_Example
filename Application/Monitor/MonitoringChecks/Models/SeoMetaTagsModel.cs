using System.Collections.Generic;

namespace Monitor.Application.MonitoringChecks.Models
{
    public class SeoMetaTagsModel
    {
        public string Title { get; set; }
        public IEnumerable<MetaTag> Metatags { get; set; }
    }

    public class MetaTag
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
