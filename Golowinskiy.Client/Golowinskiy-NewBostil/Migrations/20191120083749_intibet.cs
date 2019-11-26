using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy_NewBostil.Migrations
{
    public partial class intibet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "g",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "g",
                table: "Products");
        }
    }
}
