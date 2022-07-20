using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.DTOs.Response;
using ECommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productCode}/stock")]
        public async Task<IActionResult> Get(string productCode)
        {
            var response = await _productService.GetStocksByProductCodeAsync(productCode);
            return CreateActionResult(ResponseState<List<StockDto>>.Handle(200, "", response));
        }
    }
}
