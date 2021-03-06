USE [master]
GO
/****** Object:  Database [gestion_projet_mvc]    Script Date: 07/12/2018 15:14:43 ******/
CREATE DATABASE [gestion_projet_mvc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gestion_projet_mvc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\gestion_projet_mvc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gestion_projet_mvc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\gestion_projet_mvc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [gestion_projet_mvc] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gestion_projet_mvc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gestion_projet_mvc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET ARITHABORT OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gestion_projet_mvc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gestion_projet_mvc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gestion_projet_mvc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gestion_projet_mvc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gestion_projet_mvc] SET  MULTI_USER 
GO
ALTER DATABASE [gestion_projet_mvc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gestion_projet_mvc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gestion_projet_mvc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gestion_projet_mvc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gestion_projet_mvc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [gestion_projet_mvc] SET QUERY_STORE = OFF
GO
USE [gestion_projet_mvc]
GO
/****** Object:  Table [dbo].[AssocExiTache]    Script Date: 07/12/2018 15:14:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssocExiTache](
	[id_exigence] [int] NOT NULL,
	[id_tache] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exigence]    Script Date: 07/12/2018 15:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exigence](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[libelle] [varchar](50) NULL,
	[id_projet] [int] NOT NULL,
 CONSTRAINT [PK_Exigence] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jalon]    Script Date: 07/12/2018 15:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jalon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
	[date_livraison] [date] NOT NULL,
	[date_reelle] [date] NULL,
	[id_projet] [int] NOT NULL,
	[id_responsable] [int] NOT NULL,
 CONSTRAINT [PK_Jalon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libelle]    Script Date: 07/12/2018 15:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libelle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Libelle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projet]    Script Date: 07/12/2018 15:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trigramme] [varchar](50) NOT NULL,
	[id_utilisateur] [int] NOT NULL,
 CONSTRAINT [PK_Projet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tache]    Script Date: 07/12/2018 15:14:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[date_debut] [date] NOT NULL,
	[date_reelle_debut] [date] NULL,
	[duree] [int] NOT NULL,
	[id_tache_precente] [int] NULL,
	[id_responsable] [int] NOT NULL,
	[id_jalon] [int] NOT NULL,
	[avancement] [int] NULL,
 CONSTRAINT [PK_Tache] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 07/12/2018 15:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trigramme] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tache] ADD  CONSTRAINT [DF_Tache_avancement]  DEFAULT ((0)) FOR [avancement]
GO
ALTER TABLE [dbo].[AssocExiTache]  WITH CHECK ADD  CONSTRAINT [FK_AssocExiTache_Exigence] FOREIGN KEY([id_exigence])
REFERENCES [dbo].[Exigence] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssocExiTache] CHECK CONSTRAINT [FK_AssocExiTache_Exigence]
GO
ALTER TABLE [dbo].[AssocExiTache]  WITH CHECK ADD  CONSTRAINT [FK_AssocExiTache_Tache] FOREIGN KEY([id_tache])
REFERENCES [dbo].[Tache] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssocExiTache] CHECK CONSTRAINT [FK_AssocExiTache_Tache]
GO
ALTER TABLE [dbo].[Exigence]  WITH CHECK ADD  CONSTRAINT [FK_Exigence_Projet] FOREIGN KEY([id_projet])
REFERENCES [dbo].[Projet] ([id])
GO
ALTER TABLE [dbo].[Exigence] CHECK CONSTRAINT [FK_Exigence_Projet]
GO
ALTER TABLE [dbo].[Jalon]  WITH CHECK ADD  CONSTRAINT [FK_Jalon_Projet] FOREIGN KEY([id_projet])
REFERENCES [dbo].[Projet] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jalon] CHECK CONSTRAINT [FK_Jalon_Projet]
GO
ALTER TABLE [dbo].[Jalon]  WITH CHECK ADD  CONSTRAINT [FK_Jalon_Utilisateur] FOREIGN KEY([id_responsable])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Jalon] CHECK CONSTRAINT [FK_Jalon_Utilisateur]
GO
ALTER TABLE [dbo].[Projet]  WITH CHECK ADD  CONSTRAINT [FK_Projet_Utilisateur] FOREIGN KEY([id_utilisateur])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Projet] CHECK CONSTRAINT [FK_Projet_Utilisateur]
GO
ALTER TABLE [dbo].[Tache]  WITH CHECK ADD  CONSTRAINT [FK_Tache_Jalon] FOREIGN KEY([id_jalon])
REFERENCES [dbo].[Jalon] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tache] CHECK CONSTRAINT [FK_Tache_Jalon]
GO
ALTER TABLE [dbo].[Tache]  WITH CHECK ADD  CONSTRAINT [FK_Tache_Utilisateur] FOREIGN KEY([id_responsable])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Tache] CHECK CONSTRAINT [FK_Tache_Utilisateur]
GO
USE [master]
GO
ALTER DATABASE [gestion_projet_mvc] SET  READ_WRITE 
GO
