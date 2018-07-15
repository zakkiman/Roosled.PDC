using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<int>(
                name: "applicant_program_id",
                table: "tanswerhistory",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tanswerhistory_tapplicantprogram_applicant_program_id",
                table: "tanswerhistory",
                column: "applicant_program_id",
                principalTable: "tapplicantprogram",
                principalColumn: "applicant_program_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tappllicantanswer_tapplicantprogram_applicant_program_id",
                table: "tappllicantanswer",
                column: "applicant_program_id",
                principalTable: "tapplicantprogram",
                principalColumn: "applicant_program_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tanswerhistory_tapplicantprogram_applicant_program_id",
                table: "tanswerhistory");

            migrationBuilder.DropForeignKey(
                name: "FK_tappllicantanswer_tapplicantprogram_applicant_program_id",
                table: "tappllicantanswer");

            migrationBuilder.DropIndex(
                name: "IX_tappllicantanswer_applicant_program_id",
                table: "tappllicantanswer");

            migrationBuilder.DropColumn(
                name: "applicant_program_id",
                table: "tappllicantanswer");

            migrationBuilder.AlterColumn<int>(
                name: "applicant_program_id",
                table: "tanswerhistory",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tanswerhistory_tapplicantprogram_applicant_program_id",
                table: "tanswerhistory",
                column: "applicant_program_id",
                principalTable: "tapplicantprogram",
                principalColumn: "applicant_program_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
