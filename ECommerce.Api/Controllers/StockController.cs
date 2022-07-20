using ECommerce.Application.Common.DTOs.Response;
using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Add([FromBody] CreateStockDto createStockDto)
        {
            if (createStockDto == null)
                return CreateActionResult(ResponseState<Stock>.Handle(400, "Geçersiz bir istek", null));

            await _stockService.AddAsync(createStockDto);
            return CreateActionResult(ResponseState<Stock>.Handle(201, "Stok Başarılı bir şekilde eklendi", null));
        }
    }
}
