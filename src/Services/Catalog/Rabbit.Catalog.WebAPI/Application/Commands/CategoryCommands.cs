namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    { 
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
