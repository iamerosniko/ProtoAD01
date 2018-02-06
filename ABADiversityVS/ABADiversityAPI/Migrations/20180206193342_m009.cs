using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class m009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmInitiatives");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmDemographics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_HoursReducedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_HighCompensatedPartners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmInitiatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);
        }
    }
}
