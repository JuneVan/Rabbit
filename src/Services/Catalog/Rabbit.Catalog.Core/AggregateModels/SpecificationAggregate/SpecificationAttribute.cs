namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    /// <summary>
    /// 规格属性
    /// </summary>
    public class SpecificationAttribute : Entity
    {
        /// <summary>
        /// 所属规格Id
        /// </summary>
        public int SpecificationId { get; private set; }
        /// <summary>
        /// 属性Id
        /// </summary>
        public int AttributeId { get; private set; }
        public SpecificationAttribute(int attributeId, int? attributeOptionId, string attributeValue)
        {
            if (attributeId <= 0) throw new ArgumentOutOfRangeException(nameof(attributeId), "属性Id无效。");
            AttributeId = attributeId;
            SetAttributeOptionId(attributeOptionId);
            SetAttributeValue(attributeValue);
        }

        /// <summary>
        /// 属性选项Id
        /// </summary>
        public int? AttributeOptionId { get; private set; }
        public void SetAttributeOptionId(int? attributeOptionId)
        {
            AttributeOptionId = attributeOptionId;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        public string AttributeValue { get; private set; }
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="attributeValue"></param>
        public void SetAttributeValue(string attributeValue)
        {
            if (attributeValue == null) throw new ArgumentNullException(nameof(attributeValue), "属性值不能为空。");
            AttributeValue = attributeValue;
        }
         
    }
}
