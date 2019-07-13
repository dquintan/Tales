using Microsoft.EntityFrameworkCore.Migrations;

namespace Pasajes.Api.Migrations
{
    public partial class PasajesDbAddAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Tales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Tales");
        }
    }
}
