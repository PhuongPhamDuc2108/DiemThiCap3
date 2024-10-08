USE [QLDiemThiCap3]
GO
/****** Object:  Table [dbo].[tBan]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBan](
	[MaGV] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](50) NOT NULL,
	[MaLop] [nvarchar](50) NOT NULL,
	[SoTiet] [int] NOT NULL,
 CONSTRAINT [PK_tBan] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC,
	[MaMH] ASC,
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDiem]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDiem](
	[TenMH] [nvarchar](50) NOT NULL,
	[MaHS] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](50) NOT NULL,
	[DiemHS1] [float] NULL,
	[DiemHS2] [float] NULL,
	[DiemHS3] [float] NULL,
	[DTBTong] [float] NULL,
	[XepLoai] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tGiaoVien]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGiaoVien](
	[MaGV] [nvarchar](50) NOT NULL,
	[TenGV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](50) NULL,
	[GVCN] [nvarchar](50) NULL,
 CONSTRAINT [PK_tGiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHocSinh]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHocSinh](
	[MaHS] [nvarchar](50) NOT NULL,
	[TenHS] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[MaLop] [nvarchar](50) NOT NULL,
	[XepLoai] [nvarchar](50) NULL,
	[DTB] [float] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tHocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLop]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLop](
	[MaLop] [nvarchar](50) NOT NULL,
	[TenLop] [nvarchar](50) NOT NULL,
	[GVCN] [nvarchar](50) NULL,
 CONSTRAINT [PK_tLop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMonHoc]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMonHoc](
	[MaMH] [nvarchar](50) NOT NULL,
	[TenMH] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tMonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUserLogIn]    Script Date: 8/28/2024 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUserLogIn](
	[userName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[ChucVu] [nvarchar](20) NULL,
 CONSTRAINT [PK_tUserLogIn] PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
Create TRIGGER TinhDiemTB
ON tDiem
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @MaHS NVARCHAR(50);
    
    -- Use separate SELECT statements for INSERTED and DELETED tables
    -- Prioritize INSERTED over DELETED to ensure the latest update is captured
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        SELECT TOP 1 @MaHS = MaHS FROM inserted;
    END
    ELSE IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        SELECT TOP 1 @MaHS = MaHS FROM deleted;
    END

    -- Calculate the average score for the student
    DECLARE @DTB FLOAT;
    SELECT @DTB = AVG(DiemHS1 * 1.0 + DiemHS2 * 2.0 + DiemHS3 * 3.0) / 6.0
    FROM tDiem
    WHERE MaHS = @MaHS;

    -- Determine the classification based on the average score
    DECLARE @XepLoai NVARCHAR(50);
    IF @DTB >= 8.5
        SET @XepLoai = 'Gioi';
    ELSE IF @DTB >= 7.0
        SET @XepLoai = 'Kha';
    ELSE IF @DTB >= 5.5
        SET @XepLoai = 'Trung Binh';
    ELSE IF @DTB >= 4.0
        SET @XepLoai = 'Yeu';
    ELSE
        SET @XepLoai = 'Kem';

    -- Update the student's average score and classification in the tHocSinh table
    UPDATE tHocSinh
    SET DTB = @DTB, XepLoai = @XepLoai
    WHERE MaHS = @MaHS;
END;
GO
drop trigger TinhDiemTB
