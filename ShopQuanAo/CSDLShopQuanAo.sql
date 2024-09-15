create database ShopQuanAo
go
use ShopQuanAo
go

USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/15/2024 10:41:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KhachHang](
	[ID_KH] [int] NOT NULL,
	[HoTen_KH] [nvarchar](100) NOT NULL,
	[SDT_KH] [nvarchar](15) NOT NULL,
	[Dia_Chi] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID_KH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[DanhMuc]    Script Date: 9/13/2024 9:19:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DanhMuc](
	[ID_DM] [int] NOT NULL,
	[Ten_DM] [nvarchar](50) NOT NULL,
	[MieuTa_DM] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[ID_DM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[SanPham]    Script Date: 9/15/2024 10:40:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SanPham](
	[ID_SP] [int] NOT NULL,
	[Ten_SP] [nvarchar](50) NOT NULL,
	[Gia_SP] [int] NOT NULL,
	[TonKho] [int] NOT NULL,
	[ID_DM] [int] NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMuc] FOREIGN KEY([ID_DM])
REFERENCES [dbo].[DanhMuc] ([ID_DM])
GO

ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMuc]
GO




USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[HoaDon]    Script Date: 9/15/2024 10:38:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HoaDon](
	[ID_HD] [int] NOT NULL,
	[ID_KH] [int] NOT NULL,
	[SDT_KH] [nvarchar](15) NOT NULL,
	[Dia_Chi] [nvarchar](100) NOT NULL,
	[ID_SP] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[GiaTien] [int] NOT NULL,
	[Voucher] [nvarchar](10) NOT NULL,
	[TongTien] [int] NOT NULL,
	[ID_NV] [int] NOT NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[ID_HD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([ID_KH])
REFERENCES [dbo].[KhachHang] ([ID_KH])
GO

ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO

ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([ID_NV])
REFERENCES [dbo].[NhanVien] ([ID_NV])
GO

ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO

ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_SanPham] FOREIGN KEY([ID_SP])
REFERENCES [dbo].[SanPham] ([ID_SP])
GO

ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_SanPham]
GO




USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[NhanVien]    Script Date: 9/15/2024 10:39:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NhanVien](
	[ID_NV] [int] NOT NULL,
	[HoTen_NV] [nvarchar](100) NOT NULL,
	[NgaySinh_NV] [datetime] NOT NULL,
	[SDT_NV] [nvarchar](15) NOT NULL,
	[Gmail_NV] [nvarchar](50) NOT NULL,
	[NgayVaoLam_NV] [datetime] NOT NULL,
	[TrangThai_NV] [nchar](50) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID_NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






