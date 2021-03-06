USE [master]
GO
/****** Object:  Database [CarPool]    Script Date: 4/26/2018 11:19:38 PM ******/
CREATE DATABASE [CarPool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarPool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CarPool.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarPool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CarPool_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarPool] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarPool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarPool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarPool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarPool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarPool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarPool] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarPool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarPool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarPool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarPool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarPool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarPool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarPool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarPool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarPool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarPool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarPool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarPool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarPool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarPool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarPool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarPool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarPool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarPool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarPool] SET  MULTI_USER 
GO
ALTER DATABASE [CarPool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarPool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarPool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarPool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CarPool] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CarPool]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[City] [int] NULL,
	[State] [int] NULL,
	[Country] [int] NULL,
	[Pincode] [nvarchar](50) NULL,
	[IsActivate] [int] NULL,
	[IsDeleted] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProviderUser]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProviderUser](
	[ProviderId] [int] NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[TotalYearExp] [int] NULL,
	[CarModel] [nvarchar](50) NULL,
	[RegistrationNo] [nvarchar](50) NULL,
	[StartPoint] [nvarchar](50) NULL,
	[EndPoint] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblProviderUser] PRIMARY KEY CLUSTERED 
(
	[ProviderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRegistedGroup]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRegistedGroup](
	[RGroupId] [int] NOT NULL,
	[RGType] [int] NULL,
	[RGName] [nvarchar](1000) NULL,
	[StartFrom] [nvarchar](50) NULL,
	[EndFrom] [nvarchar](50) NULL,
	[RGDesc] [nvarchar](max) NULL,
	[RGCreatedDate] [datetime] NULL,
	[RGImagePath] [varbinary](max) NULL,
	[IsAutoRegister] [bit] NULL,
	[RGLink] [nvarchar](50) NULL,
	[IsRanking] [int] NULL,
	[City] [int] NULL,
	[Country] [int] NULL,
	[IsActivate] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblRegistedGroup] PRIMARY KEY CLUSTERED 
(
	[RGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserRequest]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRequest](
	[GRId] [int] NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[TicketId] [nvarchar](50) NULL,
	[TicketType] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[IsActivate] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRequest] PRIMARY KEY CLUSTERED 
(
	[GRId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUserRGDetails]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserRGDetails](
	[GRId] [int] NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[RGroupId] [int] NULL,
	[JustificationDesc] [nvarchar](50) NULL,
	[ImagePath] [varbinary](50) NULL,
	[IsActivate] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUserRGDetails] PRIMARY KEY CLUSTERED 
(
	[GRId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserRGMapping]    Script Date: 4/26/2018 11:19:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRGMapping](
	[UserRGId] [int] NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[RGroupId] [int] NULL,
 CONSTRAINT [PK_tblUserRGMapping] PRIMARY KEY CLUSTERED 
(
	[UserRGId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'GropAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4', N'Provider')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'SuperAdmin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'User')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d33978c-a7fe-43d4-b874-99c70f69dc99', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'24c6a1d2-868e-4afe-86df-ff1503a303bc', N'1')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Address1], [Address2], [Street], [City], [State], [Country], [Pincode], [IsActivate], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'1d33978c-a7fe-43d4-b874-99c70f69dc99', N'jigar', N'khalas', N'admin@gmail.com', 0, N'ACQ7UvfK3lvBarAYDMyJVyR6VcfU1WcXTbGk1IgiwI21eUwreCtyyT5/OKdRqSpdQg==', N'30951254-0995-479d-9ff2-9031a1538a7d', NULL, 0, 0, NULL, 0, 0, N'admin@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Address1], [Address2], [Street], [City], [State], [Country], [Pincode], [IsActivate], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'24c6a1d2-868e-4afe-86df-ff1503a303bc', NULL, NULL, N'maynak@gmail.com', 0, N'AE0BsJTjoctVMVHYMJLhqi/NCoxMLPMbpZjUtonbRZHDxasoJ93rMwlPY16mc3PGeQ==', N'0a1e736c-8767-4114-be57-d3f99e035fed', NULL, 0, 0, NULL, 0, 0, N'maynak@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/26/2018 11:19:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 4/26/2018 11:19:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 4/26/2018 11:19:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/26/2018 11:19:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [CarPool] SET  READ_WRITE 
GO
