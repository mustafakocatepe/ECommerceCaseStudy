using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.DTOs.Response;
using ECommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/variants")]
    public class VariantController : BaseController
    {
        private readonly IStockService _stockService;
        public VariantController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{variantCode}/stock")]
        public async Task<IActionResult> Get(string variantCode)
        {
            var response = await _stockService.GetStockByVariantCodeAsync(variantCode);
            return CreateActionResult(ResponseState<StockDto>.Handle(200, "", response));
        }
    }
}
