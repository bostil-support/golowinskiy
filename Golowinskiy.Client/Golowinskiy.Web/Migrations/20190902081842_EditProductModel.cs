using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy.Web.Migrations
{
    public partial class EditProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileTitile",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileTitile",
                table: "Products",
                nullable: true);
        }
    }
}
