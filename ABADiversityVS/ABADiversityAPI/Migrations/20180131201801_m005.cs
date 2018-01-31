using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class m005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_InitiativeQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmInitiatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ABA_HoursReducedLawyers",
                columns: table => new
                {
                    HoursReducedLawyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyProfileID = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABA_HoursReducedLawyers", x => x.HoursReducedLawyerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_InitiativeQuestions");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmInitiatives");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmDemographics");
        }
    }
}
