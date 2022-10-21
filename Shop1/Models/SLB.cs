namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLB")]
    public partial class SLB
    {
        [Key]
        [StringLength(5)]
        public string MaSP { get; set; }

        public int? SL { get; set; }
    }
}
