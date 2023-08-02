using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.BusinessLogic.Interfaces;

namespace TaxCalculator.BusinessLogic.Services
{
    internal class CalculatorService : ICalculatorService
    {
        public Task<CalculationResultDto> CalculateTaxesAsync(int totalSalary)
        {
            throw new NotImplementedException();
        }
    }
}
