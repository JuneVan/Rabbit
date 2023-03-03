namespace Rabbit.Catalog.AggregateModels.TemplateAggregate
{
    public class TemplateGroupItem : Entity
    {

        private int _attributeId;
        public TemplateGroupItem(int attributeId)
        {
            SetAttributeId(attributeId);
        }
        public void SetAttributeId(int attributeId)
        {
            if (attributeId < 0) throw new ArgumentOutOfRangeException(nameof(attributeId), $"属性Id`{attributeId}`无效");
            _attributeId = attributeId;
        }
    }
}
