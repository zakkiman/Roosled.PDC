using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approval_status",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "approved_by",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "approved_date",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "batch_end",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "batch_name",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "batch_start",
                table: "tapplicantprogram");

            migrationBuilder.AddColumn<int>(
                name: "batch_id",
                table: "tapplicantprogram",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbatch",
                columns: table => new
                {
                    batch_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    approval_status = table.Column<string>(maxLength: 20, nullable: true),
                    approved_by = table.Column<string>(maxLength: 50, nullable: true),
                    approved_date = table.Column<string>(nullable: true),
                    batch_end = table.Column<DateTime>(nullable: false),
                    batch_name = table.Column<string>(maxLength: 50, nullable: false),
                    batch_start = table.Column<DateTime>(nullable: false),
                    client_id = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(maxLength: 50, nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(maxLength: 50, nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbatch", x => x.batch_id);
                    table.ForeignKey(
                        name: "FK_tbatch_tclient_client_id",
                        column: x => x.client_id,
                        principalTable: "tclient",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tapplicantprogram_batch_id",
                table: "tapplicantprogram",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbatch_client_id",
                table: "tbatch",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tapplicantprogram_tbatch_batch_id",
                table: "tapplicantprogram",
                column: "batch_id",
                principalTable: "tbatch",
                principalColumn: "batch_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tapplicantprogram_tbatch_batch_id",
                table: "tapplicantprogram");

            migrationBuilder.DropTable(
                name: "tbatch");

            migrationBuilder.DropIndex(
                name: "IX_tapplicantprogram_batch_id",
                table: "tapplicantprogram");

            migrationBuilder.DropColumn(
                name: "batch_id",
                table: "tapplicantprogram");

            migrationBuilder.AddColumn<string>(
                name: "approval_status",
                table: "tapplicantprogram",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approved_by",
                table: "tapplicantprogram",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "approved_date",
                table: "tapplicantprogram",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "batch_end",
                table: "tapplicantprogram",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "batch_name",
                table: "tapplicantprogram",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "batch_start",
                table: "tapplicantprogram",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
