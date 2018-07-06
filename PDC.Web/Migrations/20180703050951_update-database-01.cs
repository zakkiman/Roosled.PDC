using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDC.Web.Migrations
{
    public partial class updatedatabase01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tapplicanttutorial",
                columns: table => new
                {
                    applicant_tutorial_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    applicant_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tapplicanttutorial", x => x.applicant_tutorial_id);
                });

            migrationBuilder.CreateTable(
                name: "tclient",
                columns: table => new
                {
                    client_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address1 = table.Column<string>(nullable: false),
                    address2 = table.Column<string>(nullable: true),
                    client_name = table.Column<string>(nullable: false),
                    contact_email = table.Column<string>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tclient", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "tgroup",
                columns: table => new
                {
                    group_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    add_answer = table.Column<bool>(nullable: false),
                    add_applicant = table.Column<bool>(nullable: false),
                    add_batch = table.Column<bool>(nullable: false),
                    add_city = table.Column<bool>(nullable: false),
                    add_client = table.Column<bool>(nullable: false),
                    add_group = table.Column<bool>(nullable: false),
                    add_menu = table.Column<bool>(nullable: false),
                    add_program = table.Column<bool>(nullable: false),
                    add_province = table.Column<bool>(nullable: false),
                    add_question = table.Column<bool>(nullable: false),
                    add_user = table.Column<bool>(nullable: false),
                    approve_batch = table.Column<bool>(nullable: false),
                    approve_program = table.Column<bool>(nullable: false),
                    approve_question = table.Column<bool>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    delete_answer = table.Column<bool>(nullable: false),
                    delete_applicant = table.Column<bool>(nullable: false),
                    delete_batch = table.Column<bool>(nullable: false),
                    delete_city = table.Column<bool>(nullable: false),
                    delete_client = table.Column<bool>(nullable: false),
                    delete_group = table.Column<bool>(nullable: false),
                    delete_menu = table.Column<bool>(nullable: false),
                    delete_program = table.Column<bool>(nullable: false),
                    delete_province = table.Column<bool>(nullable: false),
                    delete_question = table.Column<bool>(nullable: false),
                    delete_user = table.Column<bool>(nullable: false),
                    edit_answer = table.Column<bool>(nullable: false),
                    edit_applicant = table.Column<bool>(nullable: false),
                    edit_batch = table.Column<bool>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_city = table.Column<bool>(nullable: false),
                    edit_client = table.Column<bool>(nullable: false),
                    edit_date = table.Column<DateTime>(nullable: false),
                    edit_group = table.Column<bool>(nullable: false),
                    edit_menu = table.Column<bool>(nullable: false),
                    edit_program = table.Column<bool>(nullable: false),
                    edit_province = table.Column<bool>(nullable: false),
                    edit_question = table.Column<bool>(nullable: false),
                    edit_user = table.Column<bool>(nullable: false),
                    group_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tgroup", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "tmenu",
                columns: table => new
                {
                    menu_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    is_parent = table.Column<bool>(nullable: false),
                    menu_name = table.Column<string>(nullable: false),
                    parent_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tmenu", x => x.menu_id);
                });

            migrationBuilder.CreateTable(
                name: "tprogram",
                columns: table => new
                {
                    program_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    approval_status = table.Column<string>(nullable: false),
                    approved_by = table.Column<string>(nullable: true),
                    approved_date = table.Column<DateTime>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    program_detail = table.Column<string>(nullable: false),
                    program_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprogram", x => x.program_id);
                });

            migrationBuilder.CreateTable(
                name: "tprovince",
                columns: table => new
                {
                    province_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    province_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprovince", x => x.province_id);
                });

            migrationBuilder.CreateTable(
                name: "tquestion",
                columns: table => new
                {
                    question_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    approval_status = table.Column<string>(nullable: true),
                    approved_by = table.Column<string>(nullable: true),
                    approved_date = table.Column<DateTime>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    question_detail = table.Column<string>(nullable: false),
                    score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tquestion", x => x.question_id);
                });

            migrationBuilder.CreateTable(
                name: "tuser",
                columns: table => new
                {
                    user_id = table.Column<string>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    group_id = table.Column<int>(nullable: true),
                    last_login = table.Column<DateTime>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tuser", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_tuser_tgroup_group_id",
                        column: x => x.group_id,
                        principalTable: "tgroup",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tgroupmenu",
                columns: table => new
                {
                    group_menu_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group_id = table.Column<int>(nullable: true),
                    menu_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tgroupmenu", x => x.group_menu_id);
                    table.ForeignKey(
                        name: "FK_tgroupmenu_tgroup_group_id",
                        column: x => x.group_id,
                        principalTable: "tgroup",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tgroupmenu_tmenu_menu_id",
                        column: x => x.menu_id,
                        principalTable: "tmenu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tcity",
                columns: table => new
                {
                    city_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    city_name = table.Column<string>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    province_id = table.Column<int>(nullable: true),
                    time_area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tcity", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_tcity_tprovince_province_id",
                        column: x => x.province_id,
                        principalTable: "tprovince",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tanswer",
                columns: table => new
                {
                    answer_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    answer_detail = table.Column<string>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    question_id = table.Column<int>(nullable: false),
                    score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tanswer", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_tanswer_tquestion_question_id",
                        column: x => x.question_id,
                        principalTable: "tquestion",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tprogramquestion",
                columns: table => new
                {
                    program_question_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    program_id = table.Column<int>(nullable: true),
                    question_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprogramquestion", x => x.program_question_id);
                    table.ForeignKey(
                        name: "FK_tprogramquestion_tprogram_program_id",
                        column: x => x.program_id,
                        principalTable: "tprogram",
                        principalColumn: "program_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tprogramquestion_tquestion_question_id",
                        column: x => x.question_id,
                        principalTable: "tquestion",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tapplicant",
                columns: table => new
                {
                    applicant_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address1 = table.Column<string>(nullable: false),
                    address2 = table.Column<string>(nullable: true),
                    address3 = table.Column<string>(nullable: true),
                    birth_place = table.Column<string>(nullable: true),
                    city_id = table.Column<int>(nullable: false),
                    client_id = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    dob = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    gender = table.Column<int>(nullable: false),
                    id_number = table.Column<string>(maxLength: 50, nullable: true),
                    last_education = table.Column<string>(maxLength: 10, nullable: true),
                    last_education_location = table.Column<string>(maxLength: 50, nullable: true),
                    last_job = table.Column<string>(maxLength: 50, nullable: true),
                    last_job_location = table.Column<string>(maxLength: 50, nullable: true),
                    last_login = table.Column<DateTime>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    middle_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    position = table.Column<string>(maxLength: 50, nullable: true),
                    position_location = table.Column<string>(maxLength: 50, nullable: true),
                    self_opinion = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tapplicant", x => x.applicant_id);
                    table.ForeignKey(
                        name: "FK_tapplicant_tcity_city_id",
                        column: x => x.city_id,
                        principalTable: "tcity",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tapplicant_tclient_client_id",
                        column: x => x.client_id,
                        principalTable: "tclient",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tapplicanthistory",
                columns: table => new
                {
                    applicant_history_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    applicant_id = table.Column<int>(nullable: false),
                    client_id = table.Column<int>(nullable: false),
                    login_time = table.Column<DateTime>(nullable: false),
                    photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tapplicanthistory", x => x.applicant_history_id);
                    table.ForeignKey(
                        name: "FK_tapplicanthistory_tapplicant_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "tapplicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tapplicanthistory_tclient_client_id",
                        column: x => x.client_id,
                        principalTable: "tclient",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tapplicantprogram",
                columns: table => new
                {
                    applicant_program_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    applicant_id = table.Column<int>(nullable: false),
                    approval_status = table.Column<string>(nullable: true),
                    approved_by = table.Column<string>(nullable: true),
                    approved_date = table.Column<string>(nullable: true),
                    batch_end = table.Column<DateTime>(nullable: false),
                    batch_name = table.Column<string>(nullable: false),
                    batch_start = table.Column<DateTime>(nullable: false),
                    program_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tapplicantprogram", x => x.applicant_program_id);
                    table.ForeignKey(
                        name: "FK_tapplicantprogram_tapplicant_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "tapplicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tapplicantprogram_tprogram_program_id",
                        column: x => x.program_id,
                        principalTable: "tprogram",
                        principalColumn: "program_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tappllicantanswer",
                columns: table => new
                {
                    applicant_answer_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    answer_id = table.Column<int>(nullable: true),
                    applicant_id = table.Column<int>(nullable: true),
                    selected_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tappllicantanswer", x => x.applicant_answer_id);
                    table.ForeignKey(
                        name: "FK_tappllicantanswer_tanswer_answer_id",
                        column: x => x.answer_id,
                        principalTable: "tanswer",
                        principalColumn: "answer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tappllicantanswer_tapplicant_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "tapplicant",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tanswerhistory",
                columns: table => new
                {
                    answer_history_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    answer_id = table.Column<int>(nullable: false),
                    applicant_program_id = table.Column<int>(nullable: true),
                    selected_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tanswerhistory", x => x.answer_history_id);
                    table.ForeignKey(
                        name: "FK_tanswerhistory_tanswer_answer_id",
                        column: x => x.answer_id,
                        principalTable: "tanswer",
                        principalColumn: "answer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tanswerhistory_tapplicantprogram_applicant_program_id",
                        column: x => x.applicant_program_id,
                        principalTable: "tapplicantprogram",
                        principalColumn: "applicant_program_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tanswer_question_id",
                table: "tanswer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_tanswerhistory_answer_id",
                table: "tanswerhistory",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tanswerhistory_applicant_program_id",
                table: "tanswerhistory",
                column: "applicant_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicant_city_id",
                table: "tapplicant",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicant_client_id",
                table: "tapplicant",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicanthistory_applicant_id",
                table: "tapplicanthistory",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicanthistory_client_id",
                table: "tapplicanthistory",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicantprogram_applicant_id",
                table: "tapplicantprogram",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tapplicantprogram_program_id",
                table: "tapplicantprogram",
                column: "program_id");

            migrationBuilder.CreateIndex(
                name: "IX_tappllicantanswer_answer_id",
                table: "tappllicantanswer",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tappllicantanswer_applicant_id",
                table: "tappllicantanswer",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tcity_province_id",
                table: "tcity",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_tgroupmenu_group_id",
                table: "tgroupmenu",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_tgroupmenu_menu_id",
                table: "tgroupmenu",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tprogramquestion_program_id",
                table: "tprogramquestion",
                column: "program_id");

            migrationBuilder.CreateIndex(
                name: "IX_tprogramquestion_question_id",
                table: "tprogramquestion",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_tuser_group_id",
                table: "tuser",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tanswerhistory");

            migrationBuilder.DropTable(
                name: "tapplicanthistory");

            migrationBuilder.DropTable(
                name: "tapplicanttutorial");

            migrationBuilder.DropTable(
                name: "tappllicantanswer");

            migrationBuilder.DropTable(
                name: "tgroupmenu");

            migrationBuilder.DropTable(
                name: "tprogramquestion");

            migrationBuilder.DropTable(
                name: "tuser");

            migrationBuilder.DropTable(
                name: "tapplicantprogram");

            migrationBuilder.DropTable(
                name: "tanswer");

            migrationBuilder.DropTable(
                name: "tmenu");

            migrationBuilder.DropTable(
                name: "tgroup");

            migrationBuilder.DropTable(
                name: "tapplicant");

            migrationBuilder.DropTable(
                name: "tprogram");

            migrationBuilder.DropTable(
                name: "tquestion");

            migrationBuilder.DropTable(
                name: "tcity");

            migrationBuilder.DropTable(
                name: "tclient");

            migrationBuilder.DropTable(
                name: "tprovince");
        }
    }
}
