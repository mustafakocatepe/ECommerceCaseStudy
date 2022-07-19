using ECommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/variants")]
    public class VariantController : Controller
    {
        private readonly IVariantService _variantService;
        public VariantController(IVariantService variantService)
        {
            _variantService = variantService;
        }

        [HttpGet("{variantCode}/stock")]
        public IActionResult Get(string variantCode)
        {
            return View();
        }
    }
}
