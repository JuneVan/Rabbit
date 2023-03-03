namespace Rabbit.Catalog.AggregateModels.TemplateAggregate
{
    /// <summary>
    /// 属性模板
    /// </summary>
    public class Template : Entity
    {

        private string _name;
        public int _categoryId;
        private List<TemplateGroup> _groups;
        public IReadOnlyList<TemplateGroup> Groups => _groups;
        public Template(string name, int categoryId)
        {
            SetName(name);
            _categoryId = categoryId;
            _groups = new List<TemplateGroup>();
        }
        /// <summary>
        /// 设置模板名称
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "属性模板名称不能为空");
            _name = name;
        }
        /// <summary>
        /// 设置分类Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCategory(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), $"分类Id`{categoryId}`无效");
            _categoryId = categoryId;
        }
        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="name">分组名称</param>
        /// <param name="displayOrder">分组排序值</param>
        public void AddGroup(string name, int displayOrder)
        {
            _groups.Add(new TemplateGroup(name, displayOrder));
        }
        /// <summary>
        /// 移除分组
        /// </summary>
        /// <param name="id">id</param>
        public void RemoveGroup(int id)
        {
            var group = _groups.FirstOrDefault(x => x.Id == id);
            if (group != null)
                _groups.Remove(group);
        }
        /// <summary>
        /// 更新分组
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">分组名称</param>
        /// <param name="displayOrder">分组排序值</param>
        /// <exception cref="ArgumentException"></exception>
        public void UpdateGroup(int id, string name, int displayOrder)
        {
            var group = _groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
                throw new ArgumentException($"分组Id`{id}`不存在");
            group.SetName(name);
            group.SetDisplayOrder(displayOrder);
        }
    }
}
