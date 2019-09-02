using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy.Web.Migrations
{
    public partial class EditAddtImgModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileTitile",
                table: "AdditionalImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileTitile",
                table: "AdditionalImages",
                nullable: true);
        }
    }
}
