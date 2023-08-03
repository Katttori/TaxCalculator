using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.BusinessLogic.Services
{
    internal class CalculationService : ICalculationService
    {
        private readonly ITaxBandService _taxBandService;

        public CalculationService(ITaxBandService taxBandService)
        {
            _taxBandService = taxBandService;
        }

        public async Task<CalculationResultDto> CalculateTaxesAsync(int totalSalary)
        {
            var taxBands = await _taxBandService.GetTaxBandsAsync();
            Calculation calculation = new Calculation { RemainingSalary = totalSalary, Taxes = 0 };

            foreach (var taxBand in taxBands.OrderBy(band => band.LowerLimit))
            {
                if (calculation.RemainingSalary <= 0)
                {
                    break;
                }

                calculation = CalculateTaxBand(calculation, taxBand);
            }

            var netAnnualSalary = (double)totalSalary - calculation.Taxes;
            return new CalculationResultDto
            {
                GrossAnnualSalary = totalSalary,
                GrossMonthlySalary = Round((double)totalSalary / 12),
                NetAnnualSalary = Round(netAnnualSalary),
                NetMonthlySalary = Round(netAnnualSalary / 12),
                AnnualTaxPaid = Round(calculation.Taxes),
                MonthlyTaxPaid = Round(calculation.Taxes / 12),
            };
        }

        private Calculation CalculateTaxBand(Calculation calculation, TaxBandDto taxBand)
        {
            double remainingSalary;

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

            calculation.Taxes += remainingSalary * ((double)taxBand.TaxRate / 100);

            return calculation;
        }

        private double Round(double value)
        {
            return Math.Round(value, 2);
        }
    }
}
