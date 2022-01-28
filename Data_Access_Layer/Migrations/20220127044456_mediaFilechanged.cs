using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class mediaFilechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "MediaFiles");

            migrationBuilder.RenameColumn(
                name: "File",
                table: "MediaFiles",
                newName: "FileData");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "MediaFiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "MediaFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "MediaFiles",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "MediaFiles");

            migrationBuilder.RenameColumn(
                name: "FileData",
                table: "MediaFiles",
                newName: "File");

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "MediaFiles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
