using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ABADiversityAPI.Migrations
{
  public partial class m011 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_LeftLawyers",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_JoinedLawyers",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_HoursReducedLawyers",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_HomegrownPartners",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_HighCompensatedPartners",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_FirmLeaderships",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_FirmInitiatives",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_FirmDemographics",
          nullable: false,
          oldClrType: typeof(int));

      migrationBuilder.AlterColumn<Guid>(
          name: "CompanyProfileID",
          table: "ABA_CompanyProfiles",
          nullable: false,
          oldClrType: typeof(int))
          .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_LeftLawyers",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_JoinedLawyers",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_HoursReducedLawyers",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_HomegrownPartners",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_HighCompensatedPartners",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_FirmLeaderships",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_FirmInitiatives",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_FirmDemographics",
          nullable: false,
          oldClrType: typeof(Guid));

      migrationBuilder.AlterColumn<int>(
          name: "CompanyProfileID",
          table: "ABA_CompanyProfiles",
          nullable: false,
          oldClrType: typeof(Guid))
          .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
    }
  }
}
