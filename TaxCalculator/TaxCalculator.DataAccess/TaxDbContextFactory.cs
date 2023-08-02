using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaxCalculator.DataAccess
{
    public class TaxDbContextFactory : IDesignTimeDbContextFactory<TaxDbContext>
    {
        private const string ConnectionStringName = "TaxDbConnection";
        private const string EnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
        private const string LocalConnectionString = "Server=.;Database=Tax;Trusted_Connection=True;";

        public TaxDbContext CreateDbContext(string[] args)
        {
            var currentEnv = Environment.GetEnvironmentVariable(EnvironmentVariableName);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{currentEnv}.json", true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaxDbContext>();
            var connectionString = config.GetConnectionString(ConnectionStringName) ??
                                   config[ConnectionStringName] ??
                                   LocalConnectionString;

            optionsBuilder.UseSqlServer(connectionString);

            return new TaxDbContext(optionsBuilder.Options);
        }
    }
}
