using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;

namespace TaxCalculator.BusinessLogic.Interfaces
{
    public interface ITaxBandService
    {
        Task<IEnumerable<TaxBandDto>> GetTaxBandsAsync();
    }
}
