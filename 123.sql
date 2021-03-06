USE [master]
GO
/****** Object:  Database [SportShop]    Script Date: 5/3/2022 16:13:41 ******/
CREATE DATABASE [SportShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SportShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SportShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SportShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SportShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SportShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SportShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SportShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SportShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SportShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [SportShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SportShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SportShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SportShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SportShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SportShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SportShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SportShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SportShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SportShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SportShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SportShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SportShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SportShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SportShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SportShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SportShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SportShop] SET RECOVERY FULL 
GO
ALTER DATABASE [SportShop] SET  MULTI_USER 
GO
ALTER DATABASE [SportShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SportShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SportShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SportShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SportShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SportShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SportShop', N'ON'
GO
ALTER DATABASE [SportShop] SET QUERY_STORE = OFF
GO
USE [SportShop]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/3/2022 16:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Cost] [money] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[isActive] [bit] NOT NULL,
	[MainImagePath] [nvarchar](1000) NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSale]    Script Date: 5/3/2022 16:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NOT NULL,
	[price] [money] NOT NULL,
	[date] [date] NOT NULL,
	[count] [int] NOT NULL,
 CONSTRAINT [PK_ProductSale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2022 16:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (1, N'Футболка мужская Outventure', 879.0000, N'Создайте комфортный летний образ с футболкой Outventure', 1, N'C:\TovarSport\62907640299.jpg', N'Футболки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (2, N'Футболка мужская Columbia Timber Point', 1999.0000, N'Футболка Columbia — то что нужно для летних путешествий и прогулок.', 1, NULL, N'Футболки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (5, N'Худи мужская Merrell
', 3639.0000, N'Комфортная худи Merrell — удачный дополнит выбор для путешествия', 0, NULL, N'Толстовки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (6, N'Брюки мужские Columbia Washed Out Pant', 3899.0000, N'Легкие брюки Columbia — незаменимая вещь во время путешествий в теплое время года.', 1, NULL, N'Брюки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (7, N'Брюки мужские Outventure', 3439.0000, N'Практичные брюки Outventure отлично дополнят походную экипировку.', 0, NULL, N'Брюки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (8, N'Перчатки Mountain Hardwear Cloud Shadow Gore-Tex Glove', 8599.0000, N'Легкие мембранные перчатки обеспечат комфорт и защитят от осадков. Мягкая и теплая флисовая подкладка приятна на ощупь. Ладонь выполнена из противоскользящего полиуретана. Модель позволяет работать с сенсорным экраном.', 1, NULL, N'Перчатки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (9, N'Перчатки мужские Columbia M Thermarator Glove', 2399.0000, N'Флисовые перчатки Thermarator от Columbia идеально подойдут для прогулок и активного отдыха в холодное время года. Технология Omni-Heat надежно защищает от холода. Текстурированное укрепление ладони и пальцев в местах наибольшего трения продлевает срок службы модели.', 1, NULL, N'Перчатки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (10, N'Бейсболка Northland', 1499.0000, N'Хлопковая бейсболка Northland пригодится для активного отдыха летом. Приятный на ощупь натуральный материал хорошо пропускает воздух.', 1, NULL, N'Головные уборы')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (13, N'Бейсболка IcePeak Hills
', 1599.0000, N'Хлопковая бейсболка IcePeak Hills станет хорошим решением для активного отдыха в теплую погоду. Натуральный материал отлично пропускает воздух. Модель оснащена регулируемым ремешком.', 0, NULL, N'Головные уборы')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (14, N'Худи мужская Columbia CSC Basic Logo II Hoodie, Plus Size', 6499.0000, N'Худи Columbia — превосходный выбор для путешествий.', 1, NULL, N'Толстовки')
INSERT [dbo].[Product] ([ID], [Title], [Cost], [Description], [isActive], [MainImagePath], [Category]) VALUES (15, N'Футболка AW', 1000.0000, N'', 1, NULL, N'Футболки')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSale] ON 

INSERT [dbo].[ProductSale] ([id], [id_product], [price], [date], [count]) VALUES (3, 6, 3899.0000, CAST(N'2022-05-03' AS Date), 1)
INSERT [dbo].[ProductSale] ([id], [id_product], [price], [date], [count]) VALUES (4, 8, 8599.0000, CAST(N'2022-05-03' AS Date), 1)
INSERT [dbo].[ProductSale] ([id], [id_product], [price], [date], [count]) VALUES (6, 1, 879.0000, CAST(N'2022-05-03' AS Date), 5)
INSERT [dbo].[ProductSale] ([id], [id_product], [price], [date], [count]) VALUES (7, 11, 0.0000, CAST(N'2022-05-03' AS Date), 3)
SET IDENTITY_INSERT [dbo].[ProductSale] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [login], [password], [Admin]) VALUES (1, N'Manager', N'123', 1)
INSERT [dbo].[Users] ([id], [login], [password], [Admin]) VALUES (3, N'Client', N'1234', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [SportShop] SET  READ_WRITE 
GO
