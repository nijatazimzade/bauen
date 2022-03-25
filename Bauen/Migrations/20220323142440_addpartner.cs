using Microsoft.EntityFrameworkCore.Migrations;

namespace Bauen.Migrations
{
    public partial class addpartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Partners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
