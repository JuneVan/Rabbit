namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateUnitCommand : IRequest<int>
    {
        public string Name { get; set; }

        /// <summary>
        /// 获取是否可用状态 
        /// </summary>
        public bool IsActive { get; set; }
    }

    public class UpdateUnitCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 获取是否可用状态 
        /// </summary>
        public bool IsActive { get; set; }
    }
    public class DeleteUnitCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
