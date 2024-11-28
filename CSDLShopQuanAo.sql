﻿
-- Ctrl + A -> Execute để chạy hết

-- Diagram thì tạo diagram mới thêm hết bảng vào là nó tự nối -- 

USE [master]
GO
/****** Object:  Database [ShopQuanAo]    Script Date: 9/22/2024 11:00:48 PM ******/
CREATE DATABASE [ShopQuanAo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopQuanAo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShopQuanAo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopQuanAo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShopQuanAo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopQuanAo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopQuanAo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopQuanAo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopQuanAo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopQuanAo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopQuanAo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopQuanAo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopQuanAo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShopQuanAo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopQuanAo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopQuanAo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopQuanAo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopQuanAo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopQuanAo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopQuanAo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopQuanAo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopQuanAo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopQuanAo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopQuanAo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopQuanAo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopQuanAo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopQuanAo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopQuanAo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopQuanAo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopQuanAo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopQuanAo] SET  MULTI_USER 
GO
ALTER DATABASE [ShopQuanAo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopQuanAo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopQuanAo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopQuanAo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopQuanAo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopQuanAo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopQuanAo] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopQuanAo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopQuanAo]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[Ma_HD] [nvarchar](20) NOT NULL,
	[Ma_SP] [nvarchar](20) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[Ma_HD] ASC,
	[Ma_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[ID_Phieu] [nvarchar](20) NOT NULL,
	[Ma_SP] [nvarchar](20) NOT NULL,
	[Gia] [nvarchar](20) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID_Phieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhSachNhanVien]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachNhanVien](
	[Ma_NV] [nvarchar](20) NOT NULL,
	[HoTenLot_NV] [nvarchar](30) NOT NULL,
	[Ten_NV] [nvarchar](20) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[CCCD] [nvarchar](20) NOT NULL,
	[SDT_NV] [nvarchar](20) NOT NULL,
	[DiaChi_NV] [nvarchar](50) NOT NULL,
	[NgayVaoLam] [datetime] NOT NULL,
 CONSTRAINT [PK_DanhSachNhanVien] PRIMARY KEY CLUSTERED 
(
	[Ma_NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 9/22/2024 11:00:48 PM ******/
USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/28/2024 2:53:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HoaDon](
	[Ma_HD] [nvarchar](20) NOT NULL,
	[Ma_NV] [nvarchar](20) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[KH] [nvarchar](30) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](20) NOT NULL,
	[TongTien] [nvarchar](20) NOT NULL,
	[PhiShip] [nvarchar](20) NOT NULL,
	[TongThanhToan] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[Ma_HD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


----
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD001',N'0112',N'01/02/2024',N'Quốc Huy',N'0123456789',N'01 Hẻm Ma Đạo',N'245000',N'15000',N'260000')
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD002',N'0113',N'04/10/2024',N'Hừng Vĩnh',N'0555567892',N'56 Ngô Quyền',N'400000',N'20000',N'420000')
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD003',N'0112',N'21/12/2024',N'Chill Guy',N'0312666211',N'17 Phan Đình Phùng',N'137000',N'13000',N'150000')
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD004',N'0111',N'11/28/2024',N'Thịnh Lễ Hưu',N'09885426461',N'23 Hai Bà Trừng',N'430000',N'23000',N'453000')

SELECT * FROM [HoaDon]




/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Ma_KH] [nvarchar](20) NOT NULL,
	[HoVaTen] [nvarchar](50) NOT NULL,
	[SDT_KH] [nvarchar](20) NOT NULL,
	[DiaChi_KH] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[Ma_KH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHang](
	[Ma_SP] [nvarchar](20) NOT NULL,
	[Ten_SP] [nvarchar](50) NOT NULL,
	[GiaSi] [nvarchar](20) NOT NULL,
	[GiaLe] [nvarchar](20) NOT NULL,
	[SL_SP] [int] NOT NULL,
 CONSTRAINT [PK_MatHang] PRIMARY KEY CLUSTERED 
(
	[Ma_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
---
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A01',N'Áo ba lỗ',50000,55000,1)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A03',N'Áo tay ngắn',55000,60000,1)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A04',N'Áo tay dài',60000,65000,1)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q02',N'Quần què',65000,70000,1)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q05',N'Quần jean rách',70000,75000,1)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q06',N'Quần thể dục',80000,87000,5)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q07',N'Quần boy phố',70000,75000,11)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A05',N'Áo capybara',100000,120000,22)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A06',N'Áo quân đội',150000,165000,3)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A08',N'Áo hoodie',125000,132000,36)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A10',N'Áo caro',75000,80000,15)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q07',N'Quần gấu',50000,55000,7)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q07',N'Quần đùi',45000,50000,31)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q07',N'Quần dài',35000,38000,13)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'A11',N'Áo siêu nhân',195000,210000,44)

