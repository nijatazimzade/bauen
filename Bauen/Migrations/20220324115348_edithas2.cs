using Microsoft.EntityFrameworkCore.Migrations;

namespace Bauen.Migrations
{
    public partial class edithas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightHtml",
                table: "HomeAboutSections",
                newName: "ImgName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "HomeAboutSections",
                newName: "RightHtml");
        }
    }
}
