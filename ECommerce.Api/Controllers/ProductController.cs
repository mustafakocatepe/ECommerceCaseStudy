using ECommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productCode}/stock")]
        public IActionResult Get(string productCode)
        {
            var response = _productService.GetStocksByProductCodeAsync(productCode);
            return Ok();
        }
    }
}
