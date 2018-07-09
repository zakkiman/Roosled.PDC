using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class update_database02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tappllicantanswer_tanswer_answer_id",
                table: "tappllicantanswer");

            migrationBuilder.DropForeignKey(
                name: "FK_tappllicantanswer_tapplicant_applicant_id",
                table: "tappllicantanswer");

            migrationBuilder.DropForeignKey(
                name: "FK_tprogramquestion_tprogram_program_id",
                table: "tprogramquestion");

            migrationBuilder.DropForeignKey(
                name: "FK_tprogramquestion_tquestion_question_id",
                table: "tprogramquestion");

            migrationBuilder.AlterColumn<string>(
                name: "edit_by",
                table: "tquestion",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "create_by",
                table: "tquestion",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "approved_by",
                table: "tquestion",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "approval_status",
                table: "tquestion",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "domain_id",
                table: "tquestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "domain_id1",
                table: "tquestion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "tquestion",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "question_id",
                table: "tprogramquestion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "program_id",
                table: "tprogramquestion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "applicant_id",
                table: "tappllicantanswer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                table: "tappllicantanswer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tdomain",
                columns: table => new
                {
                    domain_id = table.Column<string>(nullable: false),
                    create_by = table.Column<string>(maxLength: 50, nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    domain_name = table.Column<string>(maxLength: 50, nullable: false),
                    edit_by = table.Column<string>(maxLength: 50, nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdomain", x => x.domain_id);
                });

            migrationBuilder.CreateTable(
                name: "ttype",
                columns: table => new
                {
                    type_name = table.Column<string>(maxLength: 50, nullable: false),
                    create_by = table.Column<string>(maxLength: 50, nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(maxLength: 50, nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    type_alias = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttype", x => x.type_name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tquestion_domain_id1",
                table: "tquestion",
                column: "domain_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tquestion_type_name",
                table: "tquestion",
                column: "type_name");

            migrationBuilder.AddForeignKey(
                name: "FK_tappllicantanswer_tanswer_answer_id",
                table: "tappllicantanswer",
                column: "answer_id",
                principalTable: "tanswer",
                principalColumn: "answer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tappllicantanswer_tapplicant_applicant_id",
                table: "tappllicantanswer",
                column: "applicant_id",
                principalTable: "tapplicant",
                principalColumn: "applicant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tprogramquestion_tprogram_program_id",
                table: "tprogramquestion",
                column: "program_id",
                principalTable: "tprogram",
                principalColumn: "program_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tprogramquestion_tquestion_question_id",
                table: "tprogramquestion",
                column: "question_id",
                principalTable: "tquestion",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tquestion_tdomain_domain_id1",
                table: "tquestion",
                column: "domain_id1",
                principalTable: "tdomain",
                principalColumn: "domain_id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_tappllicantanswer_tanswer_answer_id",
                table: "tappllicantanswer");

            migrationBuilder.DropForeignKey(
                name: "FK_tappllicantanswer_tapplicant_applicant_id",
                table: "tappllicantanswer");

            migrationBuilder.DropForeignKey(
                name: "FK_tprogramquestion_tprogram_program_id",
                table: "tprogramquestion");

            migrationBuilder.DropForeignKey(
                name: "FK_tprogramquestion_tquestion_question_id",
                table: "tprogramquestion");

            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_tdomain_domain_id1",
                table: "tquestion");

            migrationBuilder.DropForeignKey(
                name: "FK_tquestion_ttype_type_name",
                table: "tquestion");

            migrationBuilder.DropTable(
                name: "tdomain");

            migrationBuilder.DropTable(
                name: "ttype");

            migrationBuilder.DropIndex(
                name: "IX_tquestion_domain_id1",
                table: "tquestion");

            migrationBuilder.DropIndex(
                name: "IX_tquestion_type_name",
                table: "tquestion");

            migrationBuilder.DropColumn(
                name: "domain_id",
                table: "tquestion");

            migrationBuilder.DropColumn(
                name: "domain_id1",
                table: "tquestion");

            migrationBuilder.DropColumn(
                name: "type_name",
                table: "tquestion");

            migrationBuilder.AlterColumn<string>(
                name: "edit_by",
                table: "tquestion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "create_by",
                table: "tquestion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "approved_by",
                table: "tquestion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "approval_status",
                table: "tquestion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "question_id",
                table: "tprogramquestion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "program_id",
                table: "tprogramquestion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "applicant_id",
                table: "tappllicantanswer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                table: "tappllicantanswer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tappllicantanswer_tanswer_answer_id",
                table: "tappllicantanswer",
                column: "answer_id",
                principalTable: "tanswer",
                principalColumn: "answer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tappllicantanswer_tapplicant_applicant_id",
                table: "tappllicantanswer",
                column: "applicant_id",
                principalTable: "tapplicant",
                principalColumn: "applicant_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tprogramquestion_tprogram_program_id",
                table: "tprogramquestion",
                column: "program_id",
                principalTable: "tprogram",
                principalColumn: "program_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tprogramquestion_tquestion_question_id",
                table: "tprogramquestion",
                column: "question_id",
                principalTable: "tquestion",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
