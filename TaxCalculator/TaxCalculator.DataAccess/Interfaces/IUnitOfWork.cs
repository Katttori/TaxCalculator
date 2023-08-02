using System.Threading.Tasks;
using TaxCalculator.Entities.Interfaces;

namespace TaxCalculator.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;

        Task SaveChangesAsync();
    }
}
