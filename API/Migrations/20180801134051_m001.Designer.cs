﻿// <auto-generated />
using API.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace API.Migrations
{
    [DbContext(typeof(ADContext))]
    [Migration("20180801134051_m001")]
    partial class m001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Tables.Certificates", b =>
                {
                    b.Property<Guid>("CertificateID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<DateTime>("DateCert");

                    b.Property<string>("Name");

                    b.HasKey("CertificateID");

                    b.ToTable("AD_Certificates");
                });

            modelBuilder.Entity("API.Tables.CompanyProfiles", b =>
                {
                    b.Property<Guid>("CompanyProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Catown");

                    b.Property<DateTime>("Datecomp");

                    b.Property<Guid>("FirmID");

                    b.Property<string>("Firmcert");

                    b.Property<string>("Firmhead");

                    b.Property<string>("Firmname");

                    b.Property<string>("Firmown");

                    b.Property<string>("Sizecat");

                    b.Property<string>("Srcemail");

                    b.Property<string>("Srcname");

                    b.Property<string>("Srctitle");

                    b.Property<int>("Totalfw");

                    b.Property<int>("Totalusfw");

                    b.HasKey("CompanyProfileID");

                    b.ToTable("AD_CompanyProfiles");
                });

            modelBuilder.Entity("API.Tables.FirmDemographics", b =>
                {
                    b.Property<Guid>("FirmDemographicID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("FirmDemographicID");

                    b.ToTable("AD_FirmDemographics");
                });

            modelBuilder.Entity("API.Tables.Firms", b =>
                {
                    b.Property<Guid>("FirmID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirmName");

                    b.HasKey("FirmID");

                    b.ToTable("AD_Firms");
                });

            modelBuilder.Entity("API.Tables.JoinedLawyers", b =>
                {
                    b.Property<Guid>("JoinedLawyerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("JoinedLawyerID");

                    b.ToTable("AD_JoinedLawyers");
                });

            modelBuilder.Entity("API.Tables.LeadershipDemographics", b =>
                {
                    b.Property<Guid>("LeadershipDemographicID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Disabled");

                    b.Property<string>("LGBT");

                    b.Property<string>("MinorityFemale");

                    b.Property<string>("MinorityMale");

                    b.Property<string>("NumberQuestion");

                    b.Property<string>("WhiteFemale");

                    b.Property<string>("WhiteMale");

                    b.HasKey("LeadershipDemographicID");

                    b.ToTable("AD_LeadershipDemographics");
                });

            modelBuilder.Entity("API.Tables.LeftLawyers", b =>
                {
                    b.Property<Guid>("LeftLawyerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("LeftLawyerID");

                    b.ToTable("AD_LeftLawyers");
                });

            modelBuilder.Entity("API.Tables.PromotionsAssociatePartners", b =>
                {
                    b.Property<Guid>("PromotionsAssociatePartnerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("PromotionsAssociatePartnerID");

                    b.ToTable("AD_PromotionsAssociatePartners");
                });

            modelBuilder.Entity("API.Tables.ReducedHoursLawyers", b =>
                {
                    b.Property<Guid>("ReducedHoursLawyerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("ReducedHoursLawyerID");

                    b.ToTable("AD_ReducedHoursLawyers");
                });

            modelBuilder.Entity("API.Tables.TopTenHighestCompensations", b =>
                {
                    b.Property<Guid>("TopTenHighestCompensationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Associates");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("Counsel");

                    b.Property<string>("EquityPartners");

                    b.Property<string>("NonEquityPartners");

                    b.Property<string>("OtherLawyers");

                    b.Property<string>("RegionName");

                    b.HasKey("TopTenHighestCompensationID");

                    b.ToTable("AD_TopTenHighestCompensations");
                });

            modelBuilder.Entity("API.Tables.UndertakenInitiatives", b =>
                {
                    b.Property<Guid>("UndertakenInitiativeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer1");

                    b.Property<string>("Answer10");

                    b.Property<string>("Answer11");

                    b.Property<string>("Answer12");

                    b.Property<string>("Answer13");

                    b.Property<string>("Answer14");

                    b.Property<string>("Answer15");

                    b.Property<string>("Answer16");

                    b.Property<string>("Answer17");

                    b.Property<string>("Answer2");

                    b.Property<string>("Answer3");

                    b.Property<string>("Answer4");

                    b.Property<string>("Answer5");

                    b.Property<string>("Answer6");

                    b.Property<string>("Answer7");

                    b.Property<string>("Answer8");

                    b.Property<string>("Answer9");

                    b.Property<string>("Comment1");

                    b.Property<string>("Comment10");

                    b.Property<string>("Comment11");

                    b.Property<string>("Comment12");

                    b.Property<string>("Comment13");

                    b.Property<string>("Comment14");

                    b.Property<string>("Comment15");

                    b.Property<string>("Comment16");

                    b.Property<string>("Comment17");

                    b.Property<string>("Comment2");

                    b.Property<string>("Comment3");

                    b.Property<string>("Comment4");

                    b.Property<string>("Comment5");

                    b.Property<string>("Comment6");

                    b.Property<string>("Comment7");

                    b.Property<string>("Comment8");

                    b.Property<string>("Comment9");

                    b.Property<Guid>("CompanyProfileID");

                    b.Property<string>("MainComment");

                    b.HasKey("UndertakenInitiativeID");

                    b.ToTable("AD_UntertakenInitiatives");
                });
#pragma warning restore 612, 618
        }
    }
}