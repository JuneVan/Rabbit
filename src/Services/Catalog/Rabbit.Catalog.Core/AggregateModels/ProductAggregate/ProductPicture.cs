namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    public class ProductPicture : Entity
    {
        public int ProductId { get; private set; }
        public string VirtualPath { get; private set; }
        public ProductPicture(string virtualPath, int displayOrder)
        {
            if (virtualPath == null) throw new ArgumentNullException(nameof(virtualPath), "图片地址不能设置为空。");
            SetDisplayOrder(displayOrder);
        }
        public int DisplayOrder { get; private set; }
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
