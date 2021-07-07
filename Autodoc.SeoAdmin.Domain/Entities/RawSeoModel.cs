namespace Autodoc.SeoAdmin.Domain.Entities
{
    public class RawSeoModel
    {
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? SerieId { get; set; }
        public int? MarkId { get; set; }
        public int? SupplierId { get; set; }
        public int NodeId { get; set; } = -1;         
        public int KindTypeUrlId { get; set; }
        public string ArticleName { get; set; }
        public string SerieName { get; set; }
        public string MarkName { get; set; }
        public string NodeName { get; set; }
        public string MarkPointer { get; set; } = "2000";
        public string SeriePointer { get; set; } = "2001";
        public string SupplierName { get; set; } 
        public string SupplierNodeSuffix { get; set; }
        public bool HasAdditionalProperty { get; set; }
    }
}
