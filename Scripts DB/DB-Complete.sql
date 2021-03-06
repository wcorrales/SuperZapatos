USE [master]
GO
/****** Object:  Database [gap-super_zapatos]    Script Date: 01/27/2017 12:24:01 p.m. ******/
CREATE DATABASE [gap-super_zapatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gap-super_zapatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ROBERTO\MSSQL\DATA\gap-super_zapatos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gap-super_zapatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ROBERTO\MSSQL\DATA\gap-super_zapatos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [gap-super_zapatos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gap-super_zapatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gap-super_zapatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [gap-super_zapatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gap-super_zapatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gap-super_zapatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gap-super_zapatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gap-super_zapatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET RECOVERY FULL 
GO
ALTER DATABASE [gap-super_zapatos] SET  MULTI_USER 
GO
ALTER DATABASE [gap-super_zapatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gap-super_zapatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gap-super_zapatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gap-super_zapatos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gap-super_zapatos', N'ON'
GO
USE [gap-super_zapatos]
GO
/****** Object:  Table [dbo].[articles]    Script Date: 01/27/2017 12:24:02 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[total_in_shelf] [int] NOT NULL,
	[total_in_vault] [int] NOT NULL,
	[store_id] [int] NOT NULL,
 CONSTRAINT [PK_articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stores]    Script Date: 01/27/2017 12:24:02 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[articles]  WITH CHECK ADD  CONSTRAINT [FK_articles_stores] FOREIGN KEY([store_id])
REFERENCES [dbo].[stores] ([id])
GO
ALTER TABLE [dbo].[articles] CHECK CONSTRAINT [FK_articles_stores]
GO
USE [master]
GO
ALTER DATABASE [gap-super_zapatos] SET  READ_WRITE 
GO
