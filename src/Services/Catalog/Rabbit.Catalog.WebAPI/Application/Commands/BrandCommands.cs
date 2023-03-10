namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateBrandCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }

    public class UpdateBrandCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }
    public class DeleteBrandCommand : IRequest
    {
        public int Id { get; set; }
    }
}
