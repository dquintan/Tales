using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pasajes.Api.Migrations
{
    public partial class PasajesDbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Century = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaleSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    TaleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaleSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaleSources_Tales_TaleId",
                        column: x => x.TaleId,
                        principalTable: "Tales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaleSources_TaleId",
                table: "TaleSources",
                column: "TaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaleSources");

            migrationBuilder.DropTable(
                name: "Tales");
        }
    }
}
