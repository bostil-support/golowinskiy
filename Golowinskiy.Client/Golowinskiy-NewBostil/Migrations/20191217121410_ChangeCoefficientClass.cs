using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy_NewBostil.Migrations
{
    public partial class ChangeCoefficientClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Coefficient",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "AspNetUsers");
        }
    }
}
