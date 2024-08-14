﻿--tạo database
create database DBQL_NhaSach
go
--sử dụng database
use DBQL_NhaSach
go
--drop DATABASE DBQL_NhaSach
--tạo các bảng
create table LOAISACH
(
	MALOAISACH int PRIMARY KEY,
	LOAISACH nvarchar(MAX)
)

create table NHANVIEN
(
	MANV varchar(9) PRIMARY KEY,
	USERNAME varchar(MAX),
	MATKHAU varchar(MAX),
	HOTEN nvarchar(50),
	SDT char(10),
	DIACHI nvarchar(MAX),
	LaAdmin bit
)

create table SACH
(
	MASACH varchar(5) PRIMARY KEY,
	MALOAISACH int,
	TENSACH nvarchar(MAX),
	TENTACGIA nvarchar(MAX),
	NHAXUATBAN nvarchar(MAX),
	GIATIEN decimal(19,3),
	SLTK int,
	ANH nvarchar(MAX)
)

create table HOADONBAN
(
	MAHD varchar(14),
	MANV varchar(9),
	THOIGIAN datetime,
	TONGTIEN decimal(19,3),
	TRANGTHAI bit

	constraint PK_HOADONBAN primary key (MAHD)
)

create table CHITIET_HOADONBAN
(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	MAHD varchar(14),
	MASACH varchar(5),
	SL int,
	GIATIEN decimal(19,3),

	--constraint PK_CHITIET_HOADONBAN primary key (MAHD, MASACH)
)

create table HOADONNHAP
(
	MAHD varchar(14),
	MANV varchar(9),
	THOIGIAN datetime,
	TONGTIEN decimal(19,3),
	TRANGTHAI bit

	constraint PK_HOADONNHAP primary key (MAHD)
)

create table CHITIET_HOADONNHAP
(
	Id int IDENTITY(1, 1) PRIMARY KEY,
	MAHD varchar(14),
	MASACH varchar(5),
	SL int,
	GIATIEN decimal(19,3),

	--constraint PK_CHITIET_HOADONNHAP primary key (MAHD, MASACH)
)

set dateformat dmy

--tạo khoá ngoại

ALTER TABLE SACH
ADD CONSTRAINT  FK_SACH_LOAISACH
FOREIGN KEY (MALOAISACH)
REFERENCES LOAISACH(MALOAISACH)

ALTER TABLE CHITIET_HOADONBAN
ADD CONSTRAINT FK_CHITIET_HOADONBAN_SACH
FOREIGN KEY (MASACH)
REFERENCES SACH(MASACH)

ALTER TABLE CHITIET_HOADONNHAP
ADD CONSTRAINT FK_CHITIET_HOADONNHAP_SACH
FOREIGN KEY (MASACH)
REFERENCES SACH(MASACH)

ALTER TABLE CHITIET_HOADONBAN
ADD CONSTRAINT FK_CHITIET_HOADONBAN_HOADONBAN
FOREIGN KEY (MAHD)
REFERENCES HOADONBAN(MAHD)

ALTER TABLE CHITIET_HOADONNHAP
ADD CONSTRAINT FK_CHITIET_HOADONNHAP_HOADONNHAP
FOREIGN KEY (MAHD)
REFERENCES HOADONNHAP(MAHD)

ALTER TABLE HOADONBAN
ADD CONSTRAINT FK_HOADONBAN_NHANVIEN
FOREIGN KEY (MANV)
REFERENCES NHANVIEN(MANV)

ALTER TABLE HOADONNHAP
ADD CONSTRAINT FK_HOADONNHAP_NHANVIEN
FOREIGN KEY (MANV)
REFERENCES NHANVIEN(MANV)

--Rang buoc toan ven
ALTER TABLE CHITIET_HOADONBAN
ADD CONSTRAINT CHK_NonNegativeQuantity CHECK (SL >= 0);

ALTER TABLE NHANVIEN
ADD CONSTRAINT UQ_Username UNIQUE (USERNAME);

ALTER TABLE HOADONBAN
ADD CONSTRAINT DF_TRANGTHAI DEFAULT 0 FOR TRANGTHAI;

ALTER TABLE HOADONBAN
ADD CONSTRAINT THOI_GIAN_HOA_DON_BAN CHECK (THOIGIAN <= GETDATE())

