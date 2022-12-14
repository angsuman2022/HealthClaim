USE [master]
GO
/****** Object:  Database [HealthClaimDB]    Script Date: 04-11-2022 09:43:58 ******/
CREATE DATABASE [HealthClaimDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthClaimDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HealthClaimDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthClaimDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HealthClaimDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HealthClaimDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthClaimDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthClaimDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthClaimDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthClaimDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthClaimDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthClaimDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthClaimDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthClaimDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthClaimDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthClaimDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthClaimDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthClaimDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthClaimDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthClaimDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthClaimDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthClaimDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthClaimDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthClaimDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthClaimDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthClaimDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthClaimDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthClaimDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthClaimDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthClaimDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HealthClaimDB] SET  MULTI_USER 
GO
ALTER DATABASE [HealthClaimDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthClaimDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthClaimDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthClaimDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HealthClaimDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HealthClaimDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthClaimDB', N'ON'
GO
ALTER DATABASE [HealthClaimDB] SET QUERY_STORE = OFF
GO
USE [HealthClaimDB]
GO
/****** Object:  Table [dbo].[Claimtbl]    Script Date: 04-11-2022 09:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claimtbl](
	[ClaimID] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](50) NULL,
	[ClaimAmount] [numeric](18, 2) NULL,
	[ClaimDate] [datetime] NULL,
	[MemberId] [int] NULL,
	[Remarks] [nvarchar](100) NULL,
 CONSTRAINT [PK_Claimtbl] PRIMARY KEY CLUSTERED 
(
	[ClaimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberDet]    Script Date: 04-11-2022 09:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberDet](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NULL,
	[ConPassword] [nvarchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[State] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[MemberType] [nvarchar](50) NULL,
	[PhysianId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModiDate] [datetime] NULL,
 CONSTRAINT [PK_MemberDet] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhysicianDet]    Script Date: 04-11-2022 09:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicianDet](
	[PhysicianId] [int] IDENTITY(1,1) NOT NULL,
	[PhysicianName] [nvarchar](50) NULL,
	[PhysicianState] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhysicianDet] PRIMARY KEY CLUSTERED 
(
	[PhysicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statetbl]    Script Date: 04-11-2022 09:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statetbl](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Statetbl] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Claimtbl] ON 

INSERT [dbo].[Claimtbl] ([ClaimID], [ClaimType], [ClaimAmount], [ClaimDate], [MemberId], [Remarks]) VALUES (1, N'Vision', CAST(1000.00 AS Numeric(18, 2)), CAST(N'2022-11-01T00:00:00.000' AS DateTime), 3, N'Test')
INSERT [dbo].[Claimtbl] ([ClaimID], [ClaimType], [ClaimAmount], [ClaimDate], [MemberId], [Remarks]) VALUES (2, N'Dental', CAST(2000.00 AS Numeric(18, 2)), CAST(N'2022-11-02T00:00:00.000' AS DateTime), 4, N'New member')
INSERT [dbo].[Claimtbl] ([ClaimID], [ClaimType], [ClaimAmount], [ClaimDate], [MemberId], [Remarks]) VALUES (3, N'Vision', CAST(1000.00 AS Numeric(18, 2)), CAST(N'2022-11-02T00:00:00.000' AS DateTime), 4, N'Test')
INSERT [dbo].[Claimtbl] ([ClaimID], [ClaimType], [ClaimAmount], [ClaimDate], [MemberId], [Remarks]) VALUES (4, N'Dental', CAST(3000.00 AS Numeric(18, 2)), CAST(N'2022-11-02T00:00:00.000' AS DateTime), 4, N'test')
SET IDENTITY_INSERT [dbo].[Claimtbl] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberDet] ON 

INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (1, N'Angsuman', N'Patra', N'Angsu123', N'P@ssw0rd', N'P@ssw0rd', N'Kolkata', N'West Bengal', N'Kolkata', N'angsu@gmail.com', N'1992-01-28', N'Admin', 0, NULL, NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (3, N'Amit', N'Das', N'Amit123', N'Amit@123', N'Amit@123', N'Kolkata', N'West bengal', N'Amit@123', N'amit@gmail.com', N'2022-10-31', N'Member', 1, NULL, NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (4, N'Avik', N'Sen', N'Avik123', N'Avik@123', N'Avik@123', N'Kolkata', N'West bengal', N'Avik@123', N'a@gmail.com', N'2022-11-24', N'Member', 1, CAST(N'2022-11-01T00:06:49.910' AS DateTime), NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (5, N'Arnab', N'Mullick', N'Arnab123', N'Arnab@123', N'Arnab@123', N'Kolkata', N'West bengal', N'Arnab@123', N'arnab@gmail.com', N'2022-11-01', N'Member', 2, CAST(N'2022-11-01T11:17:57.083' AS DateTime), NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (6, N'Sourav', N'Choudhury', N'Sourav123', N'Sourav@123', N'Sourav@123', N'Kolkata', N'West bengal', N'Sourav@123', N'sourav@gmail.com', N'2022-11-01', N'Member', 4, CAST(N'2022-11-01T11:35:59.887' AS DateTime), NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (7, N'Souvik', N'Bosee', N'Souvik', N'Souvik@123', N'Souvik@123', N'Kolkata', N'West bengal', N'Souvik@123', N'souvik@gmail.com', N'2022-11-23', N'Member', 7, CAST(N'2022-11-01T11:55:41.490' AS DateTime), NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (8, N'Subhajit', N'Kundu', N'Subhajit123', N'Subhajit@123', N'Subhajit@123', N'Basdroni', N'West bengal', N'Subhajit@123', N'subhajit@gmail.com', N'2022-11-02', N'Member', 7, CAST(N'2022-11-02T10:21:32.750' AS DateTime), NULL)
INSERT [dbo].[MemberDet] ([MemberId], [FirstName], [LastName], [UserName], [Password], [ConPassword], [Address], [State], [City], [Email], [DateOfBirth], [MemberType], [PhysianId], [CreateDate], [ModiDate]) VALUES (9, N'Avirup', N'Nandy', N'Avirup123', N'Avirup@123', N'Avirup@123', N'Kolkata', N'West bengal', N'Avirup@123', N'ab@gmail.com', N'2022-11-02', N'Member', 6, CAST(N'2022-11-02T10:31:08.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[MemberDet] OFF
GO
SET IDENTITY_INSERT [dbo].[PhysicianDet] ON 

INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (1, N'John', N'UT')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (2, N'Hari', N'WA')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (3, N'Mittal', N'TX')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (4, N'Patrick', N'OH')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (5, N'Mark', N'CA')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (6, N'Jessica', N'NY')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (7, N'Mary', N'IL')
INSERT [dbo].[PhysicianDet] ([PhysicianId], [PhysicianName], [PhysicianState]) VALUES (8, N'Stacy', N'FL')
SET IDENTITY_INSERT [dbo].[PhysicianDet] OFF
GO
SET IDENTITY_INSERT [dbo].[Statetbl] ON 

INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (1, N'Andhra Pradesh')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (2, N'Arunachal Pradesh')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (3, N'Assam')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (4, N'Bihar')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (5, N'Chhattisgarh')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (6, N'Goa')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (7, N'Gujarat')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (8, N'Haryana')
INSERT [dbo].[Statetbl] ([StateId], [StateName]) VALUES (9, N'West bengal')
SET IDENTITY_INSERT [dbo].[Statetbl] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__MemberDe__C9F2845627BA75A2]    Script Date: 04-11-2022 09:43:59 ******/
ALTER TABLE [dbo].[MemberDet] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HealthClaimDB] SET  READ_WRITE 
GO
