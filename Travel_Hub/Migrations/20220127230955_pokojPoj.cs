using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_Hub.Migrations
{
    public partial class pokojPoj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pojemnosc",
                table: "RodzajePokoi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pojemnosc",
                table: "RodzajePokoi");
        }
    }
}
