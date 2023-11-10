using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("api/calculation")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculatorService;
        private readonly ILogger _logger;

        public CalculationController(ICalculationService calculatorService, ILogger<CalculationController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> CalculateTaxes([FromQuery] decimal income) 
        {
            _logger.BeginScope("Calculation");

            var calculationResult = await _calculatorService.CalculateTaxesAsync(income);
            return Ok(calculationResult);
        }
    }
}
