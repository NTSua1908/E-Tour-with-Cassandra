Create database TourManagement
use TourManagement
SET DATEFORMAT dmy
--"Phần tuyến tạo bảng bằng tay kéo xuống column properties chỉnh identity specification = yes"
--Tài khoản dự phòng--
Insert into UserID values('19522003@gm.uit.edu.vn','gdyb21LQTcIANtvYMT7QVQ==','Vo','Phat','090432') --gdyb21LQTcIANtvYMT7QVQ== là password được mã hóa có giá trị =1234--
create table UserID (
	Email nvarchar(50),
	Password nvarchar(50),
	Ho nvarchar(50),
	Ten nvarchar(50),
	SĐT nvarchar(50),
)
create table Tuyen (
	ID int IDENTITY(1,1),
	MaTuyen nvarchar(20) primary key,
	TenTuyen nvarchar(20),
	XuatPhat nvarchar(20),
	DiaDiem nvarchar(50),
	ThoiGianToChuc nvarchar(50),
	MaLoaiTuyen nvarchar(20),
)

create table LoaiTuyen (
	MaLoaiTuyen nvarchar(20) primary key,
	TenLoaiTuyen nvarchar(50),
	LePhiHoanTra int
)

create table ChuyenDuLich (
	ID int IDENTITY(1,1),
	MaChuyen nvarchar(20) primary key,
	MaTuyen nvarchar(20),
	ThoiGianKhoiHanh datetime,
	PhuongTien nvarchar(20),
	SoLuongveMax int,
	MaLoaiChuyen nvarchar(20),
	GiaVe float
)
create table  Loaichuyen (
	MaLoaiChuyen nvarchar(20) primary key,
	TenLoaiChuyen nvarchar(50),
	TienHoanTra float
)

create table PhieuDatCho (
	MaPhieu int IDENTITY(1,1) primary key,
	MaChuyen nvarchar(20),
)

create table Ve (
	MaVe int IDENTITY(1,1) primary key,
	MaPhieu int,
	GiaVe int,
	MaDuKhach int
)

create table DuKhach
( 
	MaDuKhach int IDENTITY(1,1) primary key,
	HoTen nvarchar(50),
	DiaChi nvarchar(50),
	SDT char(15),
	MaLoaiKhach nvarchar(20),
	GioiTinh nvarchar(10),
	CMND_Passport nvarchar(20),
	HanPassport date,
	HanVisa date,
)

create table LoaiKhach(
	MaLoaiKhach nvarchar(20) primary key,
	TenLoaiKhach nvarchar(50),
)

alter table Tuyen add constraint fk_Tuyen_LoaiTuyen foreign key (MaLoaiTuyen) references LoaiTuyen (MaLoaiTuyen);
alter table ChuyenDuLich add constraint fk_Chuyen_Tuyen foreign key (MaTuyen) references Tuyen (MaTuyen);
alter table PhieuDatCho add constraint fk_Phieu_Chuyen foreign key (MaChuyen) references ChuyenDuLich (MaChuyen);
alter table Ve add constraint fk_Ve_Phieu foreign key (MaPhieu) references PhieuDatCho (MaPhieu);
alter table Ve add constraint fk_Ve_DuKhach foreign key (MaDuKhach) references DuKhach (MaDuKhach);
alter table DuKhach add constraint fk_DuKhach_LoaiDK foreign key (MaLoaiKhach) references LoaiKhach (MaLoaiKhach);
alter table ChuyenDuLich add constraint fk_Chuyen_LoaiChuyen foreign key (MaLoaiChuyen) references LoaiChuyen (MaLoaiChuyen);

Insert into LoaiKhach values('CUS001','Domestic');
Insert into LoaiKhach values('CUS002','Foreign');

Insert into LoaiTuyen values('ROUTE01','National',100000);
Insert into LoaiTuyen values('ROUTE02','International',1150000);

Insert into LoaiChuyen values('TOUR01','Regular',1);
Insert into LoaiChuyen values('TOUR02','Promotional',0.8);









