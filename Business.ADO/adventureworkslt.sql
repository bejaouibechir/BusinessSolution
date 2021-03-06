USE [AdventureWorksLT]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PersonID] [int] NULL,
	[StoreID] [int] NULL,
	[TerritoryID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer_CustomerID] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Department_DepartmentID] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[BusinessEntityID] [int] NOT NULL,
	[NationalIDNumber] [nvarchar](15) NULL,
	[LoginID] [nvarchar](256) NULL,
	[JobTitle] [nvarchar](50) NULL,
	[BirthDate] [date] NULL,
	[MaritalStatus] [nchar](1) NULL,
	[Gender] [nchar](1) NULL,
	[HireDate] [date] NULL,
	[VacationHours] [smallint] NULL,
	[SickLeaveHours] [smallint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee_BusinessEntityID] PRIMARY KEY CLUSTERED 
(
	[BusinessEntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDepartmentHistory]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDepartmentHistory](
	[BusinessEntityID] [int] NULL,
	[DepartmentID] [smallint] NULL,
	[ModifiedDate] [datetime] NULL,
	[Note] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[BusinessEntityID] [int] NOT NULL,
	[PersonType] [nchar](2) NULL,
	[Title] [nvarchar](8) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailPromotion] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Person_BusinessEntityID] PRIMARY KEY CLUSTERED 
(
	[BusinessEntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 1/13/2022 5:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[StoreId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [Name], [GroupName], [ModifiedDate]) VALUES (1, N'Finance', N'Général', CAST(N'2022-01-13T15:22:53.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentID], [Name], [GroupName], [ModifiedDate]) VALUES (2, N'Production', N'Général', CAST(N'2022-01-13T15:28:19.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentID], [Name], [GroupName], [ModifiedDate]) VALUES (3, N'Recherche', N'Général', CAST(N'2022-01-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentID], [Name], [GroupName], [ModifiedDate]) VALUES (4, N'Marketing', N'Général', CAST(N'2022-01-13T15:28:27.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentID], [Name], [GroupName], [ModifiedDate]) VALUES (5, N'Personnels', N'Général', CAST(N'2022-01-13T15:28:27.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Employee] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Employee] ([BusinessEntityID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Employee]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Store] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreId])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Store]
GO
ALTER TABLE [dbo].[EmployeeDepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDepartmentHistory_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeDepartmentHistory] CHECK CONSTRAINT [FK_EmployeeDepartmentHistory_Department]
GO
ALTER TABLE [dbo].[EmployeeDepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDepartmentHistory_Employee] FOREIGN KEY([BusinessEntityID])
REFERENCES [dbo].[Employee] ([BusinessEntityID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[EmployeeDepartmentHistory] CHECK CONSTRAINT [FK_EmployeeDepartmentHistory_Employee]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Employee] FOREIGN KEY([BusinessEntityID])
REFERENCES [dbo].[Employee] ([BusinessEntityID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Employee]
GO
