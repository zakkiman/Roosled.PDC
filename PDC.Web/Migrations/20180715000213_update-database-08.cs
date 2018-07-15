using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pain_pleasure",
                table: "ttype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passive_active",
                table: "ttype",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "self_other",
                table: "ttype",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pain_pleasure",
                table: "ttype");

            migrationBuilder.DropColumn(
                name: "passive_active",
                table: "ttype");

            migrationBuilder.DropColumn(
                name: "self_other",
                table: "ttype");
        }
    }
}
