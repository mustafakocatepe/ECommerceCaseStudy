﻿using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateStockDto createStockDto)
        {
            _stockService.AddAsync(createStockDto);
            return Ok();
        }
    }
}
