namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MaSP { get; set; }

        public double? TongTien { get; set; }

        public decimal? PhiVanChuyen { get; set; }

        [StringLength(50)]
        public string TinhTrangDH { get; set; }

        [StringLength(200)]
        public string PTGiaoDich { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }
    }
}
