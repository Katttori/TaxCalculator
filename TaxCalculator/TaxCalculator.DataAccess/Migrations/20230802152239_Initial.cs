using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBand",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    LowerLimit = table.Column<int>(nullable: false),
                    UpperLimit = table.Column<int>(nullable: true),
                    TaxRate = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBand", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxBand",
                columns: new[] { "Id", "LowerLimit", "Name", "TaxRate", "UpperLimit" },
                values: new object[] { new Guid("601446ca-bad4-473d-b1ef-6d05bf72bc06"), 0, "Tax band A", 0, 5000 });

            migrationBuilder.InsertData(
                table: "TaxBand",
                columns: new[] { "Id", "LowerLimit", "Name", "TaxRate", "UpperLimit" },
                values: new object[] { new Guid("fc972069-672b-4d7f-879d-6e46348790d7"), 5000, "Tax band B", 20, 20000 });

            migrationBuilder.InsertData(
                table: "TaxBand",
                columns: new[] { "Id", "LowerLimit", "Name", "TaxRate", "UpperLimit" },
                values: new object[] { new Guid("764935e0-475d-41b0-b0e9-a6f0ca3d3f3b"), 20000, "Tax band C", 40, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBand");
        }
    }
}
