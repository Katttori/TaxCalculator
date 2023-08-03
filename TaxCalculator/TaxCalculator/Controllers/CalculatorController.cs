using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("calculator")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationService _calculatorService;
        private readonly ILogger _logger;

        public CalculatorController(ICalculationService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> CalculateTaxes([FromQuery] int income) 
        {
            var calculationResult = await _calculatorService.CalculateTaxesAsync(income);
            return Ok(calculationResult);
        }
    }
}
