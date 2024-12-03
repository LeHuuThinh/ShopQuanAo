
-- Ctrl + A -> Execute để chạy hết

-- Diagram thì tạo diagram mới thêm hết bảng vào là nó tự nối -- 

USE [master]
GO
/****** Object:  Database [ShopQuanAo]    Script Date: 9/22/2024 11:00:48 PM ******/
CREATE DATABASE [ShopQuanAo]
GO
USE [ShopQuanAo]
GO
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
INSERT [dbo].[ChiTietPhieuNhap]([ID_Phieu],[Ma_SP],[Gia],[SoLuong],[ThanhTien]) VALUES (N'P11',N'A01',45000,4,180000)
INSERT [dbo].[ChiTietPhieuNhap]([ID_Phieu],[Ma_SP],[Gia],[SoLuong],[ThanhTien]) VALUES (N'P12',N'A03',50000,3,150000)
INSERT [dbo].[ChiTietPhieuNhap]([ID_Phieu],[Ma_SP],[Gia],[SoLuong],[ThanhTien]) VALUES (N'P13',N'A04',55000,2,110000)
INSERT [dbo].[ChiTietPhieuNhap]([ID_Phieu],[Ma_SP],[Gia],[SoLuong],[ThanhTien]) VALUES (N'P14',N'Q02',60000,5,300000)
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
---
USE [ShopQuanAo]
GO

/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/28/2024 9:03:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [ChiTietHoaDon] (
    [Ma_HD] [nvarchar](20) NOT NULL,
    [Ma_SP] [nvarchar](20) NOT NULL,
    [Ten_SP] [nvarchar](50) NOT NULL,
    [SoLuong] [int] NOT NULL,
    [ThanhTien] [nvarchar](20) NOT NULL,
    PRIMARY KEY ([Ma_HD], [Ma_SP]),
    FOREIGN KEY ([Ma_HD]) REFERENCES HoaDon([Ma_HD])
)


----
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD001',N'0112',N'01/02/2024',N'Quốc Huy',N'0123456789',N'01 Hẻm Ma Đạo',N'245000',N'15000',N'260000')
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD002',N'0113',N'04/10/2024',N'Hừng Vĩnh',N'0555567892',N'56 Ngô Quyền',N'400000',N'20000',N'420000')
INSERT [dbo].[HoaDon]([Ma_HD],[Ma_NV],[NgayLap],[KH],[SDT],[DiaChi],[TongTien],[PhiShip],[TongThanhToan]) VALUES (N'HD003',N'0112',N'21/12/2024',N'Chill Guy',N'0312666211',N'17 Tran lee',N'137000',N'13000',N'150000')
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
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q08',N'Quần gấu',50000,55000,7)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q09',N'Quần đùi',45000,50000,31)
INSERT [dbo].[MatHang]([Ma_SP],[Ten_SP],[GiaSi],[GiaLe],[SL_SP]) VALUES (N'Q10',N'Quần dài',35000,38000,13)
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
	[ThanhTien] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[ID_Phieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhieuNhap]([ID_Phieu],[Ma_NV],[Ma_NCC],[NgayNhap],[ThanhTien]) VALUES (N'P11',N'0111',N'CC01',12/11/2024,180000)
