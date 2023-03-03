using Microsoft.AspNetCore.Mvc;

namespace Rabbit.Identity.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class IdentityControllerBase : ControllerBase
    {

    }
}