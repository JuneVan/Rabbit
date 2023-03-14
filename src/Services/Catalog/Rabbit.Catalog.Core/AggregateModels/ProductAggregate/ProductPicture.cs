namespace Rabbit.Catalog.AggregateModels.ProductAggregate
{
    /// <summary>
    /// 商品图片
    /// </summary>
    public class ProductPicture : AuditedEntity
    {
        public int ProductId { get; private set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string Url { get; private set; }
        public ProductPicture(string url, int displayOrder)
        {
            if (url == null) throw new ArgumentNullException(nameof(url), "图片地址不能设置为空。");
            SetDisplayOrder(displayOrder);
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; private set; }
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
