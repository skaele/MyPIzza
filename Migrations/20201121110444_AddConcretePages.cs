using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPizza.Migrations
{
    public partial class AddConcretePages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Composition",
                table: "Pizzas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Composition",
                table: "Pizzas");
        }
    }
}
