USE [master]
GO
/****** Object:  Database [Zorrito]    Script Date: 22/04/2023 11:59:35 ******/
CREATE DATABASE [Zorrito]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Zorrito', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Zorrito.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Zorrito_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Zorrito_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Zorrito] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Zorrito].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Zorrito] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Zorrito] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Zorrito] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Zorrito] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Zorrito] SET ARITHABORT OFF 
GO
ALTER DATABASE [Zorrito] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Zorrito] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Zorrito] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Zorrito] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Zorrito] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Zorrito] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Zorrito] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Zorrito] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Zorrito] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Zorrito] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Zorrito] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Zorrito] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Zorrito] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Zorrito] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Zorrito] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Zorrito] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Zorrito] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Zorrito] SET RECOVERY FULL 
GO
ALTER DATABASE [Zorrito] SET  MULTI_USER 
GO
ALTER DATABASE [Zorrito] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Zorrito] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Zorrito] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Zorrito] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Zorrito] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Zorrito] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Zorrito', N'ON'
GO
ALTER DATABASE [Zorrito] SET QUERY_STORE = OFF
GO
USE [Zorrito]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[IdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](100) NULL,
	[Tematica] [nvarchar](200) NULL,
	[FechaEntrega] [date] NULL,
	[Pedido] [nvarchar](300) NULL,
	[Total] [decimal](18, 2) NULL,
	[Importe] [decimal](18, 2) NULL,
	[Faltante] [decimal](18, 2) NULL,
	[Comentarios] [nvarchar](200) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[CodigoArticulo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Marca] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](150) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[NombreNinoNina] [nvarchar](50) NULL,
	[FechaCumpleanos] [date] NULL,
	[AnosCumplidos] [int] NULL,
	[Localidad] [nvarchar](50) NULL,
	[Celular] [bigint] NULL,
	[FechaAlta] [date] NULL,
	[Comentarios] [nvarchar](150) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComposicionProductos]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComposicionProductos](
	[IdComposicionProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[CodigoArticulo] [nvarchar](50) NULL,
	[CantidadMateriaPrima] [decimal](18, 2) NULL,
	[Costo] [decimal](18, 2) NULL,
	[CostoTotal] [decimal](18, 2) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComposicionProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[CodigoArticulo] [nvarchar](50) NULL,
	[Fecha] [date] NULL,
	[Marca] [nvarchar](50) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](150) NULL,
	[CantidadPorBulto] [int] NULL,
	[PrecioBulto] [decimal](18, 2) NULL,
	[PrecioUnitario] [decimal](18, 2) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVentas]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVentas](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[Idproducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](18, 2) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[PrecioVenta] [decimal](18, 2) NULL,
	[Descripcion] [nvarchar](150) NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[CodigoArticulo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Marca] [nvarchar](50) NULL,
	[IngresoStock] [decimal](18, 0) NULL,
	[EgresoStock] [decimal](18, 0) NULL,
	[StockActual] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 22/04/2023 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Fecha] [date] NULL,
	[BajaLogica] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComposicionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ComposicionProductos_CodigoArticulo] FOREIGN KEY([CodigoArticulo])
REFERENCES [dbo].[Articulos] ([CodigoArticulo])
GO
ALTER TABLE [dbo].[ComposicionProductos] CHECK CONSTRAINT [FK_ComposicionProductos_CodigoArticulo]
GO
ALTER TABLE [dbo].[ComposicionProductos]  WITH CHECK ADD  CONSTRAINT [FK_ComposicionProductos_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ComposicionProductos] CHECK CONSTRAINT [FK_ComposicionProductos_IdProducto]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_CodigoArticulo] FOREIGN KEY([CodigoArticulo])
REFERENCES [dbo].[Articulos] ([CodigoArticulo])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_CodigoArticulo]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVentas_Idproducto] FOREIGN KEY([Idproducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVentas] CHECK CONSTRAINT [FK_DetalleVentas_Idproducto]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVentas_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVentas] CHECK CONSTRAINT [FK_DetalleVentas_IdVenta]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_CodigoArticulo] FOREIGN KEY([CodigoArticulo])
REFERENCES [dbo].[Articulos] ([CodigoArticulo])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_CodigoArticulo]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_IdCliente]
GO
USE [master]
GO
ALTER DATABASE [Zorrito] SET  READ_WRITE 
GO
