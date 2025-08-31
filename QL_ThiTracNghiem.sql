USE master
GO

CREATE DATABASE QL_THITRACNGHIEM
GO

USE QL_THITRACNGHIEM
GO

-------------------------------------------------------------------------------------------------
------------------------------------------- Tạo Table -------------------------------------------

--Bảng 'môn học'
CREATE TABLE MonHoc
(
	MaMon INT IDENTITY(1,1) not null,
	TenMon nvarchar(max) not null,
	SoTinChi int not null,
	Constraint PK_MonHoc Primary key (MaMon),
	Constraint CHK_MonHoc_SoTinChi check (SoTinChi BETWEEN 1 AND 3)
)
GO

CREATE TABLE CapDo
(
	MaCapDo INT IDENTITY(1,1) NOT NULL,
	TenCapDo NVARCHAR(50) not null,
	Constraint PK_CapDo PRIMARY KEY (MaCapDo)
)

--Bảng 'câu hỏi'
CREATE TABLE CauHoi
(
	MaCH INT IDENTITY(1,1) not null,
	MaMon INT not null,
	MaCapDo INT not null,
	NoiDung nvarchar(max) not null,
	Constraint PK_CauHoi Primary key (MaCH),
	Constraint FK_CauHoi_MonHoc Foreign key (MaMon) references MonHoc(MaMon),
	Constraint FK_CauHoi_CapDo Foreign key (MaCapDo) references CapDo(MaCapDo)
)
GO

--Bảng 'Đáp án'
CREATE TABLE DapAn
(
	MaDA INT IDENTITY(1,1) not null,
	MaCH INT not null,
	TenDA varchar(1) not null,
	NoiDung nvarchar(max) not null,
	DungSai bit not null DEFAULT 0, -- 1 là đúng, 0 là sai
	Constraint PK_DapAn Primary key (MaDA),
	Constraint FK_DapAn_CauHoi Foreign key (MaCH) references CauHoi(MaCH)
)
GO

