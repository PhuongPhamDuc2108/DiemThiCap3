ALTER TRIGGER NHAPBANCHOGIAOVIEN
ON tBan
FOR INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @magv nvarchar(10), @mamh nvarchar(15), @malop nvarchar(15)
	SELECT @magv = MaGV, @mamh = MaMH, @malop = MaLop from inserted
	UPDATE tGiaoVien SET MaMH = @mamh WHERE MaGV = @magv
	UPDATE tGiaoVien SET GVCN = @malop WHERE MaGV = @magv
	UPDATE tLop SET GVCN = @magv WHERE MaLop = @malop
END

create TRIGGER THAYDOIGIAOVIENCHOTBAN
ON tGiaoVien
FOR INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @magv nvarchar(10), @mamh nvarchar(15), @malop nvarchar(15)
	SELECT @magv = MaGV, @mamh = MaMH, @malop = GVCN from inserted
	UPDATE tBan SET MaMH = @mamh WHERE MaGV = @magv
	UPDATE tBan SET MaGV = @magv WHERE MaGV = @magv
END
drop trigger THAYDOIGIAOVIENCHOTBAN

DELETE tGiaoVien
DELETE tBan
DELETE tLop WHERE MaLop = N'11A1'
SELECT * FROM tBan WHERE MaLop=N'10A1'