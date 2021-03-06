USE [master]
GO
/****** Object:  Database [PRN231_Blog]    Script Date: 01/07/2022 10:57:57 ******/
CREATE DATABASE [PRN231_Blog] ON  PRIMARY 
( NAME = N'PRN231_Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PRN231_Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN231_Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PRN231_Blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN231_Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN231_Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN231_Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN231_Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN231_Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN231_Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN231_Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN231_Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN231_Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN231_Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN231_Blog] SET  MULTI_USER 
GO
ALTER DATABASE [PRN231_Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN231_Blog] SET DB_CHAINING OFF 
GO
USE [PRN231_Blog]
GO
/****** Object:  Table [dbo].[category]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](150) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[authorId] [int] NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](100) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[summary] [nvarchar](255) NULL,
	[published] [int] NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_category]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_category](
	[postId] [int] NULL,
	[categoryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_comment]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postId] [int] NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](150) NULL,
	[published] [int] NULL,
	[createdAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_meta]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_meta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postId] [int] NULL,
	[key] [nvarchar](100) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post_meta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_tag]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_tag](
	[postId] [int] NULL,
	[tagId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tag]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 01/07/2022 10:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[middleName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[passwordHash] [nvarchar](50) NULL,
	[registeredAt] [datetime] NULL,
	[lastLogin] [datetime] NULL,
	[intro] [nvarchar](255) NULL,
	[proflie] [nvarchar](max) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [FK_post_user] FOREIGN KEY([authorId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_post_user]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_category]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_post]
GO
ALTER TABLE [dbo].[post_comment]  WITH CHECK ADD  CONSTRAINT [FK_post_comment_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_comment] CHECK CONSTRAINT [FK_post_comment_post]
GO
ALTER TABLE [dbo].[post_meta]  WITH CHECK ADD  CONSTRAINT [FK_post_meta_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_meta] CHECK CONSTRAINT [FK_post_meta_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_tag] FOREIGN KEY([tagId])
REFERENCES [dbo].[tag] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_tag]
GO
USE [master]
GO
ALTER DATABASE [PRN231_Blog] SET  READ_WRITE 
GO
