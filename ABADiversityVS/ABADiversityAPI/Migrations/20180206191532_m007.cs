using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class m007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_HoursReducedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_HoursReducedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_HighCompensatedPartners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_CompanyProfiles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmDemographics");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmDemographics");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_CompanyProfiles");
        }
    }
}
