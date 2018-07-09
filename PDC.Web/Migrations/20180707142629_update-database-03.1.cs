using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion");

            migrationBuilder.AlterColumn<string>(
                name: "type_name",
                table: "tquestion",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion",
                column: "type_name",
                principalTable: "ttype",
                principalColumn: "type_name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion");

            migrationBuilder.AlterColumn<string>(
                name: "type_name",
                table: "tquestion",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion",
                column: "type_name",
                principalTable: "ttype",
                principalColumn: "type_name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
