using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class initialtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AD_Certificates",
                columns: table => new
                {
                    CertificateID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    DateCert = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_Certificates", x => x.CertificateID);
                });

            migrationBuilder.CreateTable(
                name: "AD_CompanyProfiles",
                columns: table => new
                {
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    Catown = table.Column<string>(nullable: true),
                    Datecomp = table.Column<DateTime>(nullable: false),
                    Firmcert = table.Column<string>(nullable: true),
                    Firmhead = table.Column<string>(nullable: true),
                    Firmname = table.Column<string>(nullable: true),
                    Firmown = table.Column<string>(nullable: true),
                    Sizecat = table.Column<int>(nullable: false),
                    Srcemail = table.Column<string>(nullable: true),
                    Srcname = table.Column<string>(nullable: true),
                    Srctitle = table.Column<string>(nullable: true),
                    Totalfw = table.Column<int>(nullable: false),
                    Totalusfw = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_CompanyProfiles", x => x.CompanyProfileID);
                });

            migrationBuilder.CreateTable(
                name: "AD_FirmDemographics",
                columns: table => new
                {
                    FirmDemographicID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_FirmDemographics", x => x.FirmDemographicID);
                });

            migrationBuilder.CreateTable(
                name: "AD_Firms",
                columns: table => new
                {
                    FirmID = table.Column<Guid>(nullable: false),
                    FirmName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_Firms", x => x.FirmID);
                });

            migrationBuilder.CreateTable(
                name: "AD_JoinedLawyers",
                columns: table => new
                {
                    JoinedLawyerID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_JoinedLawyers", x => x.JoinedLawyerID);
                });

            migrationBuilder.CreateTable(
                name: "AD_LeadershipDemographics",
                columns: table => new
                {
                    LeadershipDemographicID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_LeadershipDemographics", x => x.LeadershipDemographicID);
                });

            migrationBuilder.CreateTable(
                name: "AD_LeftLawyers",
                columns: table => new
                {
                    LeftLawyerID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_LeftLawyers", x => x.LeftLawyerID);
                });

            migrationBuilder.CreateTable(
                name: "AD_PromotionsAssociatePartners",
                columns: table => new
                {
                    PromotionsAssociatePartnerID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_PromotionsAssociatePartners", x => x.PromotionsAssociatePartnerID);
                });

            migrationBuilder.CreateTable(
                name: "AD_ReducedHoursLawyers",
                columns: table => new
                {
                    ReducedHoursLawyerID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_ReducedHoursLawyers", x => x.ReducedHoursLawyerID);
                });

            migrationBuilder.CreateTable(
                name: "AD_TopTenHighestCompensations",
                columns: table => new
                {
                    TopTenHighestCompensationID = table.Column<Guid>(nullable: false),
                    CompanyProfileID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_TopTenHighestCompensations", x => x.TopTenHighestCompensationID);
                });

            migrationBuilder.CreateTable(
                name: "AD_UntertakenInitiatives",
                columns: table => new
                {
                    UndertakenInitiativeID = table.Column<Guid>(nullable: false),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer10 = table.Column<string>(nullable: true),
                    Answer11 = table.Column<string>(nullable: true),
                    Answer12 = table.Column<string>(nullable: true),
                    Answer13 = table.Column<string>(nullable: true),
                    Answer14 = table.Column<string>(nullable: true),
                    Answer15 = table.Column<string>(nullable: true),
                    Answer16 = table.Column<string>(nullable: true),
                    Answer17 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    Answer4 = table.Column<string>(nullable: true),
                    Answer5 = table.Column<string>(nullable: true),
                    Answer6 = table.Column<string>(nullable: true),
                    Answer7 = table.Column<string>(nullable: true),
                    Answer8 = table.Column<string>(nullable: true),
                    Answer9 = table.Column<string>(nullable: true),
                    Comment1 = table.Column<string>(nullable: true),
                    Comment10 = table.Column<string>(nullable: true),
                    Comment11 = table.Column<string>(nullable: true),
                    Comment12 = table.Column<string>(nullable: true),
                    Comment13 = table.Column<string>(nullable: true),
                    Comment14 = table.Column<string>(nullable: true),
                    Comment15 = table.Column<string>(nullable: true),
                    Comment16 = table.Column<string>(nullable: true),
                    Comment17 = table.Column<string>(nullable: true),
                    Comment2 = table.Column<string>(nullable: true),
                    Comment3 = table.Column<string>(nullable: true),
                    Comment4 = table.Column<string>(nullable: true),
                    Comment5 = table.Column<string>(nullable: true),
                    Comment6 = table.Column<string>(nullable: true),
                    Comment7 = table.Column<string>(nullable: true),
                    Comment8 = table.Column<string>(nullable: true),
                    Comment9 = table.Column<string>(nullable: true),
                    CompanyProfileID = table.Column<Guid>(nullable: false),
                    MainComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_UntertakenInitiatives", x => x.UndertakenInitiativeID);
                });

            migrationBuilder.CreateTable(
                name: "AD_Genders",
                columns: table => new
                {
                    GenderID = table.Column<Guid>(nullable: false),
                    Disabled = table.Column<string>(nullable: true),
                    FirmLeadershipID = table.Column<Guid>(nullable: false),
                    LeadershipDemographicsLeadershipDemographicID = table.Column<Guid>(nullable: true),
                    Lgbt = table.Column<string>(nullable: true),
                    MinorityFemale = table.Column<string>(nullable: true),
                    MinorityMale = table.Column<string>(nullable: true),
                    NumberQuestion = table.Column<string>(nullable: true),
                    WhiteFemale = table.Column<string>(nullable: true),
                    WhiteMale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_Genders", x => x.GenderID);
                    table.ForeignKey(
                        name: "FK_AD_Genders_AD_LeadershipDemographics_LeadershipDemographicsLeadershipDemographicID",
                        column: x => x.LeadershipDemographicsLeadershipDemographicID,
                        principalTable: "AD_LeadershipDemographics",
                        principalColumn: "LeadershipDemographicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AD_Regions",
                columns: table => new
                {
                    RegionID = table.Column<Guid>(nullable: false),
                    Associates = table.Column<string>(nullable: true),
                    Counsel = table.Column<string>(nullable: true),
                    EquityPartners = table.Column<string>(nullable: true),
                    FirmDemographicsFirmDemographicID = table.Column<Guid>(nullable: true),
                    JoinedLawyersJoinedLawyerID = table.Column<Guid>(nullable: true),
                    LeftLawyersLeftLawyerID = table.Column<Guid>(nullable: true),
                    MasterID = table.Column<Guid>(nullable: false),
                    NonEquityPartners = table.Column<string>(nullable: true),
                    OtherLawyers = table.Column<string>(nullable: true),
                    PromotionsAssociatePartnersPromotionsAssociatePartnerID = table.Column<Guid>(nullable: true),
                    ReducedHoursLawyersReducedHoursLawyerID = table.Column<Guid>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    TopTenHighestCompensationsTopTenHighestCompensationID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_Regions", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_FirmDemographics_FirmDemographicsFirmDemographicID",
                        column: x => x.FirmDemographicsFirmDemographicID,
                        principalTable: "AD_FirmDemographics",
                        principalColumn: "FirmDemographicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_JoinedLawyers_JoinedLawyersJoinedLawyerID",
                        column: x => x.JoinedLawyersJoinedLawyerID,
                        principalTable: "AD_JoinedLawyers",
                        principalColumn: "JoinedLawyerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_LeftLawyers_LeftLawyersLeftLawyerID",
                        column: x => x.LeftLawyersLeftLawyerID,
                        principalTable: "AD_LeftLawyers",
                        principalColumn: "LeftLawyerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_PromotionsAssociatePartners_PromotionsAssociatePartnersPromotionsAssociatePartnerID",
                        column: x => x.PromotionsAssociatePartnersPromotionsAssociatePartnerID,
                        principalTable: "AD_PromotionsAssociatePartners",
                        principalColumn: "PromotionsAssociatePartnerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_ReducedHoursLawyers_ReducedHoursLawyersReducedHoursLawyerID",
                        column: x => x.ReducedHoursLawyersReducedHoursLawyerID,
                        principalTable: "AD_ReducedHoursLawyers",
                        principalColumn: "ReducedHoursLawyerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AD_Regions_AD_TopTenHighestCompensations_TopTenHighestCompensationsTopTenHighestCompensationID",
                        column: x => x.TopTenHighestCompensationsTopTenHighestCompensationID,
                        principalTable: "AD_TopTenHighestCompensations",
                        principalColumn: "TopTenHighestCompensationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AD_Genders_LeadershipDemographicsLeadershipDemographicID",
                table: "AD_Genders",
                column: "LeadershipDemographicsLeadershipDemographicID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_FirmDemographicsFirmDemographicID",
                table: "AD_Regions",
                column: "FirmDemographicsFirmDemographicID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_JoinedLawyersJoinedLawyerID",
                table: "AD_Regions",
                column: "JoinedLawyersJoinedLawyerID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_LeftLawyersLeftLawyerID",
                table: "AD_Regions",
                column: "LeftLawyersLeftLawyerID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_PromotionsAssociatePartnersPromotionsAssociatePartnerID",
                table: "AD_Regions",
                column: "PromotionsAssociatePartnersPromotionsAssociatePartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_ReducedHoursLawyersReducedHoursLawyerID",
                table: "AD_Regions",
                column: "ReducedHoursLawyersReducedHoursLawyerID");

            migrationBuilder.CreateIndex(
                name: "IX_AD_Regions_TopTenHighestCompensationsTopTenHighestCompensationID",
                table: "AD_Regions",
                column: "TopTenHighestCompensationsTopTenHighestCompensationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AD_Certificates");

            migrationBuilder.DropTable(
                name: "AD_CompanyProfiles");

            migrationBuilder.DropTable(
                name: "AD_Firms");

            migrationBuilder.DropTable(
                name: "AD_Genders");

            migrationBuilder.DropTable(
                name: "AD_Regions");

            migrationBuilder.DropTable(
                name: "AD_UntertakenInitiatives");

            migrationBuilder.DropTable(
                name: "AD_LeadershipDemographics");

            migrationBuilder.DropTable(
                name: "AD_FirmDemographics");

            migrationBuilder.DropTable(
                name: "AD_JoinedLawyers");

            migrationBuilder.DropTable(
                name: "AD_LeftLawyers");

            migrationBuilder.DropTable(
                name: "AD_PromotionsAssociatePartners");

            migrationBuilder.DropTable(
                name: "AD_ReducedHoursLawyers");

            migrationBuilder.DropTable(
                name: "AD_TopTenHighestCompensations");
        }
    }
}