SELECT * FROM [MatHang]

/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[Ma_NCC] [nvarchar](20) NOT NULL,
	[Ten_NCC] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[Ma_NCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[NhomMatHang]    Script Date: 11/28/2024 4:14:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NhomMatHang](
	[MaNhom] [nvarchar](20) NOT NULL,
	[TenNhom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NhomMatHang] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[NhomMatHang]([MaNhom],[TenNhom]) VALUES (N'M001',N'Áo xịn xò')
INSERT [dbo].[NhomMatHang]([MaNhom],[TenNhom]) VALUES (N'M002',N'Áo tiktok')
INSERT [dbo].[NhomMatHang]([MaNhom],[TenNhom]) VALUES (N'M003',N'Quần xịn xò')
INSERT [dbo].[NhomMatHang]([MaNhom],[TenNhom]) VALUES (N'M004',N'Quần nhập khẩu')
INSERT [dbo].[NhomMatHang]([MaNhom],[TenNhom]) VALUES (N'M005',N'Một mảnh')

SELECT * FROM [NhomMatHang]

/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[ID_Phieu] [nvarchar](20) NOT NULL,
	[Ma_NV] [nvarchar](20) NOT NULL,
	[Ma_NCC] [nvarchar](20) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TienHang] [nvarchar](20) NOT NULL,
	[PhiShip] [nvarchar](20) NOT NULL,
	[TienThue] [nvarchar](20) NOT NULL,
	[ChiPhiKhac] [nvarchar](20) NOT NULL,
	[ThanhTien] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID_Phieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 9/22/2024 11:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](30) NOT NULL,
	[ChucVu] [nvarchar](20) NOT NULL,
	[Ma_NV] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Ma_NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
---
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[ChucVu],[Ma_NV]) VALUES (N'admin123',N'123456',N'QuanLy',N'0111')
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[ChucVu],[Ma_NV]) VALUES (N'baoquan1',N'quan123',N'NhanVien',N'0112')
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[ChucVu],[Ma_NV]) VALUES (N'huutruong1',N'truong123',N'NhanVien',N'0113')

SELECT * FROM [TaiKhoan]
----


ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([Ma_HD])
REFERENCES [dbo].[HoaDon] ([Ma_HD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_MatHang] FOREIGN KEY([Ma_SP])
REFERENCES [dbo].[MatHang] ([Ma_SP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_MatHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_DanhSachNhanVien] FOREIGN KEY([Ma_NV])
REFERENCES [dbo].[DanhSachNhanVien] ([Ma_NV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_DanhSachNhanVien]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([Ma_KH])
REFERENCES [dbo].[KhachHang] ([Ma_KH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_DanhSachNhanVien] FOREIGN KEY([Ma_NV])
REFERENCES [dbo].[DanhSachNhanVien] ([Ma_NV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_DanhSachNhanVien]
GO
USE [master]
GO
ALTER DATABASE [ShopQuanAo] SET  READ_WRITE 
GO
----

