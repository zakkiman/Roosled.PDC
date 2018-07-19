using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tcity_tprovince_province_id",
                table: "tcity");

            migrationBuilder.DropColumn(
                name: "approval_status",
                table: "tprogram");

            migrationBuilder.DropColumn(
                name: "approved_date",
                table: "tprogram");

            migrationBuilder.RenameColumn(
                name: "approved_by",
                table: "tprogram",
                newName: "report_description");

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "tcity",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tcity_tprovince_province_id",
                table: "tcity",
                column: "province_id",
                principalTable: "tprovince",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tcity_tprovince_province_id",
                table: "tcity");

            migrationBuilder.RenameColumn(
                name: "report_description",
                table: "tprogram",
                newName: "approved_by");

            migrationBuilder.AddColumn<string>(
                name: "approval_status",
                table: "tprogram",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "approved_date",
                table: "tprogram",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "tcity",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tcity_tprovince_province_id",
                table: "tcity",
                column: "province_id",
                principalTable: "tprovince",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
