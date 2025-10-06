-- Tạo Database
CREATE DATABASE NhaSachADO;


USE NhaSachADO;


-- Bảng Loại
CREATE TABLE tbl_Loai (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100)
);

-- Bảng Nhà sản xuất
CREATE TABLE tbl_NhaSanXuat (
    MaNSX INT PRIMARY KEY IDENTITY(1,1),
    TenNSX NVARCHAR(100)
);

-- Bảng Sản phẩm
CREATE TABLE tbl_SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSP NVARCHAR(200),
    MaLoai INT,
    MaNSX INT,
    Gia DECIMAL(18, 0),
    GhiChu NVARCHAR(500),
    Hinh NVARCHAR(200),
    FOREIGN KEY (MaLoai) REFERENCES tbl_Loai(MaLoai),
    FOREIGN KEY (MaNSX) REFERENCES tbl_NhaSanXuat(MaNSX)
);

-- Bảng Khách hàng
CREATE TABLE tbl_KhachHang (
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    TenKH NVARCHAR(100),
    SoDienThoai VARCHAR(20),
    MatKhau VARCHAR(50)
);

-- Bảng Hóa đơn
CREATE TABLE tbl_HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayTao DATETIME,
    MaKH INT,
    FOREIGN KEY (MaKH) REFERENCES tbl_KhachHang(MaKH)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE tbl_ChiTiet (
    MaHD INT,
    MaSP INT,
    SoLuong INT,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES tbl_HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES tbl_SanPham(MaSanPham)
);
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50)
);

-- Thêm dữ liệu mẫu
INSERT INTO tbl_Loai VALUES (N'Sách giáo khoa'), (N'Sách từ điển'), (N'Sách đại học'), (N'Truyện tranh');

INSERT INTO tbl_NhaSanXuat VALUES (N'NXB Giáo Dục'), (N'NXB Kim Đồng'), (N'NXB Từ Điển');

INSERT INTO tbl_SanPham (TenSP, MaLoai, MaNSX, Gia, GhiChu, Hinh) VALUES
(N'My First 1000 English Words', 2, 3, 56000, N'Sách tiếng Anh cho trẻ em', 'images/1000words.jfif'),
(N'Anh-Việt', 2, 3, 120900, N'Từ điển Anh-Việt chuẩn', 'images/anhviet.png'),
(N'Từ điển Hoa-Việt', 2, 3, 81000, N'Từ điển tiếng Hoa', 'images/hoaviet.png'),
(N'Anh-Việt bỏ túi', 2, 3, 47000, N'Phiên bản nhỏ gọn', 'images/anhvietmini.jfif'),
(N'Việt-Anh', 2, 3, 34000, N'Từ điển Việt - Anh cơ bản', 'images/vietanh.jfif');

INSERT INTO tbl_KhachHang (TenKH, SoDienThoai, MatKhau) VALUES
(N'Nguyễn Văn A', '0123456789', '123456'),
(N'Lê Thị B', '0987654321', 'abc123');

INSERT INTO tbl_HoaDon (NgayTao, MaKH) VALUES
(GETDATE(), 1),
(GETDATE(), 2);

INSERT INTO TaiKhoan VALUES ('admin', '123');

INSERT INTO tbl_ChiTiet VALUES
(1, 1, 2),
(1, 2, 1),
(2, 5, 3);



