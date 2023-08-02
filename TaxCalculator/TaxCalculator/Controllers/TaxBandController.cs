using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("tax-band")]
    public class TaxBandController : ControllerBase
    {
        private readonly ITaxBandService _taxBandService;
        private readonly ILogger _logger;

        public TaxBandController(ITaxBandService taxBandService, ILogger<TaxBandController> logger)
        {
            _taxBandService = taxBandService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxBands() 
        {
            _logger.BeginScope($"Tax bands");
            var taxBands = await _taxBandService.GetTaxBandsAsync();
            return Ok(taxBands);
        }
    }
}
