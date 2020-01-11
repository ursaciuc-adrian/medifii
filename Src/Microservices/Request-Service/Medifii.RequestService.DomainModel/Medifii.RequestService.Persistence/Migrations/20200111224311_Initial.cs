using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medifii.RequestService.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PharmacyId = table.Column<Guid>(nullable: false),
                    ProductName_Value = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ResolvedStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
