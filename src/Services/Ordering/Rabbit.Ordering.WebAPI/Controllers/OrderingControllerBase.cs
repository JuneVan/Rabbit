using Microsoft.AspNetCore.Mvc;

namespace Rabbit.Ordering.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class OrderingControllerBase : ControllerBase
    {

    }
}