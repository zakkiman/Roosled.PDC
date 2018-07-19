﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PDC.Web.Models;
using System;

namespace PDC.Web.Migrations
{
    [DbContext(typeof(PDCContext))]
    partial class PDCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("PDC.Web.Models.tAnswer", b =>
                {
                    b.Property<int>("answer_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("answer_detail")
                        .IsRequired();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<int>("question_id");

                    b.Property<int>("score");

                    b.HasKey("answer_id");

                    b.HasIndex("question_id");

                    b.ToTable("tanswer");
                });

            modelBuilder.Entity("PDC.Web.Models.tAnswerHistory", b =>
                {
                    b.Property<int>("answer_history_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("answer_id");

                    b.Property<int>("applicant_program_id");

                    b.Property<DateTime>("selected_time");

                    b.HasKey("answer_history_id");

                    b.HasIndex("answer_id");

                    b.HasIndex("applicant_program_id");

                    b.ToTable("tanswerhistory");
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicant", b =>
                {
                    b.Property<int>("applicant_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address1")
                        .IsRequired();

                    b.Property<string>("address2");

                    b.Property<string>("address3");

                    b.Property<string>("birth_place");

                    b.Property<int>("city_id");

                    b.Property<int>("client_id");

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<DateTime>("dob");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("first_name")
                        .IsRequired();

                    b.Property<int>("gender");

                    b.Property<string>("id_number")
                        .HasMaxLength(50);

                    b.Property<string>("last_education")
                        .HasMaxLength(10);

                    b.Property<string>("last_education_location")
                        .HasMaxLength(50);

                    b.Property<string>("last_job")
                        .HasMaxLength(50);

                    b.Property<string>("last_job_location")
                        .HasMaxLength(50);

                    b.Property<DateTime>("last_login");

                    b.Property<string>("last_name")
                        .IsRequired();

                    b.Property<string>("middle_name");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<string>("position")
                        .HasMaxLength(50);

                    b.Property<string>("position_location")
                        .HasMaxLength(50);

                    b.Property<string>("self_opinion");

                    b.Property<string>("status");

                    b.HasKey("applicant_id");

                    b.HasIndex("city_id");

                    b.HasIndex("client_id");

                    b.ToTable("tapplicant");
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicantHistory", b =>
                {
                    b.Property<int>("applicant_history_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("applicant_id");

                    b.Property<int>("client_id");

                    b.Property<DateTime>("login_time");

                    b.Property<string>("photo");

                    b.HasKey("applicant_history_id");

                    b.HasIndex("applicant_id");

                    b.HasIndex("client_id");

                    b.ToTable("tapplicanthistory");
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicantProgram", b =>
                {
                    b.Property<int>("applicant_program_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("applicant_id");

                    b.Property<int>("batch_id");

                    b.Property<int>("program_id");

                    b.Property<string>("report_description");

                    b.HasKey("applicant_program_id");

                    b.HasIndex("applicant_id");

                    b.HasIndex("batch_id");

                    b.HasIndex("program_id");

                    b.ToTable("tapplicantprogram");
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicantTutorial", b =>
                {
                    b.Property<int>("applicant_tutorial_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("applicant_id");

                    b.Property<DateTime>("date");

                    b.Property<byte>("status");

                    b.HasKey("applicant_tutorial_id");

                    b.ToTable("tapplicanttutorial");
                });

            modelBuilder.Entity("PDC.Web.Models.tAppllicantAnswer", b =>
                {
                    b.Property<int>("applicant_answer_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("answer_id");

                    b.Property<int>("applicant_id");

                    b.Property<int>("applicant_program_id");

                    b.Property<DateTime>("selected_time");

                    b.HasKey("applicant_answer_id");

                    b.HasIndex("answer_id");

                    b.HasIndex("applicant_id");

                    b.HasIndex("applicant_program_id");

                    b.ToTable("tappllicantanswer");
                });

            modelBuilder.Entity("PDC.Web.Models.tBatch", b =>
                {
                    b.Property<int>("batch_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("approval_status")
                        .HasMaxLength(20);

                    b.Property<string>("approved_by")
                        .HasMaxLength(50);

                    b.Property<string>("approved_date");

                    b.Property<DateTime>("batch_end");

                    b.Property<string>("batch_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("batch_start");

                    b.Property<int>("client_id");

                    b.Property<string>("create_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("edit_date");

                    b.HasKey("batch_id");

                    b.HasIndex("client_id");

                    b.ToTable("tbatch");
                });

            modelBuilder.Entity("PDC.Web.Models.tCity", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("city_name")
                        .IsRequired();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<int>("province_id");

                    b.Property<int>("time_area");

                    b.HasKey("city_id");

                    b.HasIndex("province_id");

                    b.ToTable("tcity");
                });

            modelBuilder.Entity("PDC.Web.Models.tClient", b =>
                {
                    b.Property<int>("client_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address1")
                        .IsRequired();

                    b.Property<string>("address2");

                    b.Property<string>("client_name")
                        .IsRequired();

                    b.Property<string>("contact_email")
                        .IsRequired();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<bool>("use_alias");

                    b.HasKey("client_id");

                    b.ToTable("tclient");
                });

            modelBuilder.Entity("PDC.Web.Models.tDomain", b =>
                {
                    b.Property<int>("domain_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("create_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("create_date");

                    b.Property<string>("domain_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("edit_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("edit_date");

                    b.HasKey("domain_id");

                    b.ToTable("tdomain");
                });

            modelBuilder.Entity("PDC.Web.Models.tGroup", b =>
                {
                    b.Property<int>("group_id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("add_answer");

                    b.Property<bool>("add_applicant");

                    b.Property<bool>("add_batch");

                    b.Property<bool>("add_city");

                    b.Property<bool>("add_client");

                    b.Property<bool>("add_group");

                    b.Property<bool>("add_menu");

                    b.Property<bool>("add_program");

                    b.Property<bool>("add_province");

                    b.Property<bool>("add_question");

                    b.Property<bool>("add_user");

                    b.Property<bool>("approve_batch");

                    b.Property<bool>("approve_program");

                    b.Property<bool>("approve_question");

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<bool>("delete_answer");

                    b.Property<bool>("delete_applicant");

                    b.Property<bool>("delete_batch");

                    b.Property<bool>("delete_city");

                    b.Property<bool>("delete_client");

                    b.Property<bool>("delete_group");

                    b.Property<bool>("delete_menu");

                    b.Property<bool>("delete_program");

                    b.Property<bool>("delete_province");

                    b.Property<bool>("delete_question");

                    b.Property<bool>("delete_user");

                    b.Property<bool>("edit_answer");

                    b.Property<bool>("edit_applicant");

                    b.Property<bool>("edit_batch");

                    b.Property<string>("edit_by");

                    b.Property<bool>("edit_city");

                    b.Property<bool>("edit_client");

                    b.Property<DateTime>("edit_date");

                    b.Property<bool>("edit_group");

                    b.Property<bool>("edit_menu");

                    b.Property<bool>("edit_program");

                    b.Property<bool>("edit_province");

                    b.Property<bool>("edit_question");

                    b.Property<bool>("edit_user");

                    b.Property<string>("group_name")
                        .IsRequired();

                    b.HasKey("group_id");

                    b.ToTable("tgroup");
                });

            modelBuilder.Entity("PDC.Web.Models.tGroupMenu", b =>
                {
                    b.Property<int>("group_menu_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("group_id");

                    b.Property<int?>("menu_id");

                    b.HasKey("group_menu_id");

                    b.HasIndex("group_id");

                    b.HasIndex("menu_id");

                    b.ToTable("tgroupmenu");
                });

            modelBuilder.Entity("PDC.Web.Models.tMenu", b =>
                {
                    b.Property<int>("menu_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<bool>("is_parent");

                    b.Property<string>("menu_name")
                        .IsRequired();

                    b.Property<int>("parent_id");

                    b.HasKey("menu_id");

                    b.ToTable("tmenu");
                });

            modelBuilder.Entity("PDC.Web.Models.tProgram", b =>
                {
                    b.Property<int>("program_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<int>("duration");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("program_detail")
                        .IsRequired();

                    b.Property<string>("program_name")
                        .IsRequired();

                    b.HasKey("program_id");

                    b.ToTable("tprogram");
                });

            modelBuilder.Entity("PDC.Web.Models.tProgramQuestion", b =>
                {
                    b.Property<int>("program_question_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("program_id");

                    b.Property<int>("question_id");

                    b.HasKey("program_question_id");

                    b.HasIndex("program_id");

                    b.HasIndex("question_id");

                    b.ToTable("tprogramquestion");
                });

            modelBuilder.Entity("PDC.Web.Models.tProvince", b =>
                {
                    b.Property<int>("province_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("province_name")
                        .IsRequired();

                    b.HasKey("province_id");

                    b.ToTable("tprovince");
                });

            modelBuilder.Entity("PDC.Web.Models.tQuestion", b =>
                {
                    b.Property<int>("question_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("approval_status")
                        .HasMaxLength(20);

                    b.Property<string>("approved_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("approved_date");

                    b.Property<string>("create_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("create_date");

                    b.Property<int>("domain_id");

                    b.Property<string>("edit_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("edit_date");

                    b.Property<bool?>("isBorderline");

                    b.Property<string>("question_detail")
                        .IsRequired();

                    b.Property<int>("score");

                    b.Property<string>("type_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("question_id");

                    b.HasIndex("domain_id");

                    b.HasIndex("type_name");

                    b.ToTable("tquestion");
                });

            modelBuilder.Entity("PDC.Web.Models.tType", b =>
                {
                    b.Property<string>("type_name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<bool>("auto_display");

                    b.Property<string>("create_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("create_date");

                    b.Property<bool>("display");

                    b.Property<decimal>("divider");

                    b.Property<string>("edit_by")
                        .HasMaxLength(50);

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("pain_pleasure")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("passive_active")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("self_other")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("substractor");

                    b.Property<string>("type_alias")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("type_name");

                    b.ToTable("ttype");
                });

            modelBuilder.Entity("PDC.Web.Models.tUser", b =>
                {
                    b.Property<string>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("create_by");

                    b.Property<DateTime>("create_date");

                    b.Property<string>("edit_by");

                    b.Property<DateTime>("edit_date");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("first_name")
                        .IsRequired();

                    b.Property<int?>("group_id");

                    b.Property<DateTime>("last_login");

                    b.Property<string>("last_name")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.HasKey("user_id");

                    b.HasIndex("group_id");

                    b.ToTable("tuser");
                });

            modelBuilder.Entity("PDC.Web.Models.tAnswer", b =>
                {
                    b.HasOne("PDC.Web.Models.tQuestion", "question")
                        .WithMany("answers")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tAnswerHistory", b =>
                {
                    b.HasOne("PDC.Web.Models.tAnswer", "answer")
                        .WithMany()
                        .HasForeignKey("answer_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tApplicantProgram", "applicant_program")
                        .WithMany()
                        .HasForeignKey("applicant_program_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicant", b =>
                {
                    b.HasOne("PDC.Web.Models.tCity", "city")
                        .WithMany()
                        .HasForeignKey("city_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tClient", "client")
                        .WithMany()
                        .HasForeignKey("client_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicantHistory", b =>
                {
                    b.HasOne("PDC.Web.Models.tApplicant", "applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tClient", "client")
                        .WithMany()
                        .HasForeignKey("client_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tApplicantProgram", b =>
                {
                    b.HasOne("PDC.Web.Models.tApplicant", "applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tBatch", "batch")
                        .WithMany("applicantPrograms")
                        .HasForeignKey("batch_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tProgram", "program")
                        .WithMany()
                        .HasForeignKey("program_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tAppllicantAnswer", b =>
                {
                    b.HasOne("PDC.Web.Models.tAnswer", "answer")
                        .WithMany()
                        .HasForeignKey("answer_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tApplicant", "applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tApplicantProgram", "applicant_program")
                        .WithMany()
                        .HasForeignKey("applicant_program_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tBatch", b =>
                {
                    b.HasOne("PDC.Web.Models.tClient", "client")
                        .WithMany()
                        .HasForeignKey("client_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tCity", b =>
                {
                    b.HasOne("PDC.Web.Models.tProvince", "province")
                        .WithMany()
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tGroupMenu", b =>
                {
                    b.HasOne("PDC.Web.Models.tGroup", "group")
                        .WithMany()
                        .HasForeignKey("group_id");

                    b.HasOne("PDC.Web.Models.tMenu", "menu")
                        .WithMany()
                        .HasForeignKey("menu_id");
                });

            modelBuilder.Entity("PDC.Web.Models.tProgramQuestion", b =>
                {
                    b.HasOne("PDC.Web.Models.tProgram", "program")
                        .WithMany()
                        .HasForeignKey("program_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tQuestion", "question")
                        .WithMany()
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tQuestion", b =>
                {
                    b.HasOne("PDC.Web.Models.tDomain", "domain")
                        .WithMany()
                        .HasForeignKey("domain_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDC.Web.Models.tType", "type")
                        .WithMany()
                        .HasForeignKey("type_name")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDC.Web.Models.tUser", b =>
                {
                    b.HasOne("PDC.Web.Models.tGroup", "group")
                        .WithMany()
                        .HasForeignKey("group_id");
                });
#pragma warning restore 612, 618
        }
    }
}
