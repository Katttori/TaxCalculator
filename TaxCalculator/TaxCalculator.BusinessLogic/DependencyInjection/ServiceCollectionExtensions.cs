using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.BusinessLogic.Configuration;
using TaxCalculator.BusinessLogic.Interfaces;
using TaxCalculator.BusinessLogic.Services;
using TaxCalculator.Configuration.Extensions;
using TaxCalculator.DataAccess.Configuration;
using TaxCalculator.DataAccess.DependencyInjection;

namespace TaxCalculator.BusinessLogic.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicComponents(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<GeneralSettings>(configuration);
            var connectionStrings = services.AddSettings<ConnectionStrings>(configuration);
            services.AddUnitOfWork(connectionStrings);
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));
            services.AddScoped<ITaxBandService, TaxBandService>();
            services.AddScoped<ICalculationService, CalculationService>();
        }
    }
}
