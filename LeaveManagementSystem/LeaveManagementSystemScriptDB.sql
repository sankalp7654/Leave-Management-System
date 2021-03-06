USE [master]
GO
/****** Object:  Database [LeaveManagementDB]    Script Date: 10-01-2020 20:24:27 ******/
CREATE DATABASE [LeaveManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeaveManagementDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LeaveManagementDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LeaveManagementDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LeaveManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LeaveManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeaveManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeaveManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeaveManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeaveManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LeaveManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [LeaveManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeaveManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeaveManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LeaveManagementDB]
GO
/****** Object:  Table [dbo].[Block_HQ]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Block_HQ](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Block_HQ] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[code] [varchar](20) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[post_id] [int] NOT NULL,
	[block_id] [int] NOT NULL,
	[type_of_institute_id] [int] NOT NULL,
	[posting_place_id] [int] NOT NULL,
	[gender] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees_Other_Leave_Counts]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees_Other_Leave_Counts](
	[code] [varchar](20) NOT NULL,
	[maternity_leave_count_left] [int] NOT NULL,
	[paternity_leave_count_left] [int] NOT NULL,
	[child_adoption_leave_count_left] [int] NOT NULL,
 CONSTRAINT [PK_Employees_Other_Leave_Counts_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees_Take_Leaves]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees_Take_Leaves](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[emp_code] [varchar](20) NOT NULL,
	[leave_id] [int] NOT NULL,
	[date_from] [date] NOT NULL,
	[date_to] [date] NOT NULL,
	[no_of_days] [int] NOT NULL,
	[financial_year_start] [int] NOT NULL,
	[financial_year_end] [int] NOT NULL,
	[absent_days] [int] NOT NULL,
 CONSTRAINT [PK_Employees_Take_Leaves] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[max_days] [int] NOT NULL,
	[max_count] [int] NOT NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 10-01-2020 20:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posting_Place]    Script Date: 10-01-2020 20:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posting_Place](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
 CONSTRAINT [PK_Posting_Place] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Of_Institute]    Script Date: 10-01-2020 20:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Of_Institute](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TypeOfInstitute] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Block_HQ] FOREIGN KEY([block_id])
REFERENCES [dbo].[Block_HQ] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Block_HQ]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Post]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Posting_Place] FOREIGN KEY([posting_place_id])
REFERENCES [dbo].[Posting_Place] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Posting_Place]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Type_Of_Institute] FOREIGN KEY([type_of_institute_id])
REFERENCES [dbo].[Type_Of_Institute] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Type_Of_Institute]
GO
ALTER TABLE [dbo].[Employees_Other_Leave_Counts]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Other_Leave_Counts_Employee] FOREIGN KEY([code])
REFERENCES [dbo].[Employee] ([code])
GO
ALTER TABLE [dbo].[Employees_Other_Leave_Counts] CHECK CONSTRAINT [FK_Employees_Other_Leave_Counts_Employee]
GO
ALTER TABLE [dbo].[Employees_Take_Leaves]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Take_Leaves_Employee] FOREIGN KEY([emp_code])
REFERENCES [dbo].[Employee] ([code])
GO
ALTER TABLE [dbo].[Employees_Take_Leaves] CHECK CONSTRAINT [FK_Employees_Take_Leaves_Employee]
GO
ALTER TABLE [dbo].[Employees_Take_Leaves]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Take_Leaves_Leave] FOREIGN KEY([leave_id])
REFERENCES [dbo].[Leave] ([id])
GO
ALTER TABLE [dbo].[Employees_Take_Leaves] CHECK CONSTRAINT [FK_Employees_Take_Leaves_Leave]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesByFinancialYearAndLeaveType]    Script Date: 10-01-2020 20:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create Proc [dbo].[GetEmployeesByFinancialYearAndLeaveType]
  ( @financial_year_start int,
	@financial_year_end int,
	@leave_id varchar(20))
	as
	select * from Employees_Take_Leaves etl
	join Employee e
	on e.code = etl.emp_code
	where @financial_year_start = etl.financial_year_start and
	@financial_year_end = etl.financial_year_end and
	@leave_id = etl.leave_id
GO
USE [master]
GO
ALTER DATABASE [LeaveManagementDB] SET  READ_WRITE 
GO
