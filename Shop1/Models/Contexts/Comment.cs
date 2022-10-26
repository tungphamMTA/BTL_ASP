namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }
    }
}
