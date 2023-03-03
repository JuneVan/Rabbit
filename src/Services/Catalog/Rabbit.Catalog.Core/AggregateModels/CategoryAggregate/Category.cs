namespace Rabbit.Catalog.AggregateModels.CategoryAggregate
{
    public class Category : FullAuditedEntity
    {
        private string _name;
        private int? _parentId;
        private int _displayOrder;
        public Category(string name, int? parentId, int displayOrder)
        {
            SetName(name);
            SetParentId(parentId);
            SetDisplayOrder(displayOrder);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "分类名称不能为空");
            _name = name;
        }
        public void SetParentId(int? parentId)
        {
            _parentId = parentId;
        }
        public void SetDisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
        }

    }
}
