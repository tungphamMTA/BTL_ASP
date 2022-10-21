using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Shop1.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<CTSP> CTSP { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DanhsachdangkisanphamNCC> DanhsachdangkisanphamNCC { get; set; }
        public virtual DbSet<DonHangKH> DonHangKH { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuat { get; set; }
        public virtual DbSet<HopDongNCC> HopDongNCC { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<Mau> Mau { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Sanphamcanmua> Sanphamcanmua { get; set; }
        public virtual DbSet<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }
        public virtual DbSet<ThongSo> ThongSo { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<SLB> SLB { get; set; }
        public virtual DbSet<tt> tt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<AspNetUsers>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUsers>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.BinhLuan)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.AspNetUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.DonHangKH)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.DaTraLoi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.MaMau)
                .IsFixedLength();

            modelBuilder.Entity<CTSP>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<CTSP>()
                .Property(e => e.MaMau)
                .IsFixedLength();

            modelBuilder.Entity<CTSP>()
                .HasMany(e => e.Cart)
                .WithOptional(e => e.CTSP)
                .HasForeignKey(e => new { e.MaSP, e.MaMau, e.Size });

            modelBuilder.Entity<CTSP>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.CTSP)
                .HasForeignKey(e => new { e.MaSP, e.MaMau, e.Size })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaDH)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaMau)
                .IsFixedLength();

            modelBuilder.Entity<DanhsachdangkisanphamNCC>()
                .Property(e => e.MaNCC)
                .IsFixedLength();

            modelBuilder.Entity<DanhsachdangkisanphamNCC>()
                .Property(e => e.Ghichu)
                .IsUnicode(false);

            modelBuilder.Entity<DonHangKH>()
                .Property(e => e.MaDH)
                .IsFixedLength();

            modelBuilder.Entity<DonHangKH>()
                .Property(e => e.PhiVanChuyen)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHangKH>()
                .Property(e => e.TinhTrangDH)
                .IsUnicode(false);

            modelBuilder.Entity<DonHangKH>()
                .Property(e => e.Ghichu)
                .IsUnicode(false);

            modelBuilder.Entity<DonHangKH>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<DonHangKH>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonHangKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangSanXuat>()
                .Property(e => e.HangSX)
                .IsFixedLength();

            modelBuilder.Entity<HangSanXuat>()
                .HasMany(e => e.SanPham)
                .WithRequired(e => e.HangSanXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDongNCC>()
                .Property(e => e.MaHD)
                .IsFixedLength();

            modelBuilder.Entity<HopDongNCC>()
                .Property(e => e.MaNCC)
                .IsFixedLength();

            modelBuilder.Entity<HopDongNCC>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<HopDongNCC>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.MaKM)
                .IsFixedLength();

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.AnhCT)
                .IsUnicode(false);

            modelBuilder.Entity<Mau>()
                .Property(e => e.MaMau)
                .IsFixedLength();

            modelBuilder.Entity<Mau>()
                .HasMany(e => e.CTSP)
                .WithRequired(e => e.Mau)
                .HasForeignKey(e => new { e.MaMau, e.Size })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsFixedLength();

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT_NCC)
                .IsFixedLength();

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.HopDongNCC)
                .WithOptional(e => e.NhaCungCap)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.HangSX)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaGoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.BinhLuan)
                .WithOptional(e => e.SanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTSP)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.HopDongNCC)
                .WithOptional(e => e.SanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.Sanphamcanmua)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sanphamcanmua>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<Sanphamcanmua>()
                .HasMany(e => e.DanhsachdangkisanphamNCC)
                .WithOptional(e => e.Sanphamcanmua)
                .HasForeignKey(e => e.MaSPCanMua)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPhamKhuyenMai>()
                .Property(e => e.MaKM)
                .IsFixedLength();

            modelBuilder.Entity<SanPhamKhuyenMai>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<ThongSo>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<Comment>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaDH)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.PhiVanChuyen)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TinhTrangDH)
                .IsUnicode(false);

            modelBuilder.Entity<SLB>()
                .Property(e => e.MaSP)
                .IsFixedLength();

            modelBuilder.Entity<tt>()
                .Property(e => e.MaDH)
                .IsFixedLength();

            modelBuilder.Entity<tt>()
                .Property(e => e.TienGiay)
                .HasPrecision(38, 0);
        }
    }
}
