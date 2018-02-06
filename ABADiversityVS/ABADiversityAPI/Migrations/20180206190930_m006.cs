using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class m006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_InitiativeQuestions");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ABA_HighCompensatedPartners");

            migrationBuilder.DropColumn(
                name: "GenderRace",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmInitiatives");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_FirmInitiatives");

            migrationBuilder.DropColumn(
                name: "Varchar",
                table: "ABA_FirmDemographics");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ABA_CompanyProfiles");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_LeftLawyers",
                newName: "OtherLawyers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_LeftLawyers",
                newName: "NonEquityPartners");

            migrationBuilder.RenameColumn(
                name: "CompanyProfileID",
                table: "ABA_LeftLawyers",
                newName: "EquityPartners");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_JoinedLawyers",
                newName: "OtherLawyers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_JoinedLawyers",
                newName: "NonEquityPartners");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "ABA_JoinedLawyers",
                newName: "Races");

            migrationBuilder.RenameColumn(
                name: "CompanyProfileID",
                table: "ABA_JoinedLawyers",
                newName: "EquityPartners");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_HoursReducedLawyers",
                newName: "OtherLawyers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_HoursReducedLawyers",
                newName: "NonEquityPartners");

            migrationBuilder.RenameColumn(
                name: "CompanyProfileID",
                table: "ABA_HoursReducedLawyers",
                newName: "EquityPartners");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_HighCompensatedPartners",
                newName: "Women");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_HighCompensatedPartners",
                newName: "Men");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "ABA_HighCompensatedPartners",
                newName: "Race");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_FirmLeaderships",
                newName: "WhiteMale");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_FirmLeaderships",
                newName: "WhiteFemale");

            migrationBuilder.RenameColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmLeaderships",
                newName: "MinorityMale");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ABA_FirmDemographics",
                newName: "OtherLawyers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ABA_FirmDemographics",
                newName: "NonEquityPartners");

            migrationBuilder.RenameColumn(
                name: "CompanyProfileID",
                table: "ABA_FirmDemographics",
                newName: "EquityPartners");

            migrationBuilder.AddColumn<int>(
                name: "Associates",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Counsels",
                table: "ABA_LeftLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Associates",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Counsels",
                table: "ABA_JoinedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Associates",
                table: "ABA_HoursReducedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Counsels",
                table: "ABA_HoursReducedLawyers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disabled",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LGBT",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinorityFemale",
                table: "ABA_FirmLeaderships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Associates",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Counsels",
                table: "ABA_FirmDemographics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Associates",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "Counsels",
                table: "ABA_LeftLawyers");

            migrationBuilder.DropColumn(
                name: "Associates",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "Counsels",
                table: "ABA_JoinedLawyers");

            migrationBuilder.DropColumn(
                name: "Associates",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "Counsels",
                table: "ABA_HoursReducedLawyers");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "LGBT",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "MinorityFemale",
                table: "ABA_FirmLeaderships");

            migrationBuilder.DropColumn(
                name: "Associates",
                table: "ABA_FirmDemographics");

            migrationBuilder.DropColumn(
                name: "Counsels",
                table: "ABA_FirmDemographics");

            migrationBuilder.RenameColumn(
                name: "OtherLawyers",
                table: "ABA_LeftLawyers",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "NonEquityPartners",
                table: "ABA_LeftLawyers",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EquityPartners",
                table: "ABA_LeftLawyers",
                newName: "CompanyProfileID");

            migrationBuilder.RenameColumn(
                name: "Races",
                table: "ABA_JoinedLawyers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "OtherLawyers",
                table: "ABA_JoinedLawyers",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "NonEquityPartners",
                table: "ABA_JoinedLawyers",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EquityPartners",
                table: "ABA_JoinedLawyers",
                newName: "CompanyProfileID");

            migrationBuilder.RenameColumn(
                name: "OtherLawyers",
                table: "ABA_HoursReducedLawyers",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "NonEquityPartners",
                table: "ABA_HoursReducedLawyers",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EquityPartners",
                table: "ABA_HoursReducedLawyers",
                newName: "CompanyProfileID");

            migrationBuilder.RenameColumn(
                name: "Women",
                table: "ABA_HighCompensatedPartners",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Race",
                table: "ABA_HighCompensatedPartners",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Men",
                table: "ABA_HighCompensatedPartners",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "WhiteMale",
                table: "ABA_FirmLeaderships",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "WhiteFemale",
                table: "ABA_FirmLeaderships",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "MinorityMale",
                table: "ABA_FirmLeaderships",
                newName: "CompanyProfileID");

            migrationBuilder.RenameColumn(
                name: "OtherLawyers",
                table: "ABA_FirmDemographics",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "NonEquityPartners",
                table: "ABA_FirmDemographics",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EquityPartners",
                table: "ABA_FirmDemographics",
                newName: "CompanyProfileID");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "ABA_LeftLawyers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "ABA_JoinedLawyers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_InitiativeQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ABA_HoursReducedLawyers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_HighCompensatedPartners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "ABA_HighCompensatedPartners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderRace",
                table: "ABA_FirmLeaderships",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileID",
                table: "ABA_FirmInitiatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_FirmInitiatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Varchar",
                table: "ABA_FirmDemographics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ABA_CompanyProfiles",
                nullable: false,
                defaultValue: 0);
        }
    }
}
