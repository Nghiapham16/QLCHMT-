create table tblNhaCC (
MaNhaCC nvarchar(50) primary key ,
TenNhaCC nvarchar(50) not null,
DiaChi nvarchar(100) not null,
MaSoThue nvarchar(50) not null,
TaiKhoan nvarchar(15) not null,
DienThoai nvarchar(50) not null,
);
create table tblHangNhap (
Mahang nvarchar(50) ,
MaNhaCC nvarchar (50) ,
SoLuong int not null,
DonGia float not null,
SoHD nvarchar(30) not null,
NgayGH Datetime ,
primary key clustered (MaNhaCC asc ,Mahang asc ),
);
