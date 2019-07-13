using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pasajes.Api.Migrations
{
    public partial class locationsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tales");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tales");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "TaleSources",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "TaleSources",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Tales",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "TaleLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    TaleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaleLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaleLocation_Tales_TaleId",
                        column: x => x.TaleId,
                        principalTable: "Tales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaleLocation_TaleId",
                table: "TaleLocation",
                column: "TaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaleLocation");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "TaleSources",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "TaleSources",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Tales",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Tales",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tales",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
