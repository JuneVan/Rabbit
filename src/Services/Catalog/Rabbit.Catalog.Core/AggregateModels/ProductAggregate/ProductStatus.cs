namespace Rabbit.Catalog.AggregateModels.ProductAggregate
{
    /// <summary>
    /// 商品状态
    /// </summary>
    public enum ProductStatus
    {
        /// <summary>
        /// 草稿状态 
        /// </summary>
        /// <remarks>无需检查信息是否完整</remarks>
        [Description("草稿状态")]
        Draft = 0,
        /// <summary>
        /// 上架状态
        /// </summary>
        [Description("上架状态")]
        Published = 1,
        /// <summary>
        /// 下架状态
        /// </summary>
        [Description("下架状态")]
        UnPublished = 2

    }
}
