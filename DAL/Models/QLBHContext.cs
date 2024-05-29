using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDh> ChiTietDhs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GiamGia> GiamGia { get; set; }
        public virtual DbSet<GiaoHang> GiaoHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamSize> SanPhamSizes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-OPTFD94M\\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDh>(entity =>
            {
                entity.HasKey(e => new { e.MaDh, e.MaSp, e.MaGiamGia })
                    .HasName("PK_ChiTietDH_1");

                entity.ToTable("ChiTietDH");

                entity.Property(e => e.MaSp).HasMaxLength(10);

                entity.Property(e => e.MaGiamGia)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDhs)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDH_DonHang");

                entity.HasOne(d => d.MaGiamGiaNavigation)
                    .WithMany(p => p.ChiTietDhs)
                    .HasForeignKey(d => d.MaGiamGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDH_GiamGia");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDhs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDH_SanPham");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh)
                    .HasName("PK__DonHang__272586610B442BEB");

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.DcgiaoHang)
                    .HasMaxLength(50)
                    .HasColumnName("DCGiaoHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(5)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(5)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MaShipper).HasMaxLength(5);

                entity.Property(e => e.NgayDatHang).HasColumnType("date");

                entity.Property(e => e.NgayGiaoHang).HasColumnType("date");

                entity.Property(e => e.PhiVc).HasColumnName("PhiVC");

                entity.Property(e => e.TinhThanhDh)
                    .HasMaxLength(20)
                    .HasColumnName("TinhThanhDH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_DonHang_NhanVien");

                entity.HasOne(d => d.MaShipperNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaShipper)
                    .HasConstraintName("FK_DonHang_GiaoHang");
            });

            modelBuilder.Entity<GiamGia>(entity =>
            {
                entity.HasKey(e => e.MaGiamGia);

                entity.Property(e => e.MaGiamGia)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenMaGiam)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GiaoHang>(entity =>
            {
                entity.HasKey(e => e.MaShipper)
                    .HasName("PK__GiaoHang__5C944AF655473761");

                entity.ToTable("GiaoHang");

                entity.Property(e => e.MaShipper).HasMaxLength(5);

                entity.Property(e => e.DonViGiao).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1E599E0F84");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(5)
                    .HasColumnName("MaKH");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoKh)
                    .HasMaxLength(10)
                    .HasColumnName("HoKH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TinhThanh)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.MaLh)
                    .HasName("PK__LoaiHang__2725C77F274A8536");

                entity.ToTable("LoaiHang");

                entity.Property(e => e.MaLh)
                    .HasMaxLength(10)
                    .HasColumnName("MaLH");

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenLh)
                    .HasMaxLength(20)
                    .HasColumnName("TenLH");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A51C258B1");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(5)
                    .HasColumnName("MaNV");

                entity.Property(e => e.ChucVu).HasMaxLength(15);

                entity.Property(e => e.DiaChiNv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DiaChiNV");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoNv)
                    .HasMaxLength(10)
                    .HasColumnName("HoNV");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(10)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CDD3CD23E");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP");

                entity.Property(e => e.MaLh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaLH");

                entity.Property(e => e.MauSac).HasMaxLength(20);

                entity.Property(e => e.NgayNhapHang).HasColumnType("date");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLhNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_LoaiHang");
            });

            modelBuilder.Entity<SanPhamSize>(entity =>
            {
                entity.HasKey(e => new { e.Size, e.MaSp });

                entity.ToTable("SanPham_Size");

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp).HasMaxLength(10);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.SanPhamSizes)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_Size_SanPham");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.SanPhamSizes)
                    .HasForeignKey(d => d.Size)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_Size_Size");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Size1)
                    .HasName("PK_Size_1");

                entity.ToTable("Size");

                entity.Property(e => e.Size1)
                    .HasMaxLength(10)
                    .HasColumnName("Size")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
