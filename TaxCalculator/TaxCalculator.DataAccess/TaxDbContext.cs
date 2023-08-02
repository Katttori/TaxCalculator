using Microsoft.EntityFrameworkCore;
using System;
using TaxCalculator.DataAccess.Extensions;

namespace TaxCalculator.DataAccess
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions<TaxDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTaxBands();
        }
    }
}
