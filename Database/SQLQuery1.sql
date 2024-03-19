Create table tblLoaiMayTinh (
MaLoaiMayTinh nvarchar(50) primary key not null,
TenLoaiMayTinh nvarchar(50) not null,
);

create table tblHang (
Mahang  nvarchar(50) primary key ,
TenHang varchar(50) not null ,
MaLoaiMayTinh nvarchar(50) ,
SoLuong float(53) not null,
DonGiaNhap float(53) not null,
DonGiaBan float(53) not null,
Anh nvarchar(500) not null,
GhiChu nvarchar(500) not null,
constraint ma_lmt foreign key (MaLoaiMayTinh ) references tblLoaiMayTinh(MaLoaiMayTinh),

);

create table tblKhach (
MaKhach nvarchar(50) primary key ,
TenKhach nvarchar(50) not null,
DiaChi varchar(50) not null,
DienThoai nvarchar(50) not null,
);



create table tblNhanVien (
ManhanVien nvarchar(50)  primary key  ,
TenNhanVien nvarchar(50) not null,
GioiTinh nvarchar(50) not null,
DiaChi nvarchar(50) not null,
DienThoai nvarchar(50) not null,
NgaySinh datetime  not null,
);



create table tblHDBan(
MaHDBan nvarchar(50)  primary key ,
MaNhanVien nvarchar(50) not null,
NgayBan datetime  not null,
MaKhach nvarchar(50) not null,
TongTien Float (53) not null,
constraint ma_kh1 foreign key ( MaKhach  ) references  tblKhach(MaKhach),
constraint ma_nv1 foreign key ( ManhanVien ) references  tblNhanVien(ManhanVien),


);

create table tblChiTietHDBan (
MaHDBan nvarchar(50) not null,
MaHang nvarchar(50) not null,
SoLuong Float(53) not null,
DonGia Float(53) not null,
GiamGia Float(53) not null,
ThanhTien Float(53) not null,
primary key clustered (MaHDBan asc ,MaHang asc )

);
alter table tblChiTietHDBan add constraint ma_hd1 foreign key ( MaHDBan ) references tblHDBan(MaHDBan)
alter table tblChiTietHDBan add constraint ma_mt1 foreign key ( Mahang  ) references tblHang(Mahang)



