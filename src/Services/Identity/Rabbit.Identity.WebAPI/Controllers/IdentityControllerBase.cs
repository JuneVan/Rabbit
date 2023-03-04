using Rabbit.Authorization;

namespace Rabbit.Identity.WebAPI.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class IdentityControllerBase : ControllerBase
    {
        public IdentityControllerBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            Mediator = serviceProvider.GetService<IMediator>();
            Identifier = serviceProvider.GetService<IIdentifier>();
        }
        protected IServiceProvider ServiceProvider { get; private set; }
        protected IMediator Mediator { get; private set; }
        protected IIdentifier Identifier { get; private set; }
    }
}
