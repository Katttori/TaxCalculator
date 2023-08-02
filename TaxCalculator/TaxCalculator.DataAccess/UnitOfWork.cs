using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.DataAccess.Repository;
using TaxCalculator.Entities.Interfaces;

namespace TaxCalculator.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositoryStorage;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositoryStorage = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            if (_repositoryStorage.ContainsKey(typeof(TEntity)))
            {
                return _repositoryStorage[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_context);
            _repositoryStorage.Add(typeof(TEntity), repository);

            return repository;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
