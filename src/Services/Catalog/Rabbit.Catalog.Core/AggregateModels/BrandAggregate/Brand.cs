namespace Rabbit.Catalog.AggregateModels.BrandAggregate
{
    /// <summary>
    /// 品牌
    /// </summary>
    public class Brand : Entity
    {
        public Brand(string name, string description, string logo)
        {
            SetName(name);
            SetDescription(description);
            SetLogo(logo);
        }
        public string Name { get; private set; }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "品牌名称不能为空");
            Name = name;
        }
        public string Description { get; private set; }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public string Logo { get; private set; }
        public void SetLogo(string logo)
        {
            Logo = logo;
        }
    }
}