--Bảng 'sinh viên'
CREATE TABLE SinhVien
(
	MaSV INT IDENTITY(1,1) not null,
	TenSV nvarchar(50) not null,
	NgaySinh date not null,
	Email varchar(50) not null,
	SDT varchar(20) not null,
	MatKhau varchar(100) not null,
	Constraint PK_SinhVien Primary key (MaSV),
	CONSTRAINT CHK_SinhVien_Email CHECK (Email LIKE '%@%.%' AND Email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_SinhVien_SDT CHECK (SDT LIKE '[0-9]%') -- Chỉ cho phép số bắt đầu bằng các chữ số 0-9
)
GO

--Bảng 'đề thi'
CREATE TABLE DeThi
(
	MaDT INT IDENTITY(1,1) not null,
	ThoiGianLam int not null,
	SoLuongCau int not null,
	NgayTao date not null,
	Constraint PK_DeThi Primary key (MaDT),
	Constraint CHK_DeThi_ThoiGianLam Check (ThoiGianLam BETWEEN 0 AND 180)
)
GO

--Bảng 'chi tiết đề thi'
CREATE TABLE ChiTietDeThi
(
	MaDT INT not null,
	MaCH INT not null,
	GhiChu nvarchar(max), -- Chỉ là mô tả thông tin thôi chứ ko cần thêm gì hết
	Constraint PK_ChiTietDeThi Primary key (MaDT, MaCH),
	Constraint FK_ChiTietDeThi_DeThi Foreign key (MaDT) references DeThi(MaDT),
	Constraint FK_ChiTietDeThi_CauHoi Foreign key (MaCH) references CauHoi(MaCH)
)
GO

-- Bảng 'Kỳ thi'
CREATE TABLE KyThi
(
	MaKyThi INT IDENTITY(1,1),
	HocKy INT not null,
	NamHoc int not null,
	TenHocKy nvarchar(50) not null,
	Constraint PK_KyThi primary key (MaKyThi)
)

-- Bảng 'kết quả'
CREATE TABLE KetQua
(
	MaSV INT not null,
	MaDT INT not null,
	MaKyThi int not null,
	SoCauDung int,
	SoCauSai int ,
	Diem Decimal(5,2),
	NgayHoanThanh date,
	Constraint PK_KetQua Primary key (MaSV, MaDT),
	Constraint FK_KetQua_DeThi Foreign key (MaDT) references DeThi(MaDT),
	Constraint FK_KetQua_SinhVien Foreign key (MaSV) references SinhVien(MaSV),
	Constraint FK_KetQua_KyThi Foreign key (MaKyThi) references KyThi(MaKyThi),
	Constraint CHK_KetQua_SoCauDung check (SoCauDung >= 0), -- Số câu đúng ko được để âm
	Constraint CHK_KetQua_SoCauSai check (SoCauSai >= 0), -- Số câu sai ko được để âm
	Constraint CHK_KetQua_Diem check (Diem BETWEEN 0 AND 10) -- Điểm dao động từ 0-10
)
GO

-- Bảng 'Thi trắc nghiệm'
CREATE TABLE ThiTracNghiem
(
	MaSV INT not null,
	MaDT INT not null,
	CauHoi INT not null,
	DapAn varchar(1),
	DungSai bit,
	CONSTRAINT PK_ThiTracNghiem Primary Key (MaSV, MaDT, CauHoi),
	CONSTRAINT FK_ThiTracNghiem_SinhVien Foreign key (MaSV) references SinhVien(MaSV),
	CONSTRAINT FK_ThiTracNghiem_DeThi Foreign key (MaDT) references DeThi(MaDT)
)
GO

----------------------------------------------------------------------------------------------------
-------------------------------------- Ràng buộc toàn vẹn (TRIGGER) --------------------------------


----------------------------------------------------------------------------------------------------
-------------------------------------- Thêm dữ liệu (INSERT) ---------------------------------------
insert into MonHoc (TenMon, SoTinChi) values
(N'Toán học', 3),
(N'Vật lý', 3),
(N'Hóa học', 2),
(N'Sinh học', 2),
(N'Lịch sử', 2),
(N'Địa lý', 2),
(N'Văn học', 3),
(N'Tiếng Anh', 3),
(N'Công nghệ', 2),
(N'Giáo dục công dân', 1);

INSERT INTO SinhVien (TenSV, NgaySinh, Email, SDT, MatKhau) VALUES
(N'Trần Văn An', '2003-01-15', 'tranvanan@example.com', '0901234567', 123),
(N'Nguyễn Thị Bích', '2004-03-22', 'nguyenthbich@example.com', '0912345678', 123),
(N'Lê Văn Cường', '2003-06-10', 'levanc@example.com', '0923456789', 123),
(N'Phạm Thị Duyên', '2004-09-18', 'phamthid@example.com', '0934567890', 123),
(N'Hoàng Văn Tài', '2003-12-25', 'hoangvantai@example.com', '0945678901', 123),
(N'Ngô Thị Hương', '2002-07-08', 'ngothihuong@example.com', '0956789012', 123),
(N'Phạm Văn Giàu', '2005-05-05', 'phamvang@example.com', '0967890123', 123),
(N'Lý Thị Huyên', '2002-11-21', 'lythihuyen@example.com', '0978901234', 123),
(N'Trương Văn Huấn', '2004-04-01', 'truongvanhuan@example.com', '0989012345', 123),
(N'Nguyễn Thị Đông', '2003-08-17', 'nguyenthidong@example.com', '0990123456', 123);
GO

INSERT INTO CapDo (TenCapDo) VALUES
(N'Bắt buộc'),
(N'Dễ'),
(N'Trung bình'),
(N'Khó');

INSERT INTO KyThi (HocKy,TenHocKy,NamHoc) VALUES
(1, N'Học kỳ 1 năm 2024', 2024),
(2 ,N'Học kỳ 2 năm 2024', 2024);

INSERT INTO CauHoi (MaMon, MaCapDo, NoiDung) VALUES
(1, 2, N'Một phép toán cơ bản là 2 + 3 bằng bao nhiêu?'),
(1, 2, N'Tìm giá trị của 5 - 3?'),
(1, 2, N'Kết quả của phép nhân 4 * 6 là gì?'),
(1, 2, N'Phép chia 9 chia cho 3 là bao nhiêu?'),
(1, 2, N'Tính tổng của 7 và 8 là bao nhiêu?'),

(2, 2, N'Kết quả của phép tính 10 + 5 là bao nhiêu?'),
(2, 2, N'Tốc độ ánh sáng trong chân không là bao nhiêu km/s?'),
(2, 2, N'Khối lượng của một electron là bao nhiêu?'),
(2, 2, N'Tính lực hấp dẫn giữa hai vật có khối lượng m1 và m2 cách nhau 1m?'),
(2, 2, N'Vật nào có nhiệt độ nóng nhất trong hệ mặt trời?'),

(3, 2, N'H2O là công thức hóa học của chất gì?'),
(3, 2, N'Chất nào là acid mạnh nhất?'),
(3, 2, N'Nhựa PVC là gì?'),
(3, 2, N'Muối ăn có công thức hóa học là gì?'),
(3, 2, N'Khí nào có trong thành phần chính của không khí?'),

(4, 2, N'Chất nào là thành phần chính cấu tạo nên tế bào?'),
(4, 2, N'Sự phát triển của phôi trong cơ thể người diễn ra ở đâu?'),
(4, 2, N'Vitamins nhóm B có tác dụng gì cho cơ thể?'),
(4, 2, N'Tế bào động vật có đặc điểm gì khác tế bào thực vật?'),
(4, 2, N'Quá trình hô hấp ở người xảy ra ở bộ phận nào của cơ thể?'),

(5, 2, N'Ngày Quốc khánh Việt Nam là ngày nào?'),
(5, 2, N'Chủ tịch Hồ Chí Minh sinh vào năm nào?'),
(5, 2, N'Cuộc khởi nghĩa Hai Bà Trưng diễn ra vào năm bao nhiêu?'),
(5, 2, N'Hiệp định Paris ký kết năm bao nhiêu?'),
(5, 2, N'Vị vua nào đầu tiên của triều đại Nguyễn?'),

(6, 2, N'Quốc gia nào có diện tích lớn nhất thế giới?'),
(6, 2, N'Hệ thống núi nào dài nhất trên thế giới?'),
(6, 2, N'Vùng đất nào là sa mạc lớn nhất thế giới?'),
(6, 2, N'Đâu là thủ đô của Nhật Bản?'),
(6, 2, N'Hệ thống sông nào dài nhất Việt Nam?'),

(7, 2, N'Tác giả của tác phẩm "Truyện Kiều" là ai?'),
(7, 2, N'Trong tác phẩm "Lão Hạc", nhân vật chính là ai?'),
(7, 2, N'Văn học Việt Nam được chia thành mấy giai đoạn?'),
(7, 2, N'Bài thơ "Sang thu" của ai?'),
(7, 2, N'Chủ đề chính trong "Chí Phèo" của Nam Cao là gì?'),

(8, 2, N'How do you say HELLO in English?'),
(8, 2, N'What is the past tense of "go"?'),
(8, 2, N'What is the plural form of "child"?'),
(8, 2, N'How do you ask for directions in English?'),
(8, 2, N'What does "computer" mean in English?'),

(9, 2, N'CPU là gì?'),
(9, 2, N'Internet là mạng gì?'),
(9, 2, N'Mạng LAN là gì?'),
(9, 2, N'Tiến trình nào được gọi là "Quá trình số hóa"?'),
(9, 2, N'Vì sao máy tính cần bộ nhớ RAM?'),

(10, 2, N'Tôn trọng người khác là gì?'),
(10, 2, N'Tại sao phải giữ gìn vệ sinh cá nhân?'),
(10, 2, N'Phải làm gì khi gặp người gặp khó khăn?'),
(10, 2, N'Những hành vi nào là hành vi văn minh trong xã hội?'),
(10, 2, N'Lòng biết ơn đối với ông bà, cha mẹ được thể hiện như thế nào?');


INSERT INTO DapAn (MaCH, TenDA, NoiDung, DungSai) VALUES
-- Câu hỏi 1
(1, 'A', N'4', 0),
(1, 'B', N'5', 1), -- Đáp án đúng
(1, 'C', N'6', 0),
(1, 'D', N'7', 0),

-- Câu hỏi 2
(2, 'A', N'1', 0),
(2, 'B', N'2', 1),  -- Đáp án đúng
(2, 'C', N'3', 0),
(2, 'D', N'4', 0),

-- Câu hỏi 3
(3, 'A', N'18', 0),
(3, 'B', N'20', 0),  
(3, 'C', N'24', 1), -- Đáp án đúng
(3, 'D', N'30', 0),

-- Câu hỏi 4
(4, 'A', N'2', 0),
(4, 'B', N'3', 1), -- Đáp án đúng
(4, 'C', N'4', 0),
(4, 'D', N'5', 0),

-- Câu hỏi 5
(5, 'A', N'14', 0),
(5, 'B', N'15', 1),  -- Đáp án đúng
(5, 'C', N'16', 0),
(5, 'D', N'17', 0),

-- Câu hỏi 6
(6, 'A', N'12', 0),
(6, 'B', N'13', 0),
(6, 'C', N'14', 0),
(6, 'D', N'15', 1),

-- Câu hỏi 7
(7, 'A', N'3 x 10^8 km/s', 1),  -- Đáp án đúng
(7, 'B', N'1.5 x 10^8 km/s', 0),
(7, 'C', N'2 x 10^8 km/s', 0),
(7, 'D', N'3.5 x 10^8 km/s', 0),


-- Câu hỏi 8
(8, 'A', N'9.11 x 10^-31 kg', 1),  -- Đáp án đúng
(8, 'B', N'1.67 x 10^-27 kg', 0),
(8, 'C', N'5.5 x 10^-28 kg', 0),
(8, 'D', N'3.14 x 10^-25 kg', 0),

-- Câu hỏi 9
(9, 'A', N'F = G * (m1 * m2) / r^2', 1),  -- Đáp án đúng
(9, 'B', N'F = G * m1 * m2', 0),
(9, 'C', N'F = m1 * m2 / r^2', 0),
(9, 'D', N'F = m1 * m2 * G', 0),

-- Câu hỏi 10
(10, 'A', N'Mặt trời', 0),
(10, 'B', N'Mặt trăng', 0),
(10, 'C', N'Ngôi sao lớn nhất', 0),
(10, 'D', N'Mặt trời - Cực nóng', 1),

-- Câu hỏi 11
(11, 'A', N'Nước', 1),  -- Đáp án đúng
(11, 'B', N'NaCl', 0),
(11, 'C', N'O2', 0),
(11, 'D', N'HCl', 0),

-- Câu hỏi 12
(12, 'A', N'HCl', 0),
(12, 'B', N'H2SO4', 1),  -- Đáp án đúng
(12, 'C', N'HNO3', 0),
(12, 'D', N'H3PO4', 0),

-- Câu hỏi 13
(13, 'A', N'Polyvinyl chloride', 1),  -- Đáp án đúng
(13, 'B', N'Polyethylene', 0),
(13, 'C', N'Polypropylene', 0),
(13, 'D', N'Polystyrene', 0),

-- Câu hỏi 14
(14, 'A', N'NaCl', 1),  -- Đáp án đúng
(14, 'B', N'Na2SO4', 0),
(14, 'C', N'K2CO3', 0),
(14, 'D', N'CaCO3', 0),

-- Câu hỏi 15
(15, 'A', N'Oxygen', 1),  -- Đáp án đúng
(15, 'B', N'Nitrogen', 0),
(15, 'C', N'Carbon dioxide', 0),
(15, 'D', N'Argon', 0),

-- Câu hỏi 16
(16, 'A', N'Protein', 0),
(16, 'B', N'Nucleic acid', 0),
(16, 'C', N'Lipids', 0),
(16, 'D', N'Water', 1),  -- Đáp án đúng

-- Câu hỏi 17
(17, 'A', N'Tử cung', 1),  -- Đáp án đúng
(17, 'B', N'Vòi trứng', 0),
(17, 'C', N'Ovaries', 0),
(17, 'D', N'Bàng quang', 0),

-- Câu hỏi 18
(18, 'A', N'Tăng cường trí nhớ', 1),  -- Đáp án đúng
(18, 'B', N'Tăng cường hệ miễn dịch', 0),
(18, 'C', N'Giảm mỡ cơ thể', 0),
(18, 'D', N'Tăng cường thị lực', 0),

-- Câu hỏi 19
(19, 'A', N'Tế bào động vật có thành tế bào', 0),
(19, 'B', N'Tế bào động vật có lysosomes', 1),  -- Đáp án đúng
(19, 'C', N'Tế bào động vật có lục lạp', 0),
(19, 'D', N'Tế bào động vật có không bào trung tâm', 0),

-- Câu hỏi 20
(20, 'A', N'Phổi', 1),  -- Đáp án đúng
(20, 'B', N'Kết mạc', 0),
(20, 'C', N'Mũi', 0),
(20, 'D', N'Tim', 0),

-- Câu hỏi 21
(21, 'A', N'2 tháng 9', 1),  -- Đáp án đúng
(21, 'B', N'1 tháng 5', 0),
(21, 'C', N'10 tháng 3', 0),
(21, 'D', N'20 tháng 11', 0),

-- Câu hỏi 22
(22, 'A', N'1890', 0),
(22, 'B', N'1895', 0),
(22, 'C', N'1900', 1),  -- Đáp án đúng
(22, 'D', N'1905', 0),

-- Câu hỏi 23
(23, 'A', N'39', 0),
(23, 'B', N'40', 0),
(23, 'C', N'41', 1),  -- Đáp án đúng
(23, 'D', N'42', 0),

-- Câu hỏi 24
(24, 'A', N'1973', 1),  -- Đáp án đúng
(24, 'B', N'1972', 0),
(24, 'C', N'1974', 0),
(24, 'D', N'1975', 0),

-- Câu hỏi 25
(25, 'A', N'Gia Long', 1),  -- Đáp án đúng
(25, 'B', N'Khai Dinh', 0),
(25, 'C', N'Bao Dai', 0),
(25, 'D', N'Tu Duc', 0),

-- Câu hỏi 26
(26, 'A', N'Canada', 1),  -- Đáp án đúng
(26, 'B', N'Nga', 0),
(26, 'C', N'Mỹ', 0),
(26, 'D', N'Brazil', 0),

-- Câu hỏi 27
(27, 'A', N'Himalaya', 0),
(27, 'B', N'Andes', 0),
(27, 'C', N'Rockies', 1),  -- Đáp án đúng
(27, 'D', N'Alps', 0),

-- Câu hỏi 28
(28, 'A', N'Sahara', 0),
(28, 'B', N'Gobi', 0),
(28, 'C', N'Karakum', 0),
(28, 'D', N'Atacama', 1),  -- Đáp án đúng

-- Câu hỏi 29
(29, 'A', N'Tokyo', 1),  -- Đáp án đúng
(29, 'B', N'Kyoto', 0),
(29, 'C', N'Osaka', 0),
(29, 'D', N'Nagoya', 0),

-- Câu hỏi 30
(30, 'A', N'Sông Hồng', 0),
(30, 'B', N'Sông Mê Kông', 0),
(30, 'C', N'Sông Đồng Nai', 1),  -- Đáp án đúng
(30, 'D', N'Sông Cửu Long', 0),

-- Câu hỏi 31
(31, 'A', N'Nguyễn Du', 1),  -- Đáp án đúng
(31, 'B', N'Nam Cao', 0),
(31, 'C', N'Tố Hữu', 0),
(31, 'D', N'Trần Nhân Tông', 0),

-- Câu hỏi 32
(32, 'A', N'Lão Hạc', 1),  -- Đáp án đúng
(32, 'B', N'Trái tim sắt', 0),
(32, 'C', N'Giọt mưa', 0),
(32, 'D', N'Chiếc lược ngà', 0),

-- Câu hỏi 33
(33, 'A', N'2', 0),
(33, 'B', N'3', 0),
(33, 'C', N'4', 1),  -- Đáp án đúng
(33, 'D', N'5', 0),

-- Câu hỏi 34
(34, 'A', N'Xuân Diệu', 0),
(34, 'B', N'Hoàng Cầm', 0),
(34, 'C', N'Hữu Thỉnh', 0),
(34, 'D', N'Chế Lan Viên', 1),  -- Đáp án đúng

-- Câu hỏi 35
(35, 'A', N'Khát vọng', 1),  -- Đáp án đúng
(35, 'B', N'Con đường', 0),
(35, 'C', N'Vượt lên chính mình', 0),
(35, 'D', N'Hòa nhập cùng cuộc đời', 0),

-- Câu hỏi 36
(36, 'A', N'Good morning', 0),
(36, 'B', N'Hello', 1),  -- Đáp án đúng
(36, 'C', N'Hi there', 0),
(36, 'D', N'Good night', 0),

-- Câu hỏi 37
(37, 'A', N'Gone', 1),  -- Đáp án đúng
(37, 'B', N'Go', 0),
(37, 'C', N'Went', 0),
(37, 'D', N'Going', 0),

-- Câu hỏi 38
(38, 'A', N'Children', 1),  -- Đáp án đúng
(38, 'B', N'Childs', 0),
(38, 'C', N'Child', 0),
(38, 'D', N'Kids', 0),

-- Câu hỏi 39
(39, 'A', N'Can you show me the way?', 1),  -- Đáp án đúng
(39, 'B', N'How to go to the park?', 0),
(39, 'C', N'Where is the road?', 0),
(39, 'D', N'Tell me the way?', 0),

-- Câu hỏi 40
(40, 'A', N'Machine', 1),  -- Đáp án đúng
(40, 'B', N'Computer', 0),
(40, 'C', N'Processing', 0),
(40, 'D', N'System', 0),

-- Câu hỏi 41
(41, 'A', N'Central Processing Unit', 1),  -- Đáp án đúng
(41, 'B', N'Computing Power Unit', 0),
(41, 'C', N'Core Processing Unit', 0),
(41, 'D', N'Control Processing Unit', 0),

-- Câu hỏi 42
(42, 'A', N'Local Area Network', 1),  -- Đáp án đúng
(42, 'B', N'Large Area Network', 0),
(42, 'C', N'Long Area Network', 0),
(42, 'D', N'Link Area Network', 0),

-- Câu hỏi 43
(43, 'A', N'Internet Protocol', 1),  -- Đáp án đúng
(43, 'B', N'Internet Power', 0),
(43, 'C', N'Interconnect Protocol', 0),
(43, 'D', N'Intranet Protocol', 0),

-- Câu hỏi 44
(44, 'A', N'Transform digital data to analog', 1),  -- Đáp án đúng
(44, 'B', N'Convert to HTML format', 0),
(44, 'C', N'Create digital signals', 0),
(44, 'D', N'Link two computers', 0),

-- Câu hỏi 45
(45, 'A', N'It helps the computer process information faster', 1),  -- Đáp án đúng
(45, 'B', N'It stores more data', 0),
(45, 'C', N'It maintains the system', 0),
(45, 'D', N'It saves energy', 0),

-- Câu hỏi 46
(46, 'A', N'Tôn trọng quyền và lợi ích của người khác', 1),  -- Đáp án đúng
(46, 'B', N'Tìm cách hạ thấp người khác', 0),
(46, 'C', N'Phớt lờ người khác', 0),
(46, 'D', N'Chấp hành luật pháp', 0), -- Đáp án đúng

-- Câu hỏi 47
(47, 'A', N'Vì nó giữ gìn sức khỏe', 1),  -- Đáp án đúng
(47, 'B', N'Vì nó giúp bạn đẹp hơn', 0),
(47, 'C', N'Vì người khác yêu cầu', 0),
(47, 'D', N'Vì nó giúp bạn sống lâu hơn', 0),

-- Câu hỏi 48
(48, 'A', N'Giúp đỡ họ vượt qua khó khăn', 1),  -- Đáp án đúng
(48, 'B', N'Nhờ người khác giải quyết', 0),
(48, 'C', N'Phớt lờ vấn đề', 0),
(48, 'D', N'Bỏ qua vấn đề', 0),

-- Câu hỏi 49
(49, 'A', N'Chăm sóc bản thân', 0),
(49, 'B', N'Giúp đỡ mọi người', 1),  -- Đáp án đúng
(49, 'C', N'Tôn trọng người khác', 0),
(49, 'D', N'Chia sẻ với cộng đồng', 0),

-- Câu hỏi 50
(50, 'A', N'Chăm sóc ông bà, cha mẹ', 1),  -- Đáp án đúng
(50, 'B', N'Tặng quà cho ông bà, cha mẹ', 0),
(50, 'C', N'Nói lời cảm ơn', 0),
(50, 'D', N'Giúp đỡ ông bà, cha mẹ', 0);

-- Chèn dữ liệu vào bảng DeThi
INSERT INTO DeThi (ThoiGianLam, SoLuongCau, NgayTao) VALUES
(60, 5, '2024-12-01'),  -- Đề thi 1: 60 phút, 5 câu hỏi
(90, 10, '2024-12-02'), -- Đề thi 2: 90 phút, 10 câu hỏi
(120, 10, '2024-12-03'); -- Đề thi 3: 120 phút, 10 câu hỏi

-- Chèn dữ liệu vào bảng ChiTietDeThi cho Đề thi 1
INSERT INTO ChiTietDeThi (MaDT, MaCH, GhiChu) VALUES
(1, 1, N'Phép toán cơ bản'),
(1, 2, N'Tìm giá trị phép trừ'),
(1, 3, N'Phép nhân đơn giản'),
(1, 4, N'Phép chia'),
(1, 5, N'Tính tổng đơn giản');

-- Chèn dữ liệu vào bảng ChiTietDeThi cho Đề thi 2
INSERT INTO ChiTietDeThi (MaDT, MaCH, GhiChu) VALUES
(2, 6, N'Phép tính cộng'),
(2, 7, N'Tốc độ ánh sáng trong chân không'),
(2, 8, N'Khối lượng electron'),
(2, 9, N'Tính lực hấp dẫn'),
(2, 10, N'Nhiệt độ của vật thể trong vũ trụ'),
(2, 11, N'Chất hóa học cơ bản'),
(2, 12, N'Tính toán hóa học'),
(2, 13, N'Nhựa PVC'),
(2, 14, N'Muối ăn'),
(2, 15, N'Khí trong không khí');

-- Chèn dữ liệu vào bảng ChiTietDeThi cho Đề thi 3
INSERT INTO ChiTietDeThi (MaDT, MaCH, GhiChu) VALUES
(3, 16, N'Thành phần cấu tạo tế bào'),
(3, 17, N'Phôi trong cơ thể người'),
(3, 18, N'Vitamins nhóm B'),
(3, 19, N'Tế bào động vật và thực vật'),
(3, 20, N'Quá trình hô hấp'),
(3, 21, N'Ngày Quốc khánh Việt Nam'),
(3, 22, N'Năm sinh Hồ Chí Minh'),
(3, 23, N'Khởi nghĩa Hai Bà Trưng'),
(3, 24, N'Hiệp định Paris'),
(3, 25, N'Vị vua đầu tiên triều Nguyễn');

-- Chèn dữ liệu vào bảng KetQua
INSERT INTO KetQua (MaSV, MaDT, MaKyThi, SoCauDung, SoCauSai, Diem, NgayHoanThanh) VALUES
(1, 1, 1, 5, 0, 10.00, '2024-12-01'),  -- Sinh viên 1 làm Đề thi 1, điểm 10
(2, 1, 1, 4, 1, 8.00, '2024-12-01'),  -- Sinh viên 2 làm Đề thi 1, điểm 8
(3, 2, 2, 7, 3, 7.00, '2024-12-02'),  -- Sinh viên 3 làm Đề thi 2, điểm 7
(4, 2, 2, 9, 1, 9.00, '2024-12-02'),  -- Sinh viên 4 làm Đề thi 2, điểm 9
(5, 3, 1, 13, 2, 8.00, '2024-12-03'),  -- Sinh viên 5 làm Đề thi 3, điểm 8
(6, 3, 1, 10, 5, 6.00, '2024-12-03');  -- Sinh viên 6 làm Đề thi 3, điểm 6
GO
insert into KetQua (MaSV, MaDT, MaKyThi) VALUES (3, 1, 1)
GO


----------------------------------------------------------------------------------------------------
-------------------------------------- Thủ tục (STORE PROCEDURE) -----------------------------------

------------------------------------------- QUẢN LÝ ĐỀ THI --------------------------------------------------
CREATE PROC SP_Select_DangNhap
	@MaSV int,
	@MatKhau nvarchar(max)
AS
BEGIN
	select * from SinhVien where MaSV = @MaSV and MatKhau = @MatKhau
END
GO

CREATE PROC SP_Select_DeThi
AS
BEGIN
	select * from DeThi
END
GO

CREATE PROC SP_Select_ChiTietDeThi
	@MaDT int = null
AS
BEGIN
	IF(@MaDT is not null)
		select * from ChiTietDeThi where MaDT = @MaDT
	ELSE
		select * from ChiTietDeThi
END
GO

CREATE PROC SP_Select_DeThi_TheoMaDT
	@MaDT int
AS
BEGIN
	select * from DeThi where MaDT = @MaDT
END
GO

CREATE PROC SP_Select_CauHoi_TheoMaCauHoi
	@MaCauHoi int
AS
BEGIN
	select * from CauHoi where MaCH = @MaCauHoi
END
GO

CREATE PROC SP_Insert_DeThi
	@Ngaytao date,
	@SoLuongCauHoi int,
	@ThoiGianLam int
AS
BEGIN
	INSERT INTO DeThi (NgayTao, SoLuongCau, ThoiGianLam) VALUES
	(@Ngaytao, @SoLuongCauHoi, @ThoiGianLam)
END
GO

CREATE PROC SP_Delete_DeThiVaChiTietDeThi
	@MaDT int
AS
BEGIN
	DELETE FROM ChiTietDeThi WHERE MaDT = @MaDT
	DELETE FROM DeThi WHERE MaDT = @MaDT
END
GO

CREATE PROC SP_Select_KetQua_TheoMaDT
	@MaDT int
AS
BEGIN
	select * from KetQua where MaDT = @MaDT
END
GO

CREATE PROC SP_Update_DeThi_TheoMaDT
	@MaDT int,
	@NgayTao date,
	@SoLuongCauHoi int,
	@ThoiGianLam int
AS
BEGIN
	update DeThi set
	NgayTao = @NgayTao,
	SoLuongCau = @SoLuongCauHoi,
	ThoiGianLam = @ThoiGianLam
	where MaDT = @MaDT
END
GO

CREATE PROC SP_Insert_ChiTietDeThi
	@MaDT int,
	@MaCH int,
	@GhiChu nvarchar(max)
AS
BEGIN
	INSERT INTO ChiTietDeThi (MaDT,MaCH,GhiChu) VALUES (@MaDT,@MaCH, @GhiChu)
END
GO

CREATE PROC SP_Delete_ChiTietDeThi
	@MaDT int,
	@MaCH int
AS
BEGIN
	DELETE FROM ChiTietDeThi where MaDT = @MaDT and MaCH = @MaCH
END
GO

CREATE PROC SP_Update_ChiTietDeThi_GhiChu
	@MaDT int,
	@MaCH int,
	@GhiChu nvarchar(max)
AS
BEGIN
	UPDATE ChiTietDeThi SET GhiChu = @GhiChu
	where MaDT = @MaDT and MaCH = @MaCH
END
GO

CREATE PROC SP_Select_ChiTietDeThi_TimKiem
	@MaDT int,
	@TimKiem nvarchar(max)
AS
BEGIN
	select * from ChiTietDeThi where MaDT =	@MaDT
	AND (MaCH LIKE '%'+@TimKiem+'%' OR GhiChu LIKE '%'+@TimKiem+'%')
END
GO

---------------------------------- QUẢN LÝ KẾT QUẢ ----------------------------------------
-- Procedure thêm kết quả
CREATE PROCEDURE sp_ThemKetQua
    @MaSV INT,
    @MaDT INT,
    @MaKyThi INT,
    @SoCauDung INT,
    @SoCauSai INT,
    @Diem DECIMAL(5,2),
    @NgayHoanThanh DATE
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra các điều kiện
        IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
            THROW 50001, N'Mã sinh viên không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM DeThi WHERE MaDT = @MaDT)
            THROW 50002, N'Mã đề thi không tồn tại', 1;
            
        IF NOT EXISTS (SELECT 1 FROM KyThi WHERE MaKyThi = @MaKyThi)
            THROW 50003, N'Mã kỳ thi không tồn tại', 1;
            
        IF EXISTS (SELECT 1 FROM KetQua WHERE MaSV = @MaSV AND MaDT = @MaDT)
            THROW 50004, N'Kết quả này đã tồn tại', 1;
            
        IF @SoCauDung < 0
            THROW 50005, N'Số câu đúng không được âm', 1;
            
        IF @SoCauSai < 0
            THROW 50006, N'Số câu sai không được âm', 1;
            
        IF @Diem < 0 OR @Diem > 10
            THROW 50007, N'Điểm phải nằm trong khoảng 0-10', 1;

        -- Thêm kết quả mới
        INSERT INTO KetQua (MaSV, MaDT, MaKyThi, SoCauDung, SoCauSai, Diem, NgayHoanThanh)
        VALUES (@MaSV, @MaDT, @MaKyThi, @SoCauDung, @SoCauSai, @Diem, @NgayHoanThanh);

        SELECT 'SUCCESS' AS Result;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Procedure xóa kết quả
CREATE PROCEDURE sp_XoaKetQua
    @MaSV INT,
    @MaDT INT
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem kết quả có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM KetQua WHERE MaSV = @MaSV AND MaDT = @MaDT)
            THROW 50008, N'Không tìm thấy kết quả để xóa', 1;

        -- Xóa kết quả
        DELETE FROM KetQua
        WHERE MaSV = @MaSV AND MaDT = @MaDT;

        SELECT 'SUCCESS' AS Result;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Procedure sửa kết quả
