namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHangKH")]
    public partial class DonHangKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHangKH()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(5)]
        public string MaDH { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKH { get; set; }

        public decimal? PhiVanChuyen { get; set; }

        [StringLength(200)]
        public string PTGiaoDich { get; set; }

        public DateTime? NgayDatMua { get; set; }

        [StringLength(50)]
        public string TinhTrangDH { get; set; }

        public double? Tongtien { get; set; }

        [Column(TypeName = "text")]
        public string Ghichu { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(15)]
        public string Dienthoai { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
