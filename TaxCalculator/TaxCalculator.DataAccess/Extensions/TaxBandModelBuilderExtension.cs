using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataAccess.Configuration;
using TaxCalculator.Entities.Entities;

namespace TaxCalculator.DataAccess.Extensions
{
    internal static class TaxBandModelBuilderExtension
    {
        public static ModelBuilder ConfigureTaxBands(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>(entity => 
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.StringMaxLength);

                entity.Property(x => x.LowerLimit)
                    .IsRequired();

                entity.Property(x => x.UpperLimit)
                    .IsRequired(false);

                entity.Property(x => x.TaxRate)
                    .IsRequired()
                    .HasMaxLength(Constants.Percentage);

                entity.SeedData();

            });
            return modelBuilder;
        }

        private static void SeedData(this EntityTypeBuilder<TaxBand> entity)
        {
            entity.HasData(new TaxBand
            {
                Id = Guid.Parse("601446ca-bad4-473d-b1ef-6d05bf72bc06"),
                Name = "Tax band A",
                LowerLimit = 0,
                UpperLimit = 5000,
                TaxRate = 0
            },
            new TaxBand
            {
                Id = Guid.Parse("fc972069-672b-4d7f-879d-6e46348790d7"),
                Name = "Tax band B",
                LowerLimit = 5000,
                UpperLimit = 20000,
                TaxRate = 20
            },
            new TaxBand
            {
                Id = Guid.Parse("764935e0-475d-41b0-b0e9-a6f0ca3d3f3b"),
                Name = "Tax band C",
                LowerLimit = 20000,
                UpperLimit = null,
                TaxRate = 40
            });
        }
    }
}
