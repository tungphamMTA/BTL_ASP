namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
            CTSP = new HashSet<CTSP>();
            HopDongNCC = new HashSet<HopDongNCC>();
            SanPhamKhuyenMai = new HashSet<SanPhamKhuyenMai>();
            ThongSo = new HashSet<ThongSo>();
            Sanphamcanmua = new HashSet<Sanphamcanmua>();
        }

        [Key]
        [StringLength(5)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuotXemSP { get; set; }

        [Required]
        [StringLength(5)]
        public string HangSX { get; set; }

        [StringLength(50)]
        public string XuatXu { get; set; }

        public decimal? GiaGoc { get; set; }

        public decimal? GiaTien { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public string AnhDaiDien { get; set; }

        public string AnhNen { get; set; }

        public int? SoLuong { get; set; }

        public bool? isnew { get; set; }

        public bool? issale { get; set; }

        public int? SoLuongBan { get; set; }

        public int? GiaSale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSP> CTSP { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongNCC> HopDongNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongSo> ThongSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanphamcanmua> Sanphamcanmua { get; set; }
    }
}
