using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.AddForeignKey(
                name: "FK_tquestion_tdomain_domain_id",
                table: "tquestion",
                column: "domain_id",
                principalTable: "tdomain",
                principalColumn: "domain_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion",
                column: "type_name",
                principalTable: "ttype",
                principalColumn: "type_name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_tdomain_domain_id",
                table: "tquestion");

            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion");

            migrationBuilder.DropIndex(
                name: "IX_tquestion_domain_id",
                table: "tquestion");

            migrationBuilder.DropIndex(
                name: "IX_tquestion_type_name",
                table: "tquestion");
        }
    }
}
