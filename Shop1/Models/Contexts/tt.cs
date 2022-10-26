namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tt")]
    public partial class tt
    {
        [Key]
        [StringLength(5)]
        public string MaDH { get; set; }

        public decimal? TienGiay { get; set; }
    }
}
