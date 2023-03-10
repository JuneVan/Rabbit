namespace Rabbit.Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")] 
    public class BrandController : CatalogControllerBase
    {
        public BrandController(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
            
        }


    }
}
