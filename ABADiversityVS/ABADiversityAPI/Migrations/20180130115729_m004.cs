using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABADiversityAPI.Migrations
{
  public partial class m004 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Dummies");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Dummies",
          columns: table => new
          {
            CompanyProfileID = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Dummies", x => x.CompanyProfileID);
          });
    }
  }
}
