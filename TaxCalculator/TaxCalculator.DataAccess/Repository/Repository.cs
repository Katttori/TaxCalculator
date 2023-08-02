using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.Entities.Interfaces;

namespace TaxCalculator.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        protected IQueryable<TEntity> NoTrackingDbSet => DbSet.AsNoTracking();


        public Guid Create(TEntity entity)
        {
            DbSet.Add(entity);

            return entity.Id;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await NoTrackingDbSet.ToListAsync();
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            return NoTrackingDbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await NoTrackingDbSet.Where(filter).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            var existingEntity = DbSet.Find(entity.Id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}
