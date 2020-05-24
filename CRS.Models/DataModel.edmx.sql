-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/23/2015 09:18:30
-- Generated from EDMX file: C:\Projects\msrrs\branch\crs\CRS.Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CRS.sdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActivityLogs_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivityLogs] DROP CONSTRAINT [FK_ActivityLogs_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityLogs_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivityLogs] DROP CONSTRAINT [FK_ActivityLogs_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicantOutcomes_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ApplicantOutcomes] DROP CONSTRAINT [FK_ApplicantOutcomes_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicantOutcomes_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ApplicantOutcomes] DROP CONSTRAINT [FK_ApplicantOutcomes_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_EnumerationEnumerationDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnumerationDetails] DROP CONSTRAINT [FK_EnumerationEnumerationDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_InterviewFeedbacks_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InterviewFeedbacks] DROP CONSTRAINT [FK_InterviewFeedbacks_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_Interviews_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interviews] DROP CONSTRAINT [FK_Interviews_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_Interviews_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Interviews] DROP CONSTRAINT [FK_Interviews_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Lists_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lists] DROP CONSTRAINT [FK_Lists_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Lists_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lists] DROP CONSTRAINT [FK_Lists_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_Lists_WidgetInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lists] DROP CONSTRAINT [FK_Lists_WidgetInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_PageInventory_EnumerationDetails1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PageInventory] DROP CONSTRAINT [FK_PageInventory_EnumerationDetails1];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissions_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissions_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissions_WidgetInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_WidgetInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_Roles_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_Roles_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Tables_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tables] DROP CONSTRAINT [FK_Tables_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_UserNotes_Applicants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserNotes] DROP CONSTRAINT [FK_UserNotes_Applicants];
GO
IF OBJECT_ID(N'[dbo].[FK_WidgetBehaviorInventory_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WidgetBehaviorInventory] DROP CONSTRAINT [FK_WidgetBehaviorInventory_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_WidgetBehaviorInventory_WidgetInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WidgetBehaviorInventory] DROP CONSTRAINT [FK_WidgetBehaviorInventory_WidgetInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_WidgetInventory_EnumerationDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WidgetInventory] DROP CONSTRAINT [FK_WidgetInventory_EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_WidgetInventory_PageInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WidgetInventory] DROP CONSTRAINT [FK_WidgetInventory_PageInventory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ActivityLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivityLogs];
GO
IF OBJECT_ID(N'[dbo].[ApplicantOutcomes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ApplicantOutcomes];
GO
IF OBJECT_ID(N'[dbo].[Applicants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Applicants];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[EnumerationDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnumerationDetails];
GO
IF OBJECT_ID(N'[dbo].[Enumerations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enumerations];
GO
IF OBJECT_ID(N'[dbo].[InterviewFeedbacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterviewFeedbacks];
GO
IF OBJECT_ID(N'[dbo].[Interviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interviews];
GO
IF OBJECT_ID(N'[dbo].[Lists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lists];
GO
IF OBJECT_ID(N'[dbo].[PageInventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PageInventory];
GO
IF OBJECT_ID(N'[dbo].[RolePermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolePermissions];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Tables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tables];
GO
IF OBJECT_ID(N'[dbo].[UserNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserNotes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[WidgetAccessInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WidgetAccessInfo];
GO
IF OBJECT_ID(N'[dbo].[WidgetBehaviorInventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WidgetBehaviorInventory];
GO
IF OBJECT_ID(N'[dbo].[WidgetInventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WidgetInventory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ActivityLogs'
CREATE TABLE [dbo].[ActivityLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ApplicantId] int  NOT NULL,
    [ActionType] int  NOT NULL,
    [Timestamp] datetime  NOT NULL
);
GO

-- Creating table 'ApplicantOutcomes'
CREATE TABLE [dbo].[ApplicantOutcomes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicantId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [OfferStatus] int  NOT NULL,
    [DivisionId] int  NOT NULL,
    [ClosingDate] datetime  NOT NULL,
    [OutcomeDate] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(max)  NULL
);
GO

-- Creating table 'Applicants1'
CREATE TABLE [dbo].[Applicants1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [AddedBy] int  NOT NULL,
    [VeteransPreference] smallint  NOT NULL,
    [Series] nvarchar(max)  NOT NULL,
    [DateCreated] nvarchar(max)  NOT NULL,
    [DateDeactivated] nvarchar(max)  NOT NULL,
    [Active] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [Division] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comments1'
CREATE TABLE [dbo].[Comments1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicantId] int  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [UserId] int  NOT NULL,
    [Timestamp] datetime  NOT NULL
);
GO

-- Creating table 'Documents1'
CREATE TABLE [dbo].[Documents1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicantId] int  NOT NULL,
    [DocumentName] nvarchar(max)  NOT NULL,
    [DocumentType] int  NOT NULL
);
GO

-- Creating table 'EnumerationDetails1'
CREATE TABLE [dbo].[EnumerationDetails1] (
    [EnumerationId] int  NOT NULL,
    [IntVal] int  NOT NULL,
    [EnumerationName] nvarchar(50)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [DisplayText] nvarchar(200)  NULL,
    [Description] nvarchar(50)  NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Enumerations1'
CREATE TABLE [dbo].[Enumerations1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(100)  NULL
);
GO

-- Creating table 'InterviewFeedbacks'
CREATE TABLE [dbo].[InterviewFeedbacks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ApplicantId] int  NOT NULL,
    [OfferStatus] nvarchar(max)  NULL,
    [InterviewDone] nvarchar(max)  NULL,
    [CensusOfferStatus] nvarchar(max)  NULL,
    [ParsNumber] nvarchar(max)  NULL,
    [Supervisor1] nvarchar(max)  NULL,
    [Supervisor2] nvarchar(max)  NULL,
    [RelocationExpense] nvarchar(max)  NULL,
    [OfferReason1] nvarchar(max)  NULL,
    [OfferReason2] nvarchar(max)  NULL,
    [OfferReason3] nvarchar(max)  NULL,
    [OfferReason4] nvarchar(max)  NULL,
    [OfferReason5] nvarchar(max)  NULL,
    [OfferReason6] nvarchar(max)  NULL,
    [OfferReason7] nvarchar(max)  NULL,
    [OfferReason8] nvarchar(max)  NULL,
    [OfferReason9] nvarchar(max)  NULL
);
GO

-- Creating table 'Interviews1'
CREATE TABLE [dbo].[Interviews1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InterviewId] int  NOT NULL,
    [ApplicantId] int  NOT NULL,
    [FeedbackProvided] int  NOT NULL,
    [InterviewDate] datetime  NOT NULL
);
GO

-- Creating table 'PageInventories'
CREATE TABLE [dbo].[PageInventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PageInventoryId] int  NOT NULL,
    [PageType] int  NULL,
    [Title] nvarchar(50)  NULL,
    [Aliases] nvarchar(100)  NULL,
    [Description] nvarchar(100)  NULL,
    [PageOrder] int  NOT NULL
);
GO

-- Creating table 'RolePermissions'
CREATE TABLE [dbo].[RolePermissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PermissionTypeId] int  NOT NULL,
    [WidgetId] int  NULL,
    [Description] nvarchar(50)  NULL,
    [AccessCode] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActiveStatusId] int  NOT NULL,
    [Description] nchar(10)  NULL,
    [EnumerationDetailsId] int  NOT NULL
);
GO

-- Creating table 'Tables'
CREATE TABLE [dbo].[Tables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TableType] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'UserNotes1'
CREATE TABLE [dbo].[UserNotes1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicantId] int  NOT NULL,
    [Remarks] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users1'
CREATE TABLE [dbo].[Users1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JamesBond] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(200)  NULL,
    [Division] nvarchar(50)  NULL,
    [FailedLogins] int  NULL,
    [FirstFailureDate] datetime  NULL,
    [LastFailureDate] datetime  NULL,
    [CreatedDate] datetime  NOT NULL,
    [UserStatus] int  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [ISB] nvarchar(1)  NOT NULL,
    [PasswordReset] char(1)  NOT NULL,
    [PasswordExpirationDate] datetime  NOT NULL,
    [AccessCode] int  NOT NULL
);
GO

-- Creating table 'WidgetAccessInfoes'
CREATE TABLE [dbo].[WidgetAccessInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WidgetId] int  NOT NULL,
    [AccessLevelId] int  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'WidgetBehaviorInventories'
CREATE TABLE [dbo].[WidgetBehaviorInventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WidgetId] int  NOT NULL,
    [BehaviorId] int  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'WidgetInventories'
CREATE TABLE [dbo].[WidgetInventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PageId] int  NOT NULL,
    [WidgetType] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DisplayText] nvarchar(max)  NULL,
    [Description] nvarchar(250)  NULL
);
GO

-- Creating table 'Lists'
CREATE TABLE [dbo].[Lists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WidgetId] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [EnumerationDetailId] int  NOT NULL,
    [AccessCode] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [PK_ActivityLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ApplicantOutcomes'
ALTER TABLE [dbo].[ApplicantOutcomes]
ADD CONSTRAINT [PK_ApplicantOutcomes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Applicants1'
ALTER TABLE [dbo].[Applicants1]
ADD CONSTRAINT [PK_Applicants1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments1'
ALTER TABLE [dbo].[Comments1]
ADD CONSTRAINT [PK_Comments1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents1'
ALTER TABLE [dbo].[Documents1]
ADD CONSTRAINT [PK_Documents1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnumerationDetails1'
ALTER TABLE [dbo].[EnumerationDetails1]
ADD CONSTRAINT [PK_EnumerationDetails1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Enumerations1'
ALTER TABLE [dbo].[Enumerations1]
ADD CONSTRAINT [PK_Enumerations1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InterviewFeedbacks'
ALTER TABLE [dbo].[InterviewFeedbacks]
ADD CONSTRAINT [PK_InterviewFeedbacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interviews1'
ALTER TABLE [dbo].[Interviews1]
ADD CONSTRAINT [PK_Interviews1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PageInventories'
ALTER TABLE [dbo].[PageInventories]
ADD CONSTRAINT [PK_PageInventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [PK_RolePermissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tables'
ALTER TABLE [dbo].[Tables]
ADD CONSTRAINT [PK_Tables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserNotes1'
ALTER TABLE [dbo].[UserNotes1]
ADD CONSTRAINT [PK_UserNotes1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users1'
ALTER TABLE [dbo].[Users1]
ADD CONSTRAINT [PK_Users1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WidgetAccessInfoes'
ALTER TABLE [dbo].[WidgetAccessInfoes]
ADD CONSTRAINT [PK_WidgetAccessInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WidgetBehaviorInventories'
ALTER TABLE [dbo].[WidgetBehaviorInventories]
ADD CONSTRAINT [PK_WidgetBehaviorInventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WidgetInventories'
ALTER TABLE [dbo].[WidgetInventories]
ADD CONSTRAINT [PK_WidgetInventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lists'
ALTER TABLE [dbo].[Lists]
ADD CONSTRAINT [PK_Lists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApplicantId] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [FK_ActivityLogs_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityLogs_Applicants'
CREATE INDEX [IX_FK_ActivityLogs_Applicants]
ON [dbo].[ActivityLogs]
    ([ApplicantId]);
GO

-- Creating foreign key on [UserId] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [FK_ActivityLogs_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityLogs_Users'
CREATE INDEX [IX_FK_ActivityLogs_Users]
ON [dbo].[ActivityLogs]
    ([UserId]);
GO

-- Creating foreign key on [ApplicantId] in table 'ApplicantOutcomes'
ALTER TABLE [dbo].[ApplicantOutcomes]
ADD CONSTRAINT [FK_ApplicantOutcomes_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicantOutcomes_Applicants'
CREATE INDEX [IX_FK_ApplicantOutcomes_Applicants]
ON [dbo].[ApplicantOutcomes]
    ([ApplicantId]);
GO

-- Creating foreign key on [UserId] in table 'ApplicantOutcomes'
ALTER TABLE [dbo].[ApplicantOutcomes]
ADD CONSTRAINT [FK_ApplicantOutcomes_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicantOutcomes_Users'
CREATE INDEX [IX_FK_ApplicantOutcomes_Users]
ON [dbo].[ApplicantOutcomes]
    ([UserId]);
GO

-- Creating foreign key on [ApplicantId] in table 'Comments1'
ALTER TABLE [dbo].[Comments1]
ADD CONSTRAINT [FK_Comments_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Applicants'
CREATE INDEX [IX_FK_Comments_Applicants]
ON [dbo].[Comments1]
    ([ApplicantId]);
GO

-- Creating foreign key on [ApplicantId] in table 'Documents1'
ALTER TABLE [dbo].[Documents1]
ADD CONSTRAINT [FK_Documents_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Applicants'
CREATE INDEX [IX_FK_Documents_Applicants]
ON [dbo].[Documents1]
    ([ApplicantId]);
GO

-- Creating foreign key on [ApplicantId] in table 'Interviews1'
ALTER TABLE [dbo].[Interviews1]
ADD CONSTRAINT [FK_Interviews_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Interviews_Applicants'
CREATE INDEX [IX_FK_Interviews_Applicants]
ON [dbo].[Interviews1]
    ([ApplicantId]);
GO

-- Creating foreign key on [ApplicantId] in table 'UserNotes1'
ALTER TABLE [dbo].[UserNotes1]
ADD CONSTRAINT [FK_UserNotes_Applicants]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserNotes_Applicants'
CREATE INDEX [IX_FK_UserNotes_Applicants]
ON [dbo].[UserNotes1]
    ([ApplicantId]);
GO

-- Creating foreign key on [UserId] in table 'Comments1'
ALTER TABLE [dbo].[Comments1]
ADD CONSTRAINT [FK_Comments_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Users'
CREATE INDEX [IX_FK_Comments_Users]
ON [dbo].[Comments1]
    ([UserId]);
GO

-- Creating foreign key on [EnumerationId] in table 'EnumerationDetails1'
ALTER TABLE [dbo].[EnumerationDetails1]
ADD CONSTRAINT [FK_EnumerationEnumerationDetail]
    FOREIGN KEY ([EnumerationId])
    REFERENCES [dbo].[Enumerations1]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EnumerationEnumerationDetail'
CREATE INDEX [IX_FK_EnumerationEnumerationDetail]
ON [dbo].[EnumerationDetails1]
    ([EnumerationId]);
GO

-- Creating foreign key on [PageInventoryId] in table 'PageInventories'
ALTER TABLE [dbo].[PageInventories]
ADD CONSTRAINT [FK_PageInventory_EnumerationDetails1]
    FOREIGN KEY ([PageInventoryId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PageInventory_EnumerationDetails1'
CREATE INDEX [IX_FK_PageInventory_EnumerationDetails1]
ON [dbo].[PageInventories]
    ([PageInventoryId]);
GO

-- Creating foreign key on [PermissionTypeId] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_EnumerationDetails]
    FOREIGN KEY ([PermissionTypeId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_EnumerationDetails'
CREATE INDEX [IX_FK_RolePermissions_EnumerationDetails]
ON [dbo].[RolePermissions]
    ([PermissionTypeId]);
GO

-- Creating foreign key on [EnumerationDetailsId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_Roles_EnumerationDetails]
    FOREIGN KEY ([EnumerationDetailsId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Roles_EnumerationDetails'
CREATE INDEX [IX_FK_Roles_EnumerationDetails]
ON [dbo].[Roles]
    ([EnumerationDetailsId]);
GO

-- Creating foreign key on [TableType] in table 'Tables'
ALTER TABLE [dbo].[Tables]
ADD CONSTRAINT [FK_Tables_EnumerationDetails]
    FOREIGN KEY ([TableType])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tables_EnumerationDetails'
CREATE INDEX [IX_FK_Tables_EnumerationDetails]
ON [dbo].[Tables]
    ([TableType]);
GO

-- Creating foreign key on [BehaviorId] in table 'WidgetBehaviorInventories'
ALTER TABLE [dbo].[WidgetBehaviorInventories]
ADD CONSTRAINT [FK_WidgetBehaviorInventory_EnumerationDetails]
    FOREIGN KEY ([BehaviorId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WidgetBehaviorInventory_EnumerationDetails'
CREATE INDEX [IX_FK_WidgetBehaviorInventory_EnumerationDetails]
ON [dbo].[WidgetBehaviorInventories]
    ([BehaviorId]);
GO

-- Creating foreign key on [WidgetType] in table 'WidgetInventories'
ALTER TABLE [dbo].[WidgetInventories]
ADD CONSTRAINT [FK_WidgetInventory_EnumerationDetails]
    FOREIGN KEY ([WidgetType])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WidgetInventory_EnumerationDetails'
CREATE INDEX [IX_FK_WidgetInventory_EnumerationDetails]
ON [dbo].[WidgetInventories]
    ([WidgetType]);
GO

-- Creating foreign key on [UserId] in table 'InterviewFeedbacks'
ALTER TABLE [dbo].[InterviewFeedbacks]
ADD CONSTRAINT [FK_InterviewFeedbacks_Users1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InterviewFeedbacks_Users1'
CREATE INDEX [IX_FK_InterviewFeedbacks_Users1]
ON [dbo].[InterviewFeedbacks]
    ([UserId]);
GO

-- Creating foreign key on [InterviewId] in table 'Interviews1'
ALTER TABLE [dbo].[Interviews1]
ADD CONSTRAINT [FK_Interviews_Users]
    FOREIGN KEY ([InterviewId])
    REFERENCES [dbo].[Users1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Interviews_Users'
CREATE INDEX [IX_FK_Interviews_Users]
ON [dbo].[Interviews1]
    ([InterviewId]);
GO

-- Creating foreign key on [PageId] in table 'WidgetInventories'
ALTER TABLE [dbo].[WidgetInventories]
ADD CONSTRAINT [FK_WidgetInventory_PageInventory]
    FOREIGN KEY ([PageId])
    REFERENCES [dbo].[PageInventories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WidgetInventory_PageInventory'
CREATE INDEX [IX_FK_WidgetInventory_PageInventory]
ON [dbo].[WidgetInventories]
    ([PageId]);
GO

-- Creating foreign key on [AccessCode] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Roles]
    FOREIGN KEY ([AccessCode])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_Roles'
CREATE INDEX [IX_FK_RolePermissions_Roles]
ON [dbo].[RolePermissions]
    ([AccessCode]);
GO

-- Creating foreign key on [WidgetId] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_WidgetInventory]
    FOREIGN KEY ([WidgetId])
    REFERENCES [dbo].[WidgetInventories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_WidgetInventory'
CREATE INDEX [IX_FK_RolePermissions_WidgetInventory]
ON [dbo].[RolePermissions]
    ([WidgetId]);
GO

-- Creating foreign key on [WidgetId] in table 'WidgetBehaviorInventories'
ALTER TABLE [dbo].[WidgetBehaviorInventories]
ADD CONSTRAINT [FK_WidgetBehaviorInventory_WidgetInventory]
    FOREIGN KEY ([WidgetId])
    REFERENCES [dbo].[WidgetInventories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WidgetBehaviorInventory_WidgetInventory'
CREATE INDEX [IX_FK_WidgetBehaviorInventory_WidgetInventory]
ON [dbo].[WidgetBehaviorInventories]
    ([WidgetId]);
GO

-- Creating foreign key on [WidgetId] in table 'Lists'
ALTER TABLE [dbo].[Lists]
ADD CONSTRAINT [FK_Lists_WidgetInventory]
    FOREIGN KEY ([WidgetId])
    REFERENCES [dbo].[WidgetInventories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Lists_WidgetInventory'
CREATE INDEX [IX_FK_Lists_WidgetInventory]
ON [dbo].[Lists]
    ([WidgetId]);
GO

-- Creating foreign key on [EnumerationDetailId] in table 'Lists'
ALTER TABLE [dbo].[Lists]
ADD CONSTRAINT [FK_Lists_EnumerationDetails]
    FOREIGN KEY ([EnumerationDetailId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Lists_EnumerationDetails'
CREATE INDEX [IX_FK_Lists_EnumerationDetails]
ON [dbo].[Lists]
    ([EnumerationDetailId]);
GO

-- Creating foreign key on [EnumerationDetailsId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_Roles_EnumerationDetails1]
    FOREIGN KEY ([EnumerationDetailsId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Roles_EnumerationDetails1'
CREATE INDEX [IX_FK_Roles_EnumerationDetails1]
ON [dbo].[Roles]
    ([EnumerationDetailsId]);
GO

-- Creating foreign key on [EnumerationDetailsId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_Roles_EnumerationDetails2]
    FOREIGN KEY ([EnumerationDetailsId])
    REFERENCES [dbo].[EnumerationDetails1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Roles_EnumerationDetails2'
CREATE INDEX [IX_FK_Roles_EnumerationDetails2]
ON [dbo].[Roles]
    ([EnumerationDetailsId]);
GO

-- Creating foreign key on [AccessCode] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Roles1]
    FOREIGN KEY ([AccessCode])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_Roles1'
CREATE INDEX [IX_FK_RolePermissions_Roles1]
ON [dbo].[RolePermissions]
    ([AccessCode]);
GO

-- Creating foreign key on [AccessCode] in table 'Lists'
ALTER TABLE [dbo].[Lists]
ADD CONSTRAINT [FK_Lists_Roles]
    FOREIGN KEY ([AccessCode])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Lists_Roles'
CREATE INDEX [IX_FK_Lists_Roles]
ON [dbo].[Lists]
    ([AccessCode]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------