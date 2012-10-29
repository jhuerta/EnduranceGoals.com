USE [master]
GO

/****** Object:  Database [EnduranceGoals]    Script Date: 10/24/2012 20:19:03 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'EnduranceGoals')
DROP DATABASE [EnduranceGoals]
GO

USE [master]
GO
/****** Object:  Database [EnduranceGoals]    Script Date: 10/24/2012 20:33:56 ******/
CREATE DATABASE [EnduranceGoals] ON  PRIMARY 
( NAME = N'EnduranceGoals', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnduranceGoals.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EnduranceGoals_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnduranceGoals_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EnduranceGoals] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnduranceGoals].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnduranceGoals] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EnduranceGoals] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EnduranceGoals] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EnduranceGoals] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EnduranceGoals] SET ARITHABORT OFF
GO
ALTER DATABASE [EnduranceGoals] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [EnduranceGoals] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EnduranceGoals] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EnduranceGoals] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EnduranceGoals] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EnduranceGoals] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EnduranceGoals] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EnduranceGoals] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EnduranceGoals] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EnduranceGoals] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EnduranceGoals] SET  DISABLE_BROKER
GO
ALTER DATABASE [EnduranceGoals] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EnduranceGoals] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EnduranceGoals] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EnduranceGoals] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EnduranceGoals] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EnduranceGoals] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EnduranceGoals] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EnduranceGoals] SET  READ_WRITE
GO
ALTER DATABASE [EnduranceGoals] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EnduranceGoals] SET  MULTI_USER
GO
ALTER DATABASE [EnduranceGoals] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EnduranceGoals] SET DB_CHAINING OFF
GO
USE [EnduranceGoals]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Name] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sports]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sports](
	[Name] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Name] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Name] [nvarchar](100) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Cities_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venues]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venues](
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goals]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goals](
	[Date] [datetime] NOT NULL,
	[SportId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[EventWeb] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VenueId] [int] NOT NULL,
	[UserCreatorId] [int] NOT NULL,
 CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGoals]    Script Date: 10/24/2012 20:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGoals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SignedOnDate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[GoalId] [int] NOT NULL,
 CONSTRAINT [PK_UserGoals] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GoalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Cities_CountryId]    Script Date: 10/24/2012 20:33:57 ******/
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_CountryId]
GO
/****** Object:  ForeignKey [FK_Venues_CityId]    Script Date: 10/24/2012 20:33:57 ******/
ALTER TABLE [dbo].[Venues]  WITH CHECK ADD  CONSTRAINT [FK_Venues_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Venues] CHECK CONSTRAINT [FK_Venues_CityId]
GO
/****** Object:  ForeignKey [FK_Goals_SportId]    Script Date: 10/24/2012 20:33:57 ******/
ALTER TABLE [dbo].[Goals]  WITH CHECK ADD  CONSTRAINT [FK_Goals_SportId] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sports] ([Id])
GO
ALTER TABLE [dbo].[Goals] CHECK CONSTRAINT [FK_Goals_SportId]
GO
/****** Object:  ForeignKey [FK_Goals_UserCreatorId]    Script Date: 10/24/2012 20:33:57 ******/
ALTER TABLE [dbo].[Goals]  WITH CHECK ADD  CONSTRAINT [FK_Goals_UserCreatorId] FOREIGN KEY([UserCreatorId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Goals] CHECK CONSTRAINT [FK_Goals_UserCreatorId]
GO
/****** Object:  ForeignKey [FK_Goals_VenueId]    Script Date: 10/24/2012 20:33:57 ******/
ALTER TABLE [dbo].[Goals]  WITH CHECK ADD  CONSTRAINT [FK_Goals_VenueId] FOREIGN KEY([VenueId])
REFERENCES [dbo].[Venues] ([Id])
GO
ALTER TABLE [dbo].[Goals] CHECK CONSTRAINT [FK_Goals_VenueId]
GO
/****** Object:  ForeignKey [FK_UserGoals_GoalId]    Script Date: 10/24/2012 20:33:57 ******/
/* -- Removing Foreign Key for this table -- Letting the ORM take care of this constrain*/
ALTER TABLE [dbo].[UserGoals]  WITH CHECK ADD  CONSTRAINT [FK_UserGoals_GoalId] FOREIGN KEY([GoalId])
REFERENCES [dbo].[Goals] ([Id])
GO
ALTER TABLE [dbo].[UserGoals] CHECK CONSTRAINT [FK_UserGoals_GoalId]
GO

/****** Object:  ForeignKey [FK_UserGoals_UserId]    Script Date: 10/24/2012 20:33:57 ******/
/* -- Removing Foreign Key for this table -- Letting the ORM take care of this constrain*/
ALTER TABLE [dbo].[UserGoals]  WITH CHECK ADD  CONSTRAINT [FK_UserGoals_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserGoals] CHECK CONSTRAINT [FK_UserGoals_UserId]
GO
