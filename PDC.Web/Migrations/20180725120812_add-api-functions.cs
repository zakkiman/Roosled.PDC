using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class addapifunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "api_key",
                table: "tclient",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "use_api",
                table: "tclient",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tRequestLog",
                columns: table => new
                {
                    request_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    request_data = table.Column<string>(nullable: false),
                    request_date = table.Column<DateTime>(nullable: false),
                    request_header = table.Column<string>(nullable: false),
                    request_ip = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tRequestLog", x => x.request_id);
                });

            migrationBuilder.CreateTable(
                name: "tResponseLog",
                columns: table => new
                {
                    response_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    request_ip = table.Column<string>(nullable: false),
                    response_data = table.Column<string>(nullable: false),
                    response_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tResponseLog", x => x.response_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tRequestLog");

            migrationBuilder.DropTable(
                name: "tResponseLog");

            migrationBuilder.DropColumn(
                name: "api_key",
                table: "tclient");

            migrationBuilder.DropColumn(
                name: "use_api",
                table: "tclient");
        }
    }
}