CREATE TRIGGER TRIGER_HOADONBAN
ON CHITIET_HOADONBAN
AFTER INSERT, UPDATE
AS
BEGIN
	UPDATE HOADONBAN
	SET TONGTIEN = (SELECT SUM(SL*GIATIEN) FROM CHITIET_HOADONBAN WHERE CHITIET_HOADONBAN.MAHD = HOADONBAN.MAHD)
	FROM HOADONBAN
	INNER JOIN INSERTED ON HOADONBAN.MAHD = INSERTED.MAHD
END
GO

CREATE TRIGGER TRIGER_HOADONBAN
ON CHITIET_HOADONBAN
AFTER INSERT, UPDATE
AS
BEGIN
	UPDATE HOADONBAN
	SET TONGTIEN = (SELECT SUM(SL*GIATIEN) FROM CHITIET_HOADONBAN WHERE CHITIET_HOADONBAN.MAHD = HOADONBAN.MAHD)
	FROM HOADONBAN
	INNER JOIN INSERTED ON HOADONBAN.MAHD = INSERTED.MAHD
END
GO




--nạp dữ liệu nhân viên

insert into NHANVIEN (MANV, USERNAME, MATKHAU, HOTEN, SDT, DIACHI, LaAdmin) values ('NV001', 'nguyenvi123', '123456a@', N'Nguyễn Tuấn Vĩ', '0896677912' , 'TP HCM', 1)
insert into NHANVIEN (MANV, USERNAME, MATKHAU, HOTEN, SDT, DIACHI, LaAdmin) values ('NV002', 'tt', '123', N'Võ Thị Thanh Trúc', '0903024852' , 'TP HCM', 1)

--nạp dữ liệu loại sách

INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (1, N'Truyện tranh')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (2, N'Tâm lý học')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (3, N'Trinh thám')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (4, N'Tiểu thuyết')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (5, N'Văn học nước ngoài')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (6, N'Văn học Việt Nam')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (7, N'Kỹ năng sống')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (8, N'Truyện Ngắn')
INSERT [dbo].[LOAISACH] ([MALOAISACH], [LOAISACH]) VALUES (9, N'Kinh tế/Kinh doanh')