INSERT [dbo].[PhieuNhap]([ID_Phieu],[Ma_NV],[Ma_NCC],[NgayNhap],[ThanhTien]) VALUES (N'P12',N'0112',N'CC01',23/11/2024,150000)
INSERT [dbo].[PhieuNhap]([ID_Phieu],[Ma_NV],[Ma_NCC],[NgayNhap],[ThanhTien]) VALUES (N'P13',N'0111',N'CC01',09/12/2024,110000)
INSERT [dbo].[PhieuNhap]([ID_Phieu],[Ma_NV],[Ma_NCC],[NgayNhap],[ThanhTien]) VALUES (N'P14',N'0113',N'CC01',13/12/2024,300000)
/****** Object:  Table [dbo].[TaiKhoan]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](30) NOT NULL,
	[HoVaTenLot_NV] [nvarchar](30) Not NULL,
	[Ten_NV] [nvarchar](20) Not NULL,
	[CCCDNV] [int] NOT NULL,
	[SDT_NV] [int] NOT NULL,
	[NgaySinh_NV] [date] NOT NULL,
	[DiaChi_NV] [nvarchar](30) NOT NULL,
	[ChucVu] [nvarchar](20) NOT NULL
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
---
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[HoVaTenLot_NV],[Ten_NV],[CCCDNV],[SDT_NV],[NgaySinh_NV],[DiaChi_NV],[ChucVu]) VALUES (N'admin123',N'123456',N'Quản lý',N'A','0684666112','0975181818','2004-01-01',N'2/3 Hoàng Diệu',N'QuanLy')
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[HoVaTenLot_NV],[Ten_NV],[CCCDNV],[SDT_NV],[NgaySinh_NV],[DiaChi_NV],[ChucVu]) VALUES (N'nhanvien1',N'123456',N'Nhân viên',N'B','068076723','014888666','2004-05-06',N'7 Hai Bà Trưng',N'NhanVien')
INSERT [dbo].[TaiKhoan]([TenDangNhap],[MatKhau],[HoVaTenLot_NV],[Ten_NV],[CCCDNV],[SDT_NV],[NgaySinh_NV],[DiaChi_NV],[ChucVu]) VALUES (N'nhanvien2',N'123456',N'Nhân viên',N'C','0682346112','039393955','2004-09-03',N'10 Trần Lê',N'NhanVien')


SELECT * FROM [TaiKhoan]
----



USE [master]
GO
ALTER DATABASE [ShopQuanAo] SET  READ_WRITE 
GO
----
/****** Thêm tài khoản ******/
CREATE PROCEDURE [InsertAccount]
    @tenDangNhap nvarchar(30) OUTPUT,
    @matKhau nvarchar(30),
    @hoVaTenLot_nv nvarchar(30),
    @ten_nv nvarchar(20),
    @sdt_nv int,
    @cccdnv int,
    @ngaySinh_nv date,
    @diaChi_nv nvarchar(30),
    @chucVu nvarchar(20)
AS
BEGIN
    INSERT INTO [TaiKhoan]
    ([TenDangNhap], [MatKhau], [HoVaTenLot_NV], [Ten_NV], [SDT_NV], [CCCDNV], [NgaySinh_NV], [DiaChi_NV], [ChucVu])
    VALUES
    (@tenDangNhap, @matKhau, @hoVaTenLot_nv, @ten_nv, @sdt_nv, @cccdnv, @ngaySinh_nv, @diaChi_nv, @chucVu);

END

/****** sửa tài khoản ******/
CREATE PROCEDURE [UpdateAccount]
	@tenDangNhap nvarchar(30) OUTPUT,
	@matKhau nvarchar(30),
    @hoVaTenLot_nv nvarchar(30),
    @ten_nv nvarchar(20),
    @sdt_nv int,
    @cccdnv int,
	@ngaySinh_nv date,
    @diaChi_nv nvarchar(30),
    @chucVu nvarchar(20)
AS
UPDATE [TaiKhoan]
SET
	[MatKhau] = @matKhau,
	[HoVaTenLot_NV] = @hoVaTenLot_nv,
	[Ten_NV] = @ten_nv,
	[SDT_NV] = @sdt_nv,
	[CCCDNV] =@cccdnv,
	[NgaySinh_NV] = @ngaySinh_nv,
	[DiaChi_NV] = @diaChi_nv,
	[ChucVu] = @chucVu
WHERE TenDangNhap = @tenDangNhap

IF @@ERROR <> 0
RETURN 0
ELSE
RETURN 1
GO
/****** xóa tài khoản ******/
CREATE PROCEDURE [DeleteAccount]
    @tenDangNhap NVARCHAR(30)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY

        DELETE FROM TaiKhoan
        WHERE TenDangNhap = @tenDangNhap;


        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Account with TenDangNhap %s does not exist.', 16, 1, @tenDangNhap);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
