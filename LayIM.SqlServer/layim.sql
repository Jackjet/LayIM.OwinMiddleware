USE [master]
GO
/****** Object:  Database [LayIM]    Script Date: 06/09/2017 17:58:52 ******/
CREATE DATABASE [LayIM] ON  PRIMARY 
( NAME = N'LayIM', FILENAME = N'D:\Microsoft SQL Server\LayIM.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LayIM_log', FILENAME = N'D:\Microsoft SQL Server\LayIM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LayIM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LayIM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LayIM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LayIM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LayIM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LayIM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LayIM] SET ARITHABORT OFF
GO
ALTER DATABASE [LayIM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [LayIM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LayIM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LayIM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LayIM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LayIM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LayIM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LayIM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LayIM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LayIM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LayIM] SET  DISABLE_BROKER
GO
ALTER DATABASE [LayIM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LayIM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LayIM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LayIM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LayIM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LayIM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LayIM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LayIM] SET  READ_WRITE
GO
ALTER DATABASE [LayIM] SET RECOVERY FULL
GO
ALTER DATABASE [LayIM] SET  MULTI_USER
GO
ALTER DATABASE [LayIM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LayIM] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'LayIM', N'ON'
GO
USE [LayIM]
GO
/****** Object:  Schema [LayIM]    Script Date: 06/09/2017 17:58:52 ******/
CREATE SCHEMA [LayIM] AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[user]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[name] [varchar](10) NOT NULL,
	[sign] [varchar](100) NOT NULL,
	[avatar] [varchar](150) NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[friend_group_detail]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[friend_group_detail](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[group_id] [bigint] NOT NULL,
	[user_id] [bigint] NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_friend_group_detail] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[friend_group]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[friend_group](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[user_id] [bigint] NOT NULL,
	[name] [varchar](10) NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_friend_group] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chat_msg]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chat_msg](
	[pk_id] [uniqueidentifier] NOT NULL,
	[user_id] [bigint] NOT NULL,
	[room_id] [varchar](20) NOT NULL,
	[msg] [varchar](2000) NOT NULL,
	[create_at] [datetime] NOT NULL,
	[timestamp] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[big_group_detail]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[big_group_detail](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[group_id] [bigint] NOT NULL,
	[user_id] [bigint] NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_big_group_detail] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[big_group]    Script Date: 06/09/2017 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[big_group](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[avatar] [varchar](200) NOT NULL,
	[description] [varchar](200) NULL,
	[owner_id] [bigint] NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_big_group] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_user_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
/****** Object:  Default [DF_friend_group_detail_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[friend_group_detail] ADD  CONSTRAINT [DF_friend_group_detail_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
/****** Object:  Default [DF_friend_group_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[friend_group] ADD  CONSTRAINT [DF_friend_group_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
/****** Object:  Default [DF_chat_msg_pk_id]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[chat_msg] ADD  CONSTRAINT [DF_chat_msg_pk_id]  DEFAULT (newid()) FOR [pk_id]
GO
/****** Object:  Default [DF_chat_msg_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[chat_msg] ADD  CONSTRAINT [DF_chat_msg_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
/****** Object:  Default [DF_chat_msg_timestamp]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[chat_msg] ADD  CONSTRAINT [DF_chat_msg_timestamp]  DEFAULT ((0)) FOR [timestamp]
GO
/****** Object:  Default [DF_big_group_detail_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[big_group_detail] ADD  CONSTRAINT [DF_big_group_detail_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
/****** Object:  Default [DF_big_group_create_at]    Script Date: 06/09/2017 17:58:54 ******/
ALTER TABLE [dbo].[big_group] ADD  CONSTRAINT [DF_big_group_create_at]  DEFAULT (getdate()) FOR [create_at]
GO
