using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.DataAccess.Configuration;
using TaxCalculator.DataAccess.Interfaces;

namespace TaxCalculator.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services, ConnectionStrings configuration)
        {
            services.AddDbContext<TaxDbContext>(options =>
                options.UseSqlServer(configuration.TaxDbConnection));
            services.AddScoped<DbContext, TaxDbContext>(provider => provider.GetService<TaxDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