CREATE PROCEDURE sp_SuaKetQua
    @MaSV INT,
    @MaDT INT,
    @MaKyThi INT,
    @SoCauDung INT,
    @SoCauSai INT,
    @Diem DECIMAL(5,2),
    @NgayHoanThanh DATE
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra các điều kiện
        IF NOT EXISTS (SELECT 1 FROM KetQua WHERE MaSV = @MaSV AND MaDT = @MaDT)
            THROW 50009, N'Không tìm thấy kết quả để cập nhật', 1;
            
        IF NOT EXISTS (SELECT 1 FROM KyThi WHERE MaKyThi = @MaKyThi)
            THROW 50010, N'Mã kỳ thi không tồn tại', 1;
            
        IF @SoCauDung < 0
            THROW 50011, N'Số câu đúng không được âm', 1;
            
        IF @SoCauSai < 0
            THROW 50012, N'Số câu sai không được âm', 1;
            
        IF @Diem < 0 OR @Diem > 10
            THROW 50013, N'Điểm phải nằm trong khoảng 0-10', 1;

        -- Cập nhật kết quả
        UPDATE KetQua
        SET MaKyThi = @MaKyThi,
            SoCauDung = @SoCauDung,
            SoCauSai = @SoCauSai,
            Diem = @Diem,
            NgayHoanThanh = @NgayHoanThanh
        WHERE MaSV = @MaSV AND MaDT = @MaDT;

        SELECT 'SUCCESS' AS Result;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-------------------------------------------- THI TRẮC NGHIỆM ------------------------------------------------------------------
