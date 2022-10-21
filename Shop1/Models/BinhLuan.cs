namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public int MaBL { get; set; }

        [StringLength(5)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        [Required]
        [StringLength(1)]
        public string DaTraLoi { get; set; }

        public int? Parent { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
