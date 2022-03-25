using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bauen.Migrations
{
    public partial class addprojectedits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectToCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DetailedHeading",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Projects",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Client",
                table: "Projects",
                newName: "Company");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Projects",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Projects",
                newName: "Client");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DetailedHeading",
                table: "Projects",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectToCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectToCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectToCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectToCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectToCategories_CategoryId",
                table: "ProjectToCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectToCategories_ProjectId",
                table: "ProjectToCategories",
                column: "ProjectId");
        }
    }
}