CREATE PROC SP_Update_ThiTracNghiem_DapAnVaDungSai
	@MaSV int,
	@MaDT int,
	@MaCH int,
	@CauHoi int,
	@DapAn varchar(1)
AS
BEGIN
	UPDATE ThiTracNghiem set
	DapAn = @DapAn, DungSai = (select DungSai from DapAn where MaCH = @MaCH and TenDA = @DapAn)
	where MaSV = @MaSV and MaDT = @MaDT and CauHoi = @CauHoi
END
GO

CREATE PROC SP_Select_ThiTracNghiem_CauDung
	@MaSV int,
	@MaDT int
AS
BEGIN
	select Count(DungSai) AS SoCauDung from ThiTracNghiem 
	where MaSV = @MaSV and MaDT = @MaDT and DungSai = 1
END
GO

CREATE PROC SP_Update_KetQuaThiCuaSinhVien
	@MaSV int,
	@MaDT int,
	@SoCauDung int,
	@SoCauSai int,
	@Diem decimal(5,2)
AS
BEGIN
	UPDATE KetQua SET
	SoCauDung = @SoCauDung,
	SoCauSai = @SoCauSai,
	Diem = @Diem,
	NgayHoanThanh = GETDATE()
	where MaSV = @MaSV and MaDT = @MaDT
END
GO
