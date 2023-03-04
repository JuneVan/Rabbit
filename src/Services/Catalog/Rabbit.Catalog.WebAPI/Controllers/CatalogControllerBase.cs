namespace Rabbit.Catalog.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class CatalogControllerBase : ControllerBase
    {
        public CatalogControllerBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Mediator = serviceProvider.GetService<IMediator>();
        }

        public virtual IServiceProvider ServiceProvider { get; private set; }
        public virtual IMediator Mediator { get; private set; }
    }
}