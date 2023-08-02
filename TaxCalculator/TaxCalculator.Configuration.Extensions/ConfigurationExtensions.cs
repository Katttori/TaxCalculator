using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaxCalculator.Configuration.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TSettings AddSettings<TSettings>(this IServiceCollection services, IConfiguration configuration) where TSettings : class, new()
        {
            TSettings settings = configuration.GetSettings<TSettings>();
            services.AddScoped((IServiceProvider provider) => settings);
            return settings;
        }

        public static TSettings GetSettings<TSettings>(this IConfiguration configuration) where TSettings : class, new()
        {
            TSettings val = new TSettings();
            configuration.Bind(typeof(TSettings).Name, val);
            return val;
        }
    }
}
