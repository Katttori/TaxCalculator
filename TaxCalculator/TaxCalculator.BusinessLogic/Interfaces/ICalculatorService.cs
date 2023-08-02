using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;

namespace TaxCalculator.BusinessLogic.Interfaces
{
    public interface ICalculatorService
    {
        Task<CalculationResultDto> CalculateTaxesAsync(int totalSalary);
    }
}
