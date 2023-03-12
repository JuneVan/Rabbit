namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    public class Specification : FullAuditedAggregateRoot
    {
        /// <summary>
        /// 规格名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; private set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; private set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal SalesPrice { get; private set; }
        /// <summary>
        /// 是否上架
        /// </summary>
        public bool IsPublished { get; private set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Stock { get; private set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; private set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; private set; }
        /// <summary>
        /// 获取属性列表
        /// </summary>
        public IReadOnlyCollection<SpecificationAttribute> Attributes => _attributes.AsReadOnly();
        private List<SpecificationAttribute> _attributes;

        /// <summary>
        /// 获取图片列表
        /// </summary>
        public IReadOnlyCollection<ProductPicture> Pictures => _pictures.AsReadOnly();
        private List<ProductPicture> _pictures;
    }
}
