USE [Website_CLB_HTSV]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202093233_initial', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202100848_initial1', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202102313_initial2', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202103013_initial3', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202103825_initial4', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202104915_initial5', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202105030_initial6', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202110552_initial7', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240202132800_initial8', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240206132132_06022024', N'6.0.26')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229081440_ini1', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229111010_ini2', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240229111659_ini3', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240314055730_ini4', N'6.0.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240327160601_init6', N'6.0.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401011944_initial01042024', N'6.0.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401024015_initial010420242', N'6.0.28')
/****** Object:  Table [dbo].[ChucVu]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV01', N'Chủ Nhiệm')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV02', N'Phó Chủ Nhiệm')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV03', N'Ủy Viên')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV04', N'Thành Viên')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV05', N'Cố Vấn')
/****** Object:  Table [dbo].[Khoa]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'K01', N'Khoa Kỹ thuật và Công nghệ')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'K02', N'Khoa Sư Phạm')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'K03', N'Khoa Ngoại Ngữ')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'K04', N'Khoa Y Dược')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'K05', N'Khoa Khoa Học Cơ Bản')
/****** Object:  Table [dbo].[HoatDong]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[HoatDong] ([MaHoatDong], [TenHoatDong], [MoTa], [ThoiGian], [DiaDiem], [HocKy], [NamHoc], [TrangThai], [HinhAnh], [DaThamGia], [DaDangKi], [MinhChung]) VALUES (N'HD001', N'Vệ Sinh Khuôn Viên Nhà Trường', N'Vệ Sinh Khuôn Viên Nhà Trường', CAST(0x0700027C969065460B AS DateTime2), N'Đại Học Trà Vinh', 1, 2024, NULL, NULL, 0, 0, NULL)
INSERT [dbo].[HoatDong] ([MaHoatDong], [TenHoatDong], [MoTa], [ThoiGian], [DiaDiem], [HocKy], [NamHoc], [TrangThai], [HinhAnh], [DaThamGia], [DaDangKi], [MinhChung]) VALUES (N'HD002', N'Vệ Sinh Khuôn Viên Nhà Trường 2', N'Vệ Sinh Khuôn Viên Nhà Trường 2 ', CAST(0x0700D0CE863465460B AS DateTime2), N'Đại Học Trà Vinh', 1, 2024, NULL, NULL, 0, 0, NULL)
INSERT [dbo].[HoatDong] ([MaHoatDong], [TenHoatDong], [MoTa], [ThoiGian], [DiaDiem], [HocKy], [NamHoc], [TrangThai], [HinhAnh], [DaThamGia], [DaDangKi], [MinhChung]) VALUES (N'HD20240328091126714', N'Vệ Sinh Khuôn Viên Nhà Trường 3', N'Vệ Sinh Khuôn Viên Nhà Trường 3', CAST(0x07006488D54C9C460B AS DateTime2), N'Đền thờ Bác - Long Đức 3', 2, 2023, NULL, NULL, 0, 1, NULL)
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Administrators', N'Admin', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Users', N'User', NULL)
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4c7ed617-d2db-4cdb-bc38-3f85f7107333', N'limeko9873@irnini.com', N'LIMEKO9873@IRNINI.COM', N'limeko9873@irnini.com', N'LIMEKO9873@IRNINI.COM', 0, N'AQAAAAEAACcQAAAAEOgqNIJpREuulgBt7aGmlUIj1oKp5vj1x1LWsUAL+Di7rz7OBzF4KfN+o4lsTCWLyw==', N'UUYWTZDEYTOV3FLUNENIDCH2VZYZGZQZ', N'651dfe31-473f-4393-92b8-c61fee1cd3e6', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5a206348-7833-4249-b21c-9541769bc87d', N'110121987@st.tvu.edu.vn', N'110121987@ST.TVU.EDU.VN', N'110121987@st.tvu.edu.vn', N'110121987@ST.TVU.EDU.VN', 0, N'AQAAAAEAACcQAAAAELUsPFmPTaFKUgwVIbM32uAMH03yOtYww8YwfiK/ztiLXeS+dB5bh/5GakNQO87+lg==', N'Z4RHCFAB5B5VBAFMTUCKQ77JGYEEWVSD', N'51d4a434-6591-4eed-90e4-d0c7c309a7b1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7ddbb37f-886e-4042-810f-55e6b711c59d', N'phuchaunguyen81@gmail.com', N'PHUCHAUNGUYEN81@GMAIL.COM', N'phuchaunguyen81@gmail.com', N'PHUCHAUNGUYEN81@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFI90cjSg+YCDSp5CKsekdje7LUQzd2VVa4DUAtZzinoPNmtVIQ33jCCwHqDze8i0w==', N'G5NWJ56O3G5XFNLBCMEP4CQQGJVTCVSE', N'8ce27c85-47cd-465f-8684-557c8e667e6e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8ee799fb-e174-495b-9805-fb477366a580', N'defam89705@azduan.com', N'DEFAM89705@AZDUAN.COM', N'defam89705@azduan.com', N'DEFAM89705@AZDUAN.COM', 1, N'AQAAAAEAACcQAAAAEGGhHCm0y4s7QM0q9Rxla2Hw0C5xdJPb+GluAeDWvWLB3Nqmw8m4z2Nf39sLbFRbdA==', N'6CXPI2TOHWZ34GWXXVI56C677R42F23X', N'cfeeaf3f-13d0-403c-a33a-39c1d4a37930', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bf7525f1-5bde-4465-8c8b-b9af24e7f161', N'nguyendaihoangphuc24@gmail.com', N'NGUYENDAIHOANGPHUC24@GMAIL.COM', N'nguyendaihoangphuc24@gmail.com', N'NGUYENDAIHOANGPHUC24@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDBYm+r4oy8d/bRBR/vy8r4bUb9wlpeH56XNoodCKjgRNIViSea88rGsAY7hLn/Y7Q==', N'PRI45WQMLCSJOAJA3OWXC7QPPC55NJSU', N'a47d9b36-7ffd-43ec-84bf-9f1e21c145bb', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd718a374-b34c-4907-b696-fcd96ac8f905', N'110121087@st.tvu.edu.vn', N'110121087@ST.TVU.EDU.VN', N'110121087@st.tvu.edu.vn', N'110121087@ST.TVU.EDU.VN', 1, N'AQAAAAEAACcQAAAAEHSCYBpwtpa08fGI45DfiXa4MNN3MTK6EFYn8fxCg8T5JK087Wll9YKO5l8RT/XJmw==', N'3GGHMPYY7GSSRBGQGZEILXHD6EMKHTV6', N'51340d58-ab48-444d-bc01-78abb00c477b', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e980792a-df80-48c1-93e3-7173a9828e51', N'110121182@st.tvu.edu.vn', N'110121182@ST.TVU.EDU.VN', N'110121182@st.tvu.edu.vn', N'110121182@ST.TVU.EDU.VN', 1, N'AQAAAAEAACcQAAAAEN2ptOrZ5IogCbwKoRBRRj21xNPVPpW5AHxfz7O8J6/wr4PHXu8L/7a105kEbTc5lg==', N'R3A6SGZ6A7B3MVJLUZZM7K6G7PU2MJOP', N'ed9b9f47-c808-4f61-8884-fa3e24fbaa83', NULL, 0, 0, NULL, 1, 0)
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bf7525f1-5bde-4465-8c8b-b9af24e7f161', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a206348-7833-4249-b21c-9541769bc87d', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd718a374-b34c-4907-b696-fcd96ac8f905', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e980792a-df80-48c1-93e3-7173a9828e51', N'2')
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[LopHoc]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA21TTA', N'Công Nghệ Thông Tin A', N'K01', N'2021')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA21TTB', N'Công Nghệ Thông Tin B', N'K01', N'2021')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA21TTC', N'Công Nghệ Thông Tin C ', N'K01', N'2021')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA22TTA', N'DA22TTA', N'K01', N'2022')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA22TTB', N'DA22TTB', N'K01', N'2022')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA22TTC', N'DA22TTC', N'K01', N'2022')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA22TTD', N'DA22TTD', N'K01', N'2022')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA23TTA', N'DA23TTA', N'K01', N'2023')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA23TTB', N'DA23TTB', N'K01', N'2023')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA23TTC', N'DA23TTC', N'K01', N'2023')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [MaKhoa], [Khoahoc]) VALUES (N'DA23TTD', N'DA23TTD', N'K01', N'2023')
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[SinhVien]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'110021223', N'Đỗ Thành Ý', CAST(0x070000000000B2250B AS DateTime2), N'0325656656', N'110021223@st.tvu.edu.vn', N'DA21TTA', N'CV05', N'37d14101-cfdd-48a3-bf4e-4275653d947d.jpg')
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'1101210122', N'Võ Thị Diểm', CAST(0x0700000000004F280B AS DateTime2), N'0325656565', N'1101210122@st.tvu.edu.vn', N'DA21TTB', N'CV04', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'1101210124', N'Nguyễn Văn Test', CAST(0x07000000000071460B AS DateTime2), N'0325656656', N'nguyendaihoangphuc1911@gmail.com', N'DA21TTA', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'110121087', N'Nguyễn Đại Hoàng Phúc', CAST(0x070000000000000000 AS DateTime2), N'0366203505', N'nguyendaihoangphuc24@gmail.com', N'DA21TTB', N'CV02', N'f763398a-bcc5-47dd-8b4e-38d519c58c4e.png')
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'110121098', N'Đỗ Cao Trí', CAST(0x0700000000004F280B AS DateTime2), N'0323656564', N'110121098', N'DA21TTC', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'110121182', N'Phạm Thúy Hằng', CAST(0x070000000000000000 AS DateTime2), N'0323656564', N'hangnguyenpham2424@gmail.com', N'DA21TTB', N'CV02', N'a8de6c25-0325-4d2f-8345-bef19cbcd963.png')
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'110121333', N'Nguyễn Hữu Luân', CAST(0x0700000000007A280B AS DateTime2), N'0366203656', N'nguyenluan@gmail.com', N'DA21TTC', N'CV01', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'113265659', N'Trương Hoàng Giang', CAST(0x070000000000E9290B AS DateTime2), N'032655656', N'hoanggiang@gmail.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV011', N'TênSV11', CAST(0x07000000000042250B AS DateTime2), N'0123456779', N'sv011@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV012', N'TênSV12', CAST(0x07000000000061250B AS DateTime2), N'0123456778', N'sv012@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV013', N'TênSV13', CAST(0x07000000000013240B AS DateTime2), N'0123456777', N'sv013@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV014', N'TênSV14', CAST(0x07000000000033240B AS DateTime2), N'0123456776', N'sv014@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV015', N'TênSV15', CAST(0x07000000000051240B AS DateTime2), N'0123456775', N'sv015@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV016', N'TênSV16', CAST(0x07000000000071240B AS DateTime2), N'0123456774', N'sv016@example.com', N'DA21TTB', N'CV03', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV017', N'TênSV17', CAST(0x07000000000090240B AS DateTime2), N'0123456773', N'sv017@example.com', N'DA21TTB', N'CV04', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV018', N'TênSV18', CAST(0x070000000000B0240B AS DateTime2), N'0123456772', N'sv018@example.com', N'DA21TTB', N'CV04', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV019', N'TênSV19', CAST(0x070000000000CF240B AS DateTime2), N'0123456771', N'sv019@example.com', N'DA21TTB', N'CV04', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [NgaySinh], [DienThoai], [Email], [MaLop], [MaChucVu], [HinhAnh]) VALUES (N'SV020', N'TênSV20', CAST(0x070000000000EF240B AS DateTime2), N'0123456770', N'sv020@example.com', N'DA21TTB', N'CV04', NULL)
/****** Object:  Table [dbo].[DangKyHoatDong]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 04/01/2024 15:14:10 ******/
/****** Object:  Table [dbo].[TinTuc]    Script Date: 04/01/2024 15:14:10 ******/
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT003', N'Thông Báo 1', N'Nguồn gốc của Lorem Ipsum hay nói cách khác là nó được sử dụng từ khi nào thì vẫn còn nhiều tranh cãi. Theo trang lipsum.com thì Lorem Ipsum không chỉ đơn giản là văn bản ngẫu nhiên như nhiều người nghĩ. Nó có nguồn gốc từ một tác phẩm văn học Latinh cổ điển từ năm ', CAST(0x07000000000081460B AS DateTime2), N'01', NULL, NULL)
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT004', N'Thông báo 3', N'Nguồn gốc của Lorem Ipsum hay nói cách khác là nó được sử dụng từ khi nào thì vẫn còn nhiều tranh cãi. Theo trang lipsum.com thì Lorem Ipsum không chỉ ...', CAST(0x07000000000099460B AS DateTime2), N'SV01', NULL, NULL)
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT005', N'Thông báo 4', N'Nguồn gốc của Lorem Ipsum hay nói cách khác là nó được sử dụng từ khi nào thì vẫn còn nhiều tranh cãi. Theo trang lipsum.com thì Ipsum không chỉ 2 ...', CAST(0x07000000000099460B AS DateTime2), N'SV002', NULL, NULL)
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT006', N'Thông báo 5', N'Nguồn gốc của Lorem Ipsum hay nói cách khác là nó được sử dụng từ khi nào thì vẫn còn nhiều tranh cãi. Theo trang lipsum.com thì Ipsum không chỉ 2 ...', CAST(0x07000000000080470B AS DateTime2), N'Nguyễn Đại Hoàng Phú', NULL, NULL)
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT01', N'Lorem', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', CAST(0x07000000000077460B AS DateTime2), N'110121087', NULL, NULL)
INSERT [dbo].[TinTuc] ([MaTinTuc], [TieuDe], [NoiDung], [NgayDang], [NguoiDang], [SinhVienMaSV], [HinhAnh]) VALUES (N'TT02', N'Thông Báo 2', N'Nguồn gốc của Lorem Ipsum hay nói cách khác là nó được sử dụng từ khi nào thì vẫn còn nhiều tranh cãi. Theo trang lipsum.com thì Lorem Ipsum không chỉ đơn giản là văn bản ngẫu nhiên như nhiều người nghĩ. Nó có nguồn gốc từ một tác phẩm văn học Latinh cổ điển từ năm ', CAST(0x07000000000069460B AS DateTime2), N'SV017', NULL, NULL)
/****** Object:  Table [dbo].[ThamGiaHoatDong]    Script Date: 04/01/2024 15:14:10 ******/
