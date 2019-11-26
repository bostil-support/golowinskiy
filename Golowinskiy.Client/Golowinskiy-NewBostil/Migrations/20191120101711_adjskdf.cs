using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy_NewBostil.Migrations
{
    public partial class adjskdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "g",
                table: "Products");

            migrationBuilder.AddColumn<string>(
               name: "DisplayPassword",
               table: "AspNetUsers",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "g",
                table: "Products",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "DisplayPassword",
               table: "AspNetUsers");
        }
    }
}
