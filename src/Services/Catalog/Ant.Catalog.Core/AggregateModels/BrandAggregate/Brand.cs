namespace Ant.Catalog.AggregateModels.BrandAggregate
{
    public class Brand : Entity
    {
        private string _name;
        private string _description;
        private string _logo;
        public Brand(string name, string description, string logo)
        {
            SetName(name);
            SetDescription(description);
            SetLogo(logo);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "品牌名称不能为空");
            _name = name;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public void SetLogo(string logo)
        {
            _logo = logo;
        }
    }
}
