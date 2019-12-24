using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medifii.PharmacyService.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name_Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PharmacyId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyProducts_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProducts_PharmacyId",
                table: "PharmacyProducts",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyProducts");

            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
