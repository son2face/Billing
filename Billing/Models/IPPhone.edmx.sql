
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2017 19:00:43
-- Generated from EDMX file: D:\Billing\Billing\Models\IPPhone.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IPPhone];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Principal_Operation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Principal] DROP CONSTRAINT [FK_Principal_Operation];
GO
IF OBJECT_ID(N'[dbo].[FK_Principal_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Principal] DROP CONSTRAINT [FK_Principal_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CallPrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CallPrice];
GO
IF OBJECT_ID(N'[dbo].[CallRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CallRecord];
GO
IF OBJECT_ID(N'[dbo].[ChargeLevel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChargeLevel];
GO
IF OBJECT_ID(N'[dbo].[CompanyReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyReport];
GO
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[DepartmentReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentReport];
GO
IF OBJECT_ID(N'[dbo].[Operation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operation];
GO
IF OBJECT_ID(N'[dbo].[PersonReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonReport];
GO
IF OBJECT_ID(N'[dbo].[Principal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Principal];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[UserToken]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserToken];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CallPrices'
CREATE TABLE [dbo].[CallPrices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Category] nvarchar(50)  NULL,
    [NumberHeader] int  NULL,
    [Minute] int  NULL,
    [Block6] int  NULL,
    [Second] int  NULL,
    [Type] int  NULL,
    [Area] nvarchar(250)  NULL,
    [Description] varchar(max)  NULL
);
GO

-- Creating table 'CallRecords'
CREATE TABLE [dbo].[CallRecords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CallingPartyNumber] int  NULL,
    [AuthCodeDescription] nvarchar(250)  NULL,
    [FinalCalledPartyNumber] nvarchar(250)  NULL,
    [DateTimeConnect] int  NULL,
    [DataTimeDisconnect] int  NULL,
    [FinalCalledPartyNumberPartition] nvarchar(max)  NULL,
    [Duration] int  NULL,
    [Charge] int  NULL,
    [Month] int  NULL,
    [Year] int  NULL,
    [DirectoryNumber] int  NULL,
    [Owner] nvarchar(250)  NULL,
    [Department] nvarchar(250)  NULL,
    [Company] nvarchar(250)  NULL
);
GO

-- Creating table 'ChargeLevels'
CREATE TABLE [dbo].[ChargeLevels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Level] tinyint  NULL,
    [Charge] int  NULL
);
GO

-- Creating table 'CompanyReports'
CREATE TABLE [dbo].[CompanyReports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Company] nvarchar(250)  NULL,
    [TotalDuration] int  NULL,
    [TotalCharge] int  NULL,
    [MobileDuration] int  NULL,
    [MobileCharge] int  NULL,
    [LongDuration] int  NULL,
    [LongCharge] int  NULL,
    [LocalDuration] int  NULL,
    [LocalCharge] int  NULL,
    [ServiceDuration] int  NOT NULL,
    [ServiceCharge] int  NULL,
    [InterDuration] int  NULL,
    [InterCharge] int  NULL,
    [Month] tinyint  NULL,
    [Year] tinyint  NULL,
    [RealCharge] int  NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DirectoryNumber] nvarchar(250)  NULL,
    [Owner] nvarchar(250)  NULL,
    [Department] nvarchar(250)  NULL,
    [Company] nvarchar(250)  NULL,
    [Level] tinyint  NULL
);
GO

-- Creating table 'DepartmentReports'
CREATE TABLE [dbo].[DepartmentReports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Department] nvarchar(250)  NULL,
    [Company] nvarchar(250)  NULL,
    [TotalDuration] int  NULL,
    [TotalCharge] int  NULL,
    [MobileDuration] int  NULL,
    [MobileCharge] int  NULL,
    [LongDuration] int  NULL,
    [LongCharge] int  NULL,
    [LocalDuration] int  NULL,
    [LocalCharge] int  NULL,
    [ServiceDuration] int  NULL,
    [ServiceCharge] int  NULL,
    [InterDuration] int  NULL,
    [InterCharge] int  NULL,
    [Month] tinyint  NULL,
    [Year] tinyint  NULL,
    [RealCharge] int  NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Method] nvarchar(max)  NULL,
    [Link] nvarchar(max)  NULL,
    [Type] bit  NULL
);
GO

-- Creating table 'PersonReports'
CREATE TABLE [dbo].[PersonReports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DirectoryNumber] int  NULL,
    [Person] nvarchar(250)  NULL,
    [Department] nvarchar(250)  NULL,
    [Company] nvarchar(250)  NULL,
    [TotalDuration] int  NULL,
    [TotalCharge] int  NULL,
    [MobileDuration] int  NULL,
    [MobileCharge] int  NULL,
    [LongDuration] int  NULL,
    [LongCharge] int  NULL,
    [LocalDuration] int  NULL,
    [LocalCharge] int  NULL,
    [ServiceDuration] int  NULL,
    [ServiceCharge] int  NULL,
    [InterDuration] int  NULL,
    [InterCharge] int  NULL,
    [Month] tinyint  NULL,
    [Year] tinyint  NULL,
    [RealCharge] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'UserTokens'
CREATE TABLE [dbo].[UserTokens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Token] nvarchar(max)  NULL,
    [ExpiredTime] datetime  NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Principal'
CREATE TABLE [dbo].[Principal] (
    [Operations_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [Roles_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CallPrices'
ALTER TABLE [dbo].[CallPrices]
ADD CONSTRAINT [PK_CallPrices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CallRecords'
ALTER TABLE [dbo].[CallRecords]
ADD CONSTRAINT [PK_CallRecords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChargeLevels'
ALTER TABLE [dbo].[ChargeLevels]
ADD CONSTRAINT [PK_ChargeLevels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanyReports'
ALTER TABLE [dbo].[CompanyReports]
ADD CONSTRAINT [PK_CompanyReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartmentReports'
ALTER TABLE [dbo].[DepartmentReports]
ADD CONSTRAINT [PK_DepartmentReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonReports'
ALTER TABLE [dbo].[PersonReports]
ADD CONSTRAINT [PK_PersonReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserTokens'
ALTER TABLE [dbo].[UserTokens]
ADD CONSTRAINT [PK_UserTokens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Operations_Id], [Roles_Id] in table 'Principal'
ALTER TABLE [dbo].[Principal]
ADD CONSTRAINT [PK_Principal]
    PRIMARY KEY CLUSTERED ([Operations_Id], [Roles_Id] ASC);
GO

-- Creating primary key on [Roles_Id], [Users_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([Roles_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Operations_Id] in table 'Principal'
ALTER TABLE [dbo].[Principal]
ADD CONSTRAINT [FK_Principal_Operation]
    FOREIGN KEY ([Operations_Id])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'Principal'
ALTER TABLE [dbo].[Principal]
ADD CONSTRAINT [FK_Principal_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Principal_Role'
CREATE INDEX [IX_FK_Principal_Role]
ON [dbo].[Principal]
    ([Roles_Id]);
GO

-- Creating foreign key on [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRole]
    ([Users_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_FileUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileUser'
CREATE INDEX [IX_FK_FileUser]
ON [dbo].[Files]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------