
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/21/2019 05:19:06
-- Generated from EDMX file: \\xpgwin\Users\XPGram\Home\GitHub\C-Sharp-Projects\NoPorschesInsurance\Models\Inquiry.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NoPorscheInsuranceDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Inquiries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inquiries];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Inquiries'
CREATE TABLE [dbo].[Inquiries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(20)  NOT NULL,
    [LastName] nvarchar(20)  NOT NULL,
    [EmailAddress] nvarchar(80)  NULL,
    [DateOfBirth] datetime  NOT NULL,
    [CarYear] int  NULL,
    [CarMake] nvarchar(40)  NULL,
    [CarModel] nvarchar(40)  NULL,
    [HadDUI] bit  NOT NULL,
    [NumSpeedingTickets] int  NULL,
    [CoverageType] nvarchar(40)  NULL,
    [Quote] decimal(18,0)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Inquiries'
ALTER TABLE [dbo].[Inquiries]
ADD CONSTRAINT [PK_Inquiries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------