using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
    public partial class m010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABA_HomegrownPartners",
                columns: table => new
                {
                    HomegrownPartnersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyProfileID = table.Column<int>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABA_HomegrownPartners");

            migrationBuilder.DropTable(
                name: "ABA_SizeCategory");
        }
    }
}
