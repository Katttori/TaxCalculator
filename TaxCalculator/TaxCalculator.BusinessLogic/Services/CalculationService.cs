using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.BusinessLogic.Extensions;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.BusinessLogic.Services
{
    internal class CalculationService : ICalculationService
    {
        private int monthCount = 12;
        private readonly ITaxBandService _taxBandService;
        private readonly ILogger<CalculationService> _logger;


        public CalculationService(ITaxBandService taxBandService, ILogger<CalculationService> logger)
        {
            _taxBandService = taxBandService;
            _logger = logger;
        }

        public async Task<CalculationResultDto> CalculateTaxesAsync(decimal totalSalary)
        {
            var actualSalary = totalSalary.Round();
            _logger.LogInformation("Calculation started for {income}", actualSalary);

            var taxBands = await _taxBandService.GetTaxBandsAsync();
            Calculation calculation = new Calculation { RemainingSalary = actualSalary, Taxes = 0 };

            foreach (var taxBand in taxBands.OrderBy(band => band.LowerLimit))
            {
                if (calculation.RemainingSalary <= 0)
                {
                    break;
                }

                calculation = CalculateTaxBand(calculation, taxBand);
            }

            var netAnnualSalary = actualSalary - calculation.Taxes;
            return new CalculationResultDto
            {
                GrossAnnualSalary = actualSalary,
                GrossMonthlySalary = (actualSalary / monthCount).Round(),
                NetAnnualSalary = (netAnnualSalary).Round(),
                NetMonthlySalary = (netAnnualSalary / monthCount).Round(),
                AnnualTaxPaid = (calculation.Taxes).Round(),
                MonthlyTaxPaid = (calculation.Taxes / monthCount).Round(),
            };
        }

        private Calculation CalculateTaxBand(Calculation calculation, TaxBandDto taxBand)
        {
            decimal remainingSalary;

            if (taxBand.UpperLimit != null && calculation.RemainingSalary > taxBand.UpperLimit)
            {
                remainingSalary = taxBand.UpperLimit.Value - taxBand.LowerLimit;
                calculation.RemainingSalary -= remainingSalary;
            }
            else
            {
                remainingSalary = calculation.RemainingSalary;
                calculation.RemainingSalary = 0;
            }

            calculation.Taxes += remainingSalary * ((decimal)taxBand.TaxRate / 100);

            return calculation;
        }
    }
}
