using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "auto_display",
                table: "ttype",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "display",
                table: "ttype",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "divider",
                table: "ttype",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "substractor",
                table: "ttype",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auto_display",
                table: "ttype");

            migrationBuilder.DropColumn(
                name: "display",
                table: "ttype");

            migrationBuilder.DropColumn(
                name: "divider",
                table: "ttype");

            migrationBuilder.DropColumn(
                name: "substractor",
                table: "ttype");
        }
    }
}