--nạp dữ liệu sách
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S01', 7, N'Đọc Suy Nghĩ, Thấu Tâm Can', N'Lư Văn Kiện', N'NXB Hồng Đức', CAST(160.000 AS Decimal(19, 3)), 1, N'20231210_110752.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S02', 7, N'Giao Tiếp Tự Tin Trong 1 Phút', N'Mike Bechtle', N'NXB Hồng Đức', CAST(148.000 AS Decimal(19, 3)), 10, N'20231210_111337.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S03', 4, N'Một Cuộc Đời Dang Dở: John F. Kennedy', N'Robert Dallek', N'Dân Trí', CAST(320.000 AS Decimal(19, 3)), 5, N'20231210_103809.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S04', 1, N'Sức Mạnh Của Sự Tử Tế', N'Linda Kaplan Thaler & Robin Koval', N'NXB Thế Giới', CAST(83.000 AS Decimal(19, 3)), 6, N'20231210_104033.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S05', 5, N'Chuyện Tình Yêu Loài Người', N'Cam (Write to death)', N'NXB Thế Giới', CAST(89.000 AS Decimal(19, 3)), 3, N'20231210_104451.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S06', 1, N'Vườn Tôi Có Cây Lá Bình Yên', N'Winlinh', N'NXB Thế Giới', CAST(135.000 AS Decimal(19, 3)), 3, N'20231210_104635.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S07', 6, N'Đất Rừng Phương Nam (Tái Bản Năm 2019)', N'Đoàn Giỏi', N'NXB Kim Đồng', CAST(82.000 AS Decimal(19, 3)), 5, N'20231210_105112.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S08', 1, N'Tranh Truyện Dân Gian Việt Nam - Cha Mẹ Nuôi Con Bẳng Trời Bằng Bể', N'Kim Seung Hyun & Hồng Hà', N'NXB Kim Đồng', CAST(15.000 AS Decimal(19, 3)), 2, N'20231210_105513.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S10', 8, N'Tô Hoài Tự Truyện', N'Tô Hoài', N'NXB Kim Đồng', CAST(100.000 AS Decimal(19, 3)), 5, N'20231210_105939')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S11', 8, N'Mười Năm', N'Tô Hoài', N'NXB Văn Học', CAST(75.000 AS Decimal(19, 3)), 3, N'20231210_105924')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S12', 8, N'Chuyện để quên', N'Tô Hoài', N'NXB Văn học', CAST(80.000 AS Decimal(19, 3)), 3, N'20231210_110020.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S13', 1, N'Mùa Hè Không Tên', N'Nguyễn Nhật Ánh', N'NXB Trẻ', CAST(230.000 AS Decimal(19, 3)), 5, N'20231210_110132.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S14', 1, N'Đi Qua Hoa Cúc (Tái bản năm 2022)', N'Nguyễn Nhật Ánh', N'NXB Trẻ', CAST(110.000 AS Decimal(19, 3)), 6, N'20231210_110320.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S15', 8, N'Khi Người Ta Lớn (Tái bản năm 2019)', N'Đỗ Hồng Ngọc', N'NXB Văn Hóa - Văn Nghệ', CAST(70.000 AS Decimal(19, 3)), 5, N'20231210_110626.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S16', 8, N'Áo Xưa Dù Nhàu...', N'Đỗ Hồng Ngọc', N'NXB Đà Nẵng', CAST(200.000 AS Decimal(19, 3)), 10, N'20231210_110607.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S17', 6, N'Gian Nan Tuổi Trẻ, Thảnh Thơi Tuổi Già', N'Trầm Bạch', N'NXB Hồng Đức', CAST(170.000 AS Decimal(19, 3)), 3, N'20231210_112619')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S18', 9, N'38 Lá Thư Rockefeller Gửi Cho Con Trai', N'Bizbooks', N'NXB Hồng Đức', CAST(158.000 AS Decimal(19, 3)), 3, N'20231210_112724.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S19', 9, N'Unlock IT: Mở Khóa Tài Chính, Làm Giàu Doanh Nghiệp', N'Dan Lok', N'NXB Hồng Đức', CAST(158.000 AS Decimal(19, 3)), 5, N'20231210_113030.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S20', 2, N'Thương Yêu Theo Phương Pháp Bụt Dạy', N'Nguyễn Lang (Thích Nhất Hạnh)', N'NXB Thế Giới', CAST(98.000 AS Decimal(19, 3)), 4, N'20231210_113452.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S21', 2, N'Con Gà Đẻ Trứng Vàng', N'Thich Nhat Hanh', N'NXB Hồng Đức', CAST(196.000 AS Decimal(19, 3)), 4, N'20231210_113704.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S22', 1, N'Nắng Tháng Tám (Nobel Văn học 1949 - Sách hay 2013) (Tái bản năm 2018)', N'William Faulkner', N'NXB Hội Nhà Văn', CAST(200.000 AS Decimal(19, 3)), 5, N'20231210_113854.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S23', 5, N'Người Đẹp Ngủ Mê (Tái bản năm 2023)', N'Kawabata Yasunari', N'NXB Hội Nhà Văn', CAST(102.000 AS Decimal(19, 3)), 4, N'20231210_114024.jpg')
INSERT [dbo].[SACH] ([MASACH], [MALOAISACH], [TENSACH], [TENTACGIA], [NHAXUATBAN], [GIATIEN], [SLTK], [ANH]) VALUES (N'S24', 4, N'Biên Niên Sử Về Khủng Long: Từ Tiến Hóa Tới Diệt Vong', N'Steve Brusatte', N'NXB Thế Giới', CAST(250.000 AS Decimal(19, 3)), 10, N'20231210_114147.jpg')



-- viết hàm xuất hóa đơn từ ngày đến ngày
create function GetDayToDay(@from datetime, @to datetime)
returns table
as
return
(select HOADONBAN.THOIGIAN,  SUM (CHITIET_HOADONBAN.GIATIEN*CHITIET_HOADONBAN.SL) as DOANHTHU
	FROM HOADONBAN, CHITIET_HOADONBAN
	WHERE HOADONBAN.THOIGIAN >= @from and HOADONBAN.THOIGIAN <= @to
	and HOADONBAN.MAHD = CHITIET_HOADONBAN.MAHD
	GROUP BY HOADONBAN.THOIGIAN)
go

-- viết hàm truyền vào 1 ngày lấy ra doanh thu của ngày đó
CREATE FUNCTION GetDay
(
    @day datetime
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        HOADONBAN.THOIGIAN,
        SUM(CHITIET_HOADONBAN.GIATIEN * CHITIET_HOADONBAN.SL) AS DOANHTHU
    FROM
        HOADONBAN
    INNER JOIN
        CHITIET_HOADONBAN ON HOADONBAN.MAHD = CHITIET_HOADONBAN.MAHD
    WHERE
        HOADONBAN.THOIGIAN >= @day
        AND HOADONBAN.THOIGIAN < DATEADD(DAY, 1, @day) -- Lấy tất cả các hóa đơn trong ngày đó
    GROUP BY
        HOADONBAN.THOIGIAN
)

