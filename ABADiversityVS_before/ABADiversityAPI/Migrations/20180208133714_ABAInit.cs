using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class ABAInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABA_CompanyProfiles",
                columns: table => new
                {
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    CertifyingEntityName = table.Column<string>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    FirmHead = table.Column<string>(nullable: true),
                    FirmName = table.Column<string>(nullable: true),
                    IsFirmCertified = table.Column<bool>(nullable: false),
                    IsFirmWomenOwned = table.Column<bool>(nullable: false),
                    OwnershipCategory = table.Column<string>(nullable: true),
                    SizeCategoryID = table.Column<int>(nullable: false),
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
                    Associates = table.Column<int>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Counsels = table.Column<int>(nullable: false),
                    EquityPartners = table.Column<int>(nullable: false),
                    NonEquityPartners = table.Column<int>(nullable: false),
                    OtherLawyers = table.Column<int>(nullable: false),
                    Race = table.Column<string>(nullable: true)
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
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    IfYes = table.Column<bool>(nullable: false),
                    InitiativeQuestionID = table.Column<int>(nullable: false)
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
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Disabled = table.Column<int>(nullable: false),
                    LGBT = table.Column<int>(nullable: false),
                    MinorityFemale = table.Column<int>(nullable: false),
                    MinorityMale = table.Column<int>(nullable: false),
                    WhiteFemale = table.Column<int>(nullable: false),
                    WhiteMale = table.Column<int>(nullable: false)
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
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Men = table.Column<int>(nullable: false),
                    Race = table.Column<string>(nullable: true),
                    Women = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_HighCompensatedPartners", x => x.HighCompensatedPartnerID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_HomegrownPartners",
                columns: table => new
                {
                    HomegrownPartnersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Disabled = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LGBT = table.Column<int>(nullable: false),
                    Minority = table.Column<int>(nullable: false),
                    White = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_HomegrownPartners", x => x.HomegrownPartnersID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_HoursReducedLawyers",
                columns: table => new
                {
                    HoursReducedLawyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Associates = table.Column<int>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Counsels = table.Column<int>(nullable: false),
                    EquityPartners = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    NonEquityPartners = table.Column<int>(nullable: false),
                    OtherLawyers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_HoursReducedLawyers", x => x.HoursReducedLawyerID);
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
                    Associates = table.Column<int>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Counsels = table.Column<int>(nullable: false),
                    EquityPartners = table.Column<int>(nullable: false),
                    NonEquityPartners = table.Column<int>(nullable: false),
                    OtherLawyers = table.Column<int>(nullable: false),
                    Races = table.Column<string>(nullable: true)
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
                    Associates = table.Column<int>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Counsels = table.Column<int>(nullable: false),
                    EquityPartners = table.Column<int>(nullable: false),
                    NonEquityPartners = table.Column<int>(nullable: false),
                    OtherLawyers = table.Column<int>(nullable: false),
                    Races = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_LeftLawyers", x => x.LeftLawyerID);
                });

            migrationBuilder.CreateTable(
                name: "ABA_SizeCategory",
                columns: table => new
                {
                    SizeCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SizeCategoryDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_SizeCategory", x => x.SizeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "set_group",
                columns: table => new
                {
                    grp_id = table.Column<string>(maxLength: 25, nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    grp_desc = table.Column<string>(maxLength: 255, nullable: true),
                    grp_name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set_group", x => x.grp_id);
                });

            migrationBuilder.CreateTable(
                name: "set_user",
                columns: table => new
                {
                    user_id = table.Column<string>(maxLength: 25, nullable: false),
                    can_DEV = table.Column<bool>(nullable: false),
                    can_PEER = table.Column<bool>(nullable: false),
                    can_PROD = table.Column<bool>(nullable: false),
                    can_UAT = table.Column<bool>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    user_first_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_last_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_middle_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "set_user_access",
                columns: table => new
                {
                    user_grp_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    grp_id = table.Column<string>(maxLength: 25, nullable: true),
                    user_id = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set_user_access", x => x.user_grp_id);
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
                name: "ABA_HomegrownPartners");

            migrationBuilder.DropTable(
                name: "ABA_HoursReducedLawyers");

            migrationBuilder.DropTable(
                name: "ABA_InitiativeQuestions");

            migrationBuilder.DropTable(
                name: "ABA_JoinedLawyers");

            migrationBuilder.DropTable(
                name: "ABA_LeftLawyers");

            migrationBuilder.DropTable(
                name: "ABA_SizeCategory");

            migrationBuilder.DropTable(
                name: "set_group");

            migrationBuilder.DropTable(
                name: "set_user");

            migrationBuilder.DropTable(
                name: "set_user_access");
        }
    }
}
