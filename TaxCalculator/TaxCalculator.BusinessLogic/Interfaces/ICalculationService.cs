using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;

namespace TaxCalculator.BusinessLogic.Interfaces
{
    public interface ICalculationService
    {
        Task<CalculationResultDto> CalculateTaxesAsync(decimal totalSalary);
    }
}
