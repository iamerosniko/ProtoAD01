﻿// <auto-generated />
using ABADiversityAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ABADiversityAPI.Migrations
{
    [DbContext(typeof(ABAContext))]
    [Migration("20180130115729_m004")]
    partial class m004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABADiversityAPI.Entities.CompanyProfiles", b =>
                {
                    b.Property<int>("CompanyProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CertifyingEntityName");

                    b.Property<DateTime>("CompletionDate");

                    b.Property<string>("FirmHead");

                    b.Property<string>("FirmName");

                    b.Property<bool>("IsFirmCertified");

                    b.Property<bool>("IsFirmWomenOwned");

                    b.Property<string>("OwnershipCategory");

                    b.Property<int>("SizeCategoryID");

                    b.Property<string>("SurveyContactEmail");

                    b.Property<string>("SurveyContactPerson");

                    b.Property<string>("SurveyContactTitle");

                    b.Property<int>("TotalLawyers");

                    b.Property<int>("TotalUSLawyers");

                    b.Property<int>("Year");

                    b.HasKey("CompanyProfileID");

                    b.ToTable("ABA_CompanyProfiles");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.FirmDemographics", b =>
                {
                    b.Property<int>("FIrmDemographicsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Race");

                    b.Property<int>("Value");

                    b.Property<string>("Varchar");

                    b.Property<int>("Year");

                    b.HasKey("FIrmDemographicsID");

                    b.ToTable("ABA_FirmDemographics");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.FirmInitiatives", b =>
                {
                    b.Property<int>("FirmInitiativeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<bool>("IfYes");

                    b.Property<int>("InitiativeQuestionID");

                    b.Property<int>("Year");

                    b.HasKey("FirmInitiativeID");

                    b.ToTable("ABA_FirmInitiatives");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.FirmLeaderships", b =>
                {
                    b.Property<int>("FirmLeadershipID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("GenderRace");

                    b.Property<int>("Value");

                    b.Property<int>("Year");

                    b.HasKey("FirmLeadershipID");

                    b.ToTable("ABA_FirmLeaderships");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.HighCompensatedPartners", b =>
                {
                    b.Property<int>("HighCompensatedPartnerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender");

                    b.Property<string>("Role");

                    b.Property<int>("Value");

                    b.Property<int>("Year");

                    b.HasKey("HighCompensatedPartnerID");

                    b.ToTable("ABA_HighCompensatedPartners");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.InitiativeQuestions", b =>
                {
                    b.Property<int>("InitiativeQuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestionDesc");

                    b.HasKey("InitiativeQuestionID");

                    b.ToTable("ABA_InitiativeQuestions");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.JoinedLawyers", b =>
                {
                    b.Property<int>("JoinedLawyerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Race");

                    b.Property<string>("Role");

                    b.Property<int>("Value");

                    b.Property<int>("Year");

                    b.HasKey("JoinedLawyerID");

                    b.ToTable("ABA_JoinedLawyers");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.LeftLawyers", b =>
                {
                    b.Property<int>("LeftLawyerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender");

                    b.Property<string>("Races");

                    b.Property<int>("Value");

                    b.Property<int>("Year");

                    b.HasKey("LeftLawyerID");

                    b.ToTable("ABA_LeftLawyers");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.SetGroup", b =>
                {
                    b.Property<string>("grp_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<DateTime>("created_date");

                    b.Property<string>("grp_desc")
                        .HasMaxLength(255);

                    b.Property<string>("grp_name")
                        .HasMaxLength(50);

                    b.HasKey("grp_id");

                    b.ToTable("set_group");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.SetUser", b =>
                {
                    b.Property<string>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<bool>("can_DEV");

                    b.Property<bool>("can_PEER");

                    b.Property<bool>("can_PROD");

                    b.Property<bool>("can_UAT");

                    b.Property<DateTime>("created_date");

                    b.Property<string>("user_first_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_last_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_middle_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_name")
                        .HasMaxLength(25);

                    b.HasKey("user_id");

                    b.ToTable("set_user");
                });

            modelBuilder.Entity("ABADiversityAPI.Entities.SetUserAccess", b =>
                {
                    b.Property<int>("user_grp_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("grp_id")
                        .HasMaxLength(25);

                    b.Property<string>("user_id")
                        .HasMaxLength(25);

                    b.HasKey("user_grp_id");

                    b.ToTable("set_user_access");
                });
#pragma warning restore 612, 618
        }
    }
}
