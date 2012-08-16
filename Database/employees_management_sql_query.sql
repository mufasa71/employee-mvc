USE [master]
GO

/****** Object:  Database [EmployeesManagement]    Script Date: 08/16/2012 20:08:50 ******/
CREATE DATABASE [EmployeesManagement] ON  PRIMARY 
( NAME = N'EmployesManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EmployeesManagement.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmployesManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EmployeesManagement_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EmployeesManagement] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeesManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EmployeesManagement] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EmployeesManagement] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EmployeesManagement] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EmployeesManagement] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EmployeesManagement] SET ARITHABORT OFF 
GO

ALTER DATABASE [EmployeesManagement] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [EmployeesManagement] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EmployeesManagement] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EmployeesManagement] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EmployeesManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EmployeesManagement] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EmployeesManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EmployeesManagement] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EmployeesManagement] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EmployeesManagement] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EmployeesManagement] SET  ENABLE_BROKER 
GO

ALTER DATABASE [EmployeesManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EmployeesManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EmployeesManagement] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EmployeesManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EmployeesManagement] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EmployeesManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EmployeesManagement] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EmployeesManagement] SET  READ_WRITE 
GO

ALTER DATABASE [EmployeesManagement] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EmployeesManagement] SET  MULTI_USER 
GO

ALTER DATABASE [EmployeesManagement] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EmployeesManagement] SET DB_CHAINING OFF 
GO



USE [EmployeesManagement]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 08/16/2012 20:10:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employes] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- `dbo.Employees`
SET IDENTITY_INSERT dbo.Employees ON

INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (1, N'Steve Gates', 2000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (3, N'Bill Jobs', 3000, 0)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (4, N'Adam Freeman', 2500, 0)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (5, N'George Banson', 2300, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (6, N'Edward Clone', 1800, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (7, N'Sam Serious', 1900, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (9, N'Tupac Amaru', 13000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (10, N'Adam Freeman', 2500, 0)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (12, N'Rodem Shy''eni', 14000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (13, N'Wiserusk Bonaro', 33300, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (14, N'Tasban Issay', 2250, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (15, N'Lorsul Hatris', 800, 0)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (16, N'Dancha Yilda', 15000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (17, N'Leys Queatenth', 60000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (18, N'Erik Saner', 7999, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (19, N'Neil Dubuque', 21000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (20, N'Guy Stauber', 21500, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (21, N'Zelma Yopp', 43000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (22, N'Alana Venturini', 19000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (23, N'Harriett Taplin', 12000, 1)
INSERT dbo.Employees (EmployeeId, Name, Salary, IsActive) VALUES (24, N'Nelson Tatom', 23000, 0)
SET IDENTITY_INSERT dbo.Employees OFF
