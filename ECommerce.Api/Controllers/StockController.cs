using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
