using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Models;

public partial class QuanLyThuVienContext : DbContext
{
    public QuanLyThuVienContext()
    {
    }

    public QuanLyThuVienContext(DbContextOptions<QuanLyThuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<DocGia> DocGia { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TacGia> TacGia { get; set; }

    public virtual DbSet<TaiKhoanDocGia> TaiKhoanDocGia { get; set; }

    public virtual DbSet<TaiKhoanNhanVien> TaiKhoanNhanViens { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-7NRT0S5C;Database=QuanLyThuVien;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietPhieuMuon>(entity =>
        {
            entity.HasKey(e => new { e.MaPm, e.MaSach }).HasName("PK__ChiTietP__EC06B0BD9FB6A1C5");

            entity.ToTable("ChiTietPhieuMuon", tb => tb.HasTrigger("trg_CapNhatSoLuongSach"));

            entity.Property(e => e.MaPm).HasColumnName("MaPM");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");
            entity.Property(e => e.TienPhat)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TinhTrangSach)
                .HasMaxLength(50)
                .HasDefaultValue("Bình thường");

            entity.HasOne(d => d.MaPmNavigation).WithMany(p => p.ChiTietPhieuMuons)
                .HasForeignKey(d => d.MaPm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaPM__5812160E");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPhieuMuons)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaSac__59063A47");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPn, e.MaSach }).HasName("PK__ChiTietP__EC06B0B2943C8888");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaPnNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaPN__05D8E0BE");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaSac__06CD04F7");
        });

        modelBuilder.Entity<DocGia>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("PK__DocGia__27258660ECB9B89D");

            entity.HasIndex(e => e.Sdt, "UQ__DocGia__CA1930A534FB427B").IsUnique();

            entity.Property(e => e.MaDg).HasColumnName("MaDG");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgayLapThe).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEBE71AA915");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(200)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK__NhaXuatB__3A19482CAB2A315C");

            entity.ToTable("NhaXuatBan");

            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.TenNxb)
                .HasMaxLength(100)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A40BE6692");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Sdt, "UQ__NhanVien__CA1930A55A0EB012").IsUnique();

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.ChucVu)
                .HasMaxLength(50)
                .HasDefaultValue("Thủ thư");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Luong)
                .HasDefaultValue(5000000m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayVaoLam).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<PhieuMuon>(entity =>
        {
            entity.HasKey(e => e.MaPm).HasName("PK__PhieuMuo__2725E7FF0D5C83B0");

            entity.ToTable("PhieuMuon");

            entity.Property(e => e.MaPm).HasColumnName("MaPM");
            entity.Property(e => e.MaDg).HasColumnName("MaDG");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.NgayMuon)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaDg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuMuon__MaDG__5165187F");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuMuon__MaNV__52593CB8");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPn).HasName("PK__PhieuNha__2725E7F0C912B0A9");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayNhap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__MaNCC__01142BA1");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__MaNV__00200768");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742DABE273C7");

            entity.ToTable("Sach");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.MaTg).HasColumnName("MaTG");
            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.NamXb).HasColumnName("NamXB");
            entity.Property(e => e.SoLuongTon).HasDefaultValue(0);
            entity.Property(e => e.TenSach).HasMaxLength(200);
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(50)
                .HasDefaultValue("Mới");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK__Sach__MaNXB__4D94879B");

            entity.HasOne(d => d.MaTgNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTg)
                .HasConstraintName("FK__Sach__MaTG__4CA06362");

            entity.HasOne(d => d.MaTlNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTl)
                .HasConstraintName("FK__Sach__MaTL__4BAC3F29");
        });

        modelBuilder.Entity<TacGia>(entity =>
        {
            entity.HasKey(e => e.MaTg).HasName("PK__TacGia__272500740751940B");

            entity.Property(e => e.MaTg).HasColumnName("MaTG");
            entity.Property(e => e.TenTg)
                .HasMaxLength(100)
                .HasColumnName("TenTG");
            entity.Property(e => e.Website).HasMaxLength(200);
        });

        modelBuilder.Entity<TaiKhoanDocGia>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TaiKhoan__27250070563BBD0E");

            entity.HasIndex(e => e.MaDg, "UQ__TaiKhoan__2725866140E558B9").IsUnique();

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0707BDAF6").IsUnique();

            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.MaDg).HasColumnName("MaDG");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDu)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SoLuongMuonToiDa).HasDefaultValue(5);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaDgNavigation).WithOne(p => p.TaiKhoanDocGium)
                .HasForeignKey<TaiKhoanDocGia>(d => d.MaDg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoanDo__MaDG__778AC167");
        });

        modelBuilder.Entity<TaiKhoanNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TaiKhoan__2725007047310483");

            entity.ToTable("TaiKhoanNhanVien");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC024E3246E").IsUnique();

            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasDefaultValue(1);
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTl).HasName("PK__TheLoai__27250071734AF185");

            entity.ToTable("TheLoai");

            entity.HasIndex(e => e.TenTl, "UQ__TheLoai__4CF9E7760393C54A").IsUnique();

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.TenTl)
                .HasMaxLength(100)
                .HasColumnName("TenTL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
