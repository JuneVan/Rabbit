namespace Rabbit.Catalog.WebAPI.Commands.Catagories
{
    public class CreateOrUpdateCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
