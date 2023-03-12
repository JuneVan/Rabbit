namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    public class SpecificationPicture : Entity
    {
        public int SpecificationId { get; private set; }
        public string VirtualPath { get; private set; }
        public int DisplayOrder { get; private set; }
    }
}
