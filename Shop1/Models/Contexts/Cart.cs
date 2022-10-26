namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Required]
        [StringLength(50)]
        public string IDUser { get; set; }

        [Required]
        [StringLength(5)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(5)]
        public string MaMau { get; set; }

        public int? Size { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAdd { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        public double? Total { get; set; }

        [Key]
        public int IDCart { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual CTSP CTSP { get; set; }
    }
}
