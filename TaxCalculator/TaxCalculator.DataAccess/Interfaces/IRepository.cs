using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.DataAccess.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Guid Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
