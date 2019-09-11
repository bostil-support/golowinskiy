using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Golowinskiy.Web.Migrations
{
    public partial class ImageEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagedata",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Imagedata",
                table: "AdditionalImages");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Products",
                newName: "MainImage");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "AdditionalImages",
                newName: "ImageLink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "Products",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "AdditionalImages",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagedata",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagedata",
                table: "AdditionalImages",
                nullable: true);
        }
    }
}
