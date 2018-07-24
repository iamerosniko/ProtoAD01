IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_CompanyProfiles] (
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [CertifyingEntityName] nvarchar(max) NULL,
        [CompletionDate] datetime2 NOT NULL,
        [FirmHead] nvarchar(max) NULL,
        [FirmName] nvarchar(max) NULL,
        [IsFirmCertified] bit NOT NULL,
        [IsFirmWomenOwned] bit NOT NULL,
        [OwnershipCategory] nvarchar(max) NULL,
        [SizeCategoryID] int NOT NULL,
        [SurveyContactEmail] nvarchar(max) NULL,
        [SurveyContactPerson] nvarchar(max) NULL,
        [SurveyContactTitle] nvarchar(max) NULL,
        [TotalLawyers] int NOT NULL,
        [TotalUSLawyers] int NOT NULL,
        [Year] int NOT NULL,
        CONSTRAINT [PK_ABA_CompanyProfiles] PRIMARY KEY ([CompanyProfileID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_FirmDemographics] (
        [FIrmDemographicsID] int NOT NULL IDENTITY,
        [Associates] int NOT NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Counsels] int NOT NULL,
        [EquityPartners] int NOT NULL,
        [NonEquityPartners] int NOT NULL,
        [OtherLawyers] int NOT NULL,
        [Race] nvarchar(max) NULL,
        CONSTRAINT [PK_ABA_FirmDemographics] PRIMARY KEY ([FIrmDemographicsID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_FirmInitiatives] (
        [FirmInitiativeID] int NOT NULL IDENTITY,
        [Comments] nvarchar(max) NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [IfYes] bit NOT NULL,
        [InitiativeQuestionID] int NOT NULL,
        CONSTRAINT [PK_ABA_FirmInitiatives] PRIMARY KEY ([FirmInitiativeID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_FirmLeaderships] (
        [FirmLeadershipID] int NOT NULL IDENTITY,
        [Category] nvarchar(max) NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Disabled] int NOT NULL,
        [LGBT] int NOT NULL,
        [MinorityFemale] int NOT NULL,
        [MinorityMale] int NOT NULL,
        [WhiteFemale] int NOT NULL,
        [WhiteMale] int NOT NULL,
        CONSTRAINT [PK_ABA_FirmLeaderships] PRIMARY KEY ([FirmLeadershipID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_HighCompensatedPartners] (
        [HighCompensatedPartnerID] int NOT NULL IDENTITY,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Men] int NOT NULL,
        [Race] nvarchar(max) NULL,
        [Women] int NOT NULL,
        CONSTRAINT [PK_ABA_HighCompensatedPartners] PRIMARY KEY ([HighCompensatedPartnerID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_HomegrownPartners] (
        [HomegrownPartnersID] int NOT NULL IDENTITY,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Disabled] int NOT NULL,
        [Gender] nvarchar(max) NULL,
        [LGBT] int NOT NULL,
        [Minority] int NOT NULL,
        [White] int NOT NULL,
        CONSTRAINT [PK_ABA_HomegrownPartners] PRIMARY KEY ([HomegrownPartnersID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_HoursReducedLawyers] (
        [HoursReducedLawyerID] int NOT NULL IDENTITY,
        [Associates] int NOT NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Counsels] int NOT NULL,
        [EquityPartners] int NOT NULL,
        [Gender] nvarchar(max) NULL,
        [NonEquityPartners] int NOT NULL,
        [OtherLawyers] int NOT NULL,
        CONSTRAINT [PK_ABA_HoursReducedLawyers] PRIMARY KEY ([HoursReducedLawyerID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_InitiativeQuestions] (
        [InitiativeQuestionID] int NOT NULL IDENTITY,
        [QuestionDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_ABA_InitiativeQuestions] PRIMARY KEY ([InitiativeQuestionID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_JoinedLawyers] (
        [JoinedLawyerID] int NOT NULL IDENTITY,
        [Associates] int NOT NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Counsels] int NOT NULL,
        [EquityPartners] int NOT NULL,
        [NonEquityPartners] int NOT NULL,
        [OtherLawyers] int NOT NULL,
        [Races] nvarchar(max) NULL,
        CONSTRAINT [PK_ABA_JoinedLawyers] PRIMARY KEY ([JoinedLawyerID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_LeftLawyers] (
        [LeftLawyerID] int NOT NULL IDENTITY,
        [Associates] int NOT NULL,
        [CompanyProfileID] uniqueidentifier NOT NULL,
        [Counsels] int NOT NULL,
        [EquityPartners] int NOT NULL,
        [NonEquityPartners] int NOT NULL,
        [OtherLawyers] int NOT NULL,
        [Races] nvarchar(max) NULL,
        CONSTRAINT [PK_ABA_LeftLawyers] PRIMARY KEY ([LeftLawyerID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [ABA_SizeCategory] (
        [SizeCategoryID] int NOT NULL IDENTITY,
        [SizeCategoryDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_ABA_SizeCategory] PRIMARY KEY ([SizeCategoryID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [set_group] (
        [grp_id] nvarchar(25) NOT NULL,
        [created_date] datetime2 NOT NULL,
        [grp_desc] nvarchar(255) NULL,
        [grp_name] nvarchar(50) NULL,
        CONSTRAINT [PK_set_group] PRIMARY KEY ([grp_id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [set_user] (
        [user_id] nvarchar(25) NOT NULL,
        [can_DEV] bit NOT NULL,
        [can_PEER] bit NOT NULL,
        [can_PROD] bit NOT NULL,
        [can_UAT] bit NOT NULL,
        [created_date] datetime2 NOT NULL,
        [user_first_name] nvarchar(50) NULL,
        [user_last_name] nvarchar(50) NULL,
        [user_middle_name] nvarchar(50) NULL,
        [user_name] nvarchar(25) NULL,
        CONSTRAINT [PK_set_user] PRIMARY KEY ([user_id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    CREATE TABLE [set_user_access] (
        [user_grp_id] int NOT NULL IDENTITY,
        [grp_id] nvarchar(25) NULL,
        [user_id] nvarchar(25) NULL,
        CONSTRAINT [PK_set_user_access] PRIMARY KEY ([user_grp_id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180208133714_ABAInit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180208133714_ABAInit', N'2.0.1-rtm-125');
END;

GO

