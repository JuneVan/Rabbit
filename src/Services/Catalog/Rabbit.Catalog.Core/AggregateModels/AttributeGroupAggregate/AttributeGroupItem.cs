namespace Rabbit.Catalog.AggregateModels.AttributeGroupAggregate
{
    public class AttributeGroupItem : Entity
    {
        /// <summary>
        /// 属性Id
        /// </summary>
        public int AttributeId { get; private set; }

        /// <summary>
        /// 模板分组Id
        /// </summary>
        public int AttributeGroupId { get; private set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; private set; }
        public AttributeGroupItem(int attributeId, int displayOrder)
        {
            SetAttributeId(attributeId);
            SetDisplayOrder(displayOrder);
        }
        public void SetAttributeId(int attributeId)
        {
            if (attributeId < 0) throw new ArgumentOutOfRangeException(nameof(attributeId), "属性Id无效。");
            AttributeId = attributeId;
        }
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
