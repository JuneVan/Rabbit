namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    public class SpecificationPicture : Entity
    {
        public int SpecificationId { get; private set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string Url { get; private set; }
        public SpecificationPicture(string url, int displayOrder)
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
