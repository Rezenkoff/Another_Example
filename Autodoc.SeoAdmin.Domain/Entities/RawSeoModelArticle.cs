using Autodoc.SeoAdmin.Domain.Enum;

namespace Autodoc.SeoAdmin.Domain.Entities
{
    public class RawSeoModelArticle
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }        
        public int NodeId { get; set; } = -1;
        public string NodeName { get; set; }        
        public GenerationStatus GenerationStatus { get; set; }
        public LinkingStatus LinkingStatus { get; set; }
    }
}
