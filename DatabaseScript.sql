USE [master]
GO
/****** Object:  Database [AuthenticationAndAuthorization]    Script Date: 7/26/2022 3:36:42 PM ******/
CREATE DATABASE [AuthenticationAndAuthorization]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuthenticationAndAuthorization', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AuthenticationAndAuthorization.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuthenticationAndAuthorization_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AuthenticationAndAuthorization_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuthenticationAndAuthorization].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET RECOVERY FULL 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET  MULTI_USER 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AuthenticationAndAuthorization', N'ON'
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET QUERY_STORE = OFF
GO
USE [AuthenticationAndAuthorization]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AuthenticationAndAuthorization]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/26/2022 3:36:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/26/2022 3:36:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[InsertDateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AuthenticationAndAuthorization] SET  READ_WRITE 
GO
