using Rabbit.Catalog.WebAPI.Commands.Catagories;

namespace Rabbit.Catalog.WebAPI.Controllers
{
    public class CategoryController : CatalogControllerBase
    {
        public CategoryController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }
        /// <summary>
        /// 创建或更新分类
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateOrUpdate([FromBody] CreateOrUpdateCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
