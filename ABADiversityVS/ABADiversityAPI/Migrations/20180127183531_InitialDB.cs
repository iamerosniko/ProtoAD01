using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABA_CompanyProfiles",
                columns: table => new
                {
                    CompanyProfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertifyingEntityName = table.Column<string>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    FirmHead = table.Column<string>(nullable: true),
                    FirmName = table.Column<string>(nullable: true),
                    IsFirmCertified = table.Column<bool>(nullable: false),
                    IsFirmWomenOwned = table.Column<bool>(nullable: false),
                    OwnershipCategory = table.Column<string>(nullable: true),
                    SizeCategory = table.Column<int>(nullable: false),
                    SurveyContactEmail = table.Column<string>(nullable: true),
                    SurveyContactPerson = table.Column<string>(nullable: true),
                    SurveyContactTitle = table.Column<string>(nullable: true),
                    TotalLawyers = table.Column<int>(nullable: false),
                    TotalUSLawyers = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_CompanyProfiles", x => x.CompanyProfileID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_FirmDemographics",
                columns: table => new
                {
                    FIrmDemographicsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Race = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Varchar = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_FirmDemographics", x => x.FIrmDemographicsID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_FirmInitiatives",
                columns: table => new
                {
                    FirmInitiativeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    IfYes = table.Column<bool>(nullable: false),
                    InitiativeQuestionID = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_FirmInitiatives", x => x.FirmInitiativeID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_FirmLeaderships",
                columns: table => new
                {
                    FirmLeadershipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    GenderRace = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_FirmLeaderships", x => x.FirmLeadershipID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_HighCompensatedPartners",
                columns: table => new
                {
                    HighCompensatedPartnerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_HighCompensatedPartners", x => x.HighCompensatedPartnerID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_InitiativeQuestions",
                columns: table => new
                {
                    InitiativeQuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_InitiativeQuestions", x => x.InitiativeQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_JoinedLawyers",
                columns: table => new
                {
                    JoinedLawyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Race = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_JoinedLawyers", x => x.JoinedLawyerID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_LeftLawyers",
                columns: table => new
                {
                    LeftLawyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    Races = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_LeftLawyers", x => x.LeftLawyerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABA_CompanyProfiles");

            migrationBuilder.DropTable(
                name: "ABA_FirmDemographics");

            migrationBuilder.DropTable(
                name: "ABA_FirmInitiatives");

            migrationBuilder.DropTable(
                name: "ABA_FirmLeaderships");

            migrationBuilder.DropTable(
                name: "ABA_HighCompensatedPartners");

            migrationBuilder.DropTable(
                name: "ABA_InitiativeQuestions");

            migrationBuilder.DropTable(
                name: "ABA_JoinedLawyers");

            migrationBuilder.DropTable(
                name: "ABA_LeftLawyers");
        }
    }
}
