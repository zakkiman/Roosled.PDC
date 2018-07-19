using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "report_description",
                table: "tprogram");

            migrationBuilder.AddColumn<string>(
                name: "report_description",
                table: "tapplicantprogram",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "report_description",
                table: "tapplicantprogram");

            migrationBuilder.AddColumn<string>(
                name: "report_description",
                table: "tprogram",
                nullable: true);
        }
    }
}
