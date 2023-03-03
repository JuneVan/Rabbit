using Microsoft.AspNetCore.Mvc;

namespace Rabbit.Membership.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public abstract class MembershipControllerBase : ControllerBase
    {

    }
}