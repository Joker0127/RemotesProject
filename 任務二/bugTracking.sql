USE [master]
GO
/****** Object:  Database [TicketTracking]    Script Date: 2022/1/16 下午 03:04:46 ******/
CREATE DATABASE [TicketTracking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TicketTracking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TicketTracking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TicketTracking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TicketTracking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TicketTracking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TicketTracking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TicketTracking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TicketTracking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TicketTracking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TicketTracking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TicketTracking] SET ARITHABORT OFF 
GO
ALTER DATABASE [TicketTracking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TicketTracking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TicketTracking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TicketTracking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TicketTracking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TicketTracking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TicketTracking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TicketTracking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TicketTracking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TicketTracking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TicketTracking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TicketTracking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TicketTracking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TicketTracking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TicketTracking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TicketTracking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TicketTracking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TicketTracking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TicketTracking] SET  MULTI_USER 
GO
ALTER DATABASE [TicketTracking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TicketTracking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TicketTracking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TicketTracking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TicketTracking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TicketTracking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TicketTracking] SET QUERY_STORE = OFF
GO
USE [TicketTracking]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2022/1/16 下午 03:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](100) NOT NULL,
	[Password] [varchar](100) NULL,
	[SiteRole] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportBug]    Script Date: 2022/1/16 下午 03:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportBug](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[BugDes] [varchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[bugStatus] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Account], [Password], [SiteRole], [CreateDate]) VALUES (1, N'admin', N'0000', 1, CAST(N'2022-01-15T12:52:34.373' AS DateTime))
INSERT [dbo].[Account] ([ID], [Account], [Password], [SiteRole], [CreateDate]) VALUES (2, N'qa', N'0000', 2, CAST(N'2022-01-15T12:55:06.680' AS DateTime))
INSERT [dbo].[Account] ([ID], [Account], [Password], [SiteRole], [CreateDate]) VALUES (3, N'rd', N'0000', 3, CAST(N'2022-01-15T12:55:31.043' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[ReportBug] ON 

INSERT [dbo].[ReportBug] ([ID], [Title], [BugDes], [CreateTime], [bugStatus]) VALUES (2, N'日期輸入', N'日期輸入後儲存失敗', CAST(N'2022-01-15T19:56:28.567' AS DateTime), 0)
INSERT [dbo].[ReportBug] ([ID], [Title], [BugDes], [CreateTime], [bugStatus]) VALUES (3, N'登入', N'登入時沒輸入密碼卻可以登入', CAST(N'2022-01-15T19:56:53.330' AS DateTime), 1)
INSERT [dbo].[ReportBug] ([ID], [Title], [BugDes], [CreateTime], [bugStatus]) VALUES (32, N'123', N'123', CAST(N'2022-01-16T13:36:09.057' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ReportBug] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_SiteRole]  DEFAULT ((0)) FOR [SiteRole]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ReportBug] ADD  CONSTRAINT [DF_ReportBug_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ReportBug] ADD  CONSTRAINT [DF_ReportBug_bugStatus]  DEFAULT ((0)) FOR [bugStatus]
GO
USE [master]
GO
ALTER DATABASE [TicketTracking] SET  READ_WRITE 
GO
