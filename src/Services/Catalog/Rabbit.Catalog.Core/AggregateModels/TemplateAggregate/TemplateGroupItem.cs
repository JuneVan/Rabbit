namespace Rabbit.Catalog.AggregateModels.TemplateAggregate
{
    public class TemplateGroupItem : Entity
    {
        /// <summary>
        /// 属性Id
        /// </summary>
        public int AttributeId { get; private set; }

        /// <summary>
        /// 模板分组Id
        /// </summary>
        public int GroupId { get; private set; }
        /// <summary>
        /// 模板Id
        /// </summary>
        public int TemplateId { get; private set; }
        public TemplateGroupItem(int attributeId)
        {
            SetAttributeId(attributeId);
        }
        public void SetAttributeId(int attributeId)
        {
            if (attributeId < 0) throw new ArgumentOutOfRangeException(nameof(attributeId), "属性Id无效。");
            AttributeId = attributeId;
        }
    }
}
