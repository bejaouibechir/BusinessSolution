
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2022 14:36:29
-- Generated from EDMX file: C:\Users\bechir\source\repos\BusinessSolution\Business.EFModelFisrt\BusinessModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BusinessModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [BusinessEntityID] int IDENTITY(1,1) NOT NULL,
    [PersonType] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MidlleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [EmailPromotion] int  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [PersonID] int  NOT NULL,
    [StoreID] int  NOT NULL,
    [TerritoryID] int  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [EmployeeBusinessEntityID] int  NOT NULL,
    [StoreStoreID] int  NOT NULL
);
GO

-- Creating table 'Stores'
CREATE TABLE [dbo].[Stores] (
    [StoreID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Departements'
CREATE TABLE [dbo].[Departements] (
    [DepartementID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Persons_Employee'
CREATE TABLE [dbo].[Persons_Employee] (
    [NationalIDNumber] nvarchar(max)  NOT NULL,
    [LoginID] nvarchar(max)  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [MartialStatus] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [HireDate] datetime  NOT NULL,
    [VacationHours] int  NOT NULL,
    [SickLeaveHours] int  NOT NULL,
    [BusinessEntityID] int  NOT NULL
);
GO

-- Creating table 'Departement_Employee'
CREATE TABLE [dbo].[Departement_Employee] (
    [Departements_DepartementID] int  NOT NULL,
    [Employees_BusinessEntityID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BusinessEntityID] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([BusinessEntityID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [StoreID] in table 'Stores'
ALTER TABLE [dbo].[Stores]
ADD CONSTRAINT [PK_Stores]
    PRIMARY KEY CLUSTERED ([StoreID] ASC);
GO

-- Creating primary key on [DepartementID] in table 'Departements'
ALTER TABLE [dbo].[Departements]
ADD CONSTRAINT [PK_Departements]
    PRIMARY KEY CLUSTERED ([DepartementID] ASC);
GO

-- Creating primary key on [BusinessEntityID] in table 'Persons_Employee'
ALTER TABLE [dbo].[Persons_Employee]
ADD CONSTRAINT [PK_Persons_Employee]
    PRIMARY KEY CLUSTERED ([BusinessEntityID] ASC);
GO

-- Creating primary key on [Departements_DepartementID], [Employees_BusinessEntityID] in table 'Departement_Employee'
ALTER TABLE [dbo].[Departement_Employee]
ADD CONSTRAINT [PK_Departement_Employee]
    PRIMARY KEY CLUSTERED ([Departements_DepartementID], [Employees_BusinessEntityID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeBusinessEntityID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_EmployeeCustomer]
    FOREIGN KEY ([EmployeeBusinessEntityID])
    REFERENCES [dbo].[Persons_Employee]
        ([BusinessEntityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeCustomer'
CREATE INDEX [IX_FK_EmployeeCustomer]
ON [dbo].[Customers]
    ([EmployeeBusinessEntityID]);
GO

-- Creating foreign key on [StoreStoreID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_StoreCustomer]
    FOREIGN KEY ([StoreStoreID])
    REFERENCES [dbo].[Stores]
        ([StoreID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StoreCustomer'
CREATE INDEX [IX_FK_StoreCustomer]
ON [dbo].[Customers]
    ([StoreStoreID]);
GO

-- Creating foreign key on [Departements_DepartementID] in table 'Departement_Employee'
ALTER TABLE [dbo].[Departement_Employee]
ADD CONSTRAINT [FK_Departement_Employee_Departement]
    FOREIGN KEY ([Departements_DepartementID])
    REFERENCES [dbo].[Departements]
        ([DepartementID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employees_BusinessEntityID] in table 'Departement_Employee'
ALTER TABLE [dbo].[Departement_Employee]
ADD CONSTRAINT [FK_Departement_Employee_Employee]
    FOREIGN KEY ([Employees_BusinessEntityID])
    REFERENCES [dbo].[Persons_Employee]
        ([BusinessEntityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Departement_Employee_Employee'
CREATE INDEX [IX_FK_Departement_Employee_Employee]
ON [dbo].[Departement_Employee]
    ([Employees_BusinessEntityID]);
GO

-- Creating foreign key on [BusinessEntityID] in table 'Persons_Employee'
ALTER TABLE [dbo].[Persons_Employee]
ADD CONSTRAINT [FK_Employee_inherits_Person]
    FOREIGN KEY ([BusinessEntityID])
    REFERENCES [dbo].[Persons]
        ([BusinessEntityID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------