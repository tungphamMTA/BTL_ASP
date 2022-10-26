namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MaMau { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Size { get; set; }

        public virtual CTSP CTSP { get; set; }

        public virtual DonHangKH DonHangKH { get; set; }
    }
}
