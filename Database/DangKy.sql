

ALTER PROC SP_DangKyTaiKhoan
@tendangnhap NCHAR(20),
@tenhienthi NVARCHAR(50),
@matkhau varchar(200),
@ngaysinh DATE,
@gioitinh NVARCHAR(20),
@dienthoai nchar(20),
@email nchar(40),
@anhdaidien varchar(250)
AS
BEGIN
	INSERT INTO dbo.ThanhVien
	        ( TenDangNhap ,
	          MatKhau ,
	          TenHienThi ,
	          NgaySinh ,
	          GioiTinh ,
	          DienThoai ,
	          Email ,
	          AnhDaiDien
	        )
	VALUES  ( @tendangnhap , -- TenDangNhap - nchar(20)
	          @matkhau , -- MatKhau - varchar(200)
	          @tenhienthi, -- TenHienThi - nvarchar(50)
	          @ngaysinh , -- NgaySinh - date
	          @gioitinh, -- GioiTinh - nvarchar(10)
	          @dienthoai , -- DienThoai - nchar(20)
	          @email, -- Email - nchar(40)
	          @anhdaidien -- AnhDaiDien - varchar(250)
	        )
END

GO

dbo.SP_DangKyTaiKhoan @tendangnhap = N'xxx', -- nchar(20)
    @tenhienthi = N'xxx', -- nvarchar(50)
    @matkhau = '1', -- varchar(200)
    @ngaysinh = '2018-11-28', -- date
    @gioitinh = N'nam', -- nvarchar(20)
    @dienthoai = N'0987654321', -- nchar(20)
    @email = N'aaaa@gmail.com', -- nchar(40)
    @anhdaidien = 'asdasd/sadsa/ádas' -- varchar(250)

GO

ALTER PROC SP_KiemTraThongTinDangKy
@tendangnhap NCHAR(20),
@dienthoai nchar(20),
@email nchar(40)
AS
BEGIN
	DECLARE @Maloi INT;

	IF EXISTS(SELECT * FROM dbo.ThanhVien WHERE TenDangNhap = @tendangnhap)
	BEGIN
		SET @Maloi = 1
	END
	ELSE IF EXISTS(SELECT * FROM dbo.ThanhVien WHERE DienThoai = @dienthoai)
	BEGIN
		SET @Maloi = 2
	END
	ELSE IF EXISTS(SELECT * FROM dbo.ThanhVien WHERE Email = @email)
	BEGIN
		SET @Maloi = 3
	END
	ELSE
	BEGIN
		SET @Maloi = 0
	END

	SELECT @Maloi AS MaLoi
END
GO

dbo.SP_KiemTraThongTinDangKy @tendangnhap = N'tuanvm2', -- nchar(20)
    @dienthoai = N'016775605901', -- nchar(20)
    @email = N'manhtuanst04@gmail.com1' -- nchar(40)
