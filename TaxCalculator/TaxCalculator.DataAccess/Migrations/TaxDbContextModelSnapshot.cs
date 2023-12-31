﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.DataAccess;

namespace TaxCalculator.DataAccess.Migrations
{
    [DbContext(typeof(TaxDbContext))]
    partial class TaxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaxCalculator.Entities.Entities.TaxBand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LowerLimit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("TaxRate")
                        .HasColumnType("int")
                        .HasMaxLength(100);

                    b.Property<int?>("UpperLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaxBand");

                    b.HasData(
                        new
                        {
                            Id = new Guid("601446ca-bad4-473d-b1ef-6d05bf72bc06"),
                            LowerLimit = 0,
                            Name = "Tax band A",
                            TaxRate = 0,
                            UpperLimit = 5000
                        },
                        new
                        {
                            Id = new Guid("fc972069-672b-4d7f-879d-6e46348790d7"),
                            LowerLimit = 5000,
                            Name = "Tax band B",
                            TaxRate = 20,
                            UpperLimit = 20000
                        },
                        new
                        {
                            Id = new Guid("764935e0-475d-41b0-b0e9-a6f0ca3d3f3b"),
                            LowerLimit = 20000,
                            Name = "Tax band C",
                            TaxRate = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
