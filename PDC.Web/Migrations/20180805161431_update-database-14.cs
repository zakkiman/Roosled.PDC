using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isExpired",
                table: "tbatch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tconfiguration",
                columns: table => new
                {
                    config_name = table.Column<string>(maxLength: 50, nullable: false),
                    email_address = table.Column<string>(maxLength: 150, nullable: false),
                    email_name = table.Column<string>(maxLength: 150, nullable: false),
                    email_tempate = table.Column<string>(nullable: false),
                    is_secure = table.Column<bool>(nullable: false),
                    smtp_host = table.Column<string>(maxLength: 150, nullable: false),
                    smtp_port = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tconfiguration", x => x.config_name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isExpired",
                table: "tbatch");

            migrationBuilder.DropColumn(
                name: "notes",
                table: "tapplicant");
        }
    }
}
