using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPizza.Migrations
{
    public partial class AddComposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Composition",
                table: "Drinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Composition",
                table: "Drinks");
        }
    }
}
