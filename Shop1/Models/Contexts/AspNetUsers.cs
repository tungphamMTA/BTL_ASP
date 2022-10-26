namespace Shop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUsers()
        {
            BinhLuan = new HashSet<BinhLuan>();
            Cart = new HashSet<Cart>();
            DonHangKH = new HashSet<DonHangKH>();
        }

        [Key]
        [StringLength(50)]
        public string IDUser { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public string SDT { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [StringLength(5)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(256)]
        public string DiaChi { get; set; }

        [Column(TypeName = "text")]
        public string Avatar { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public bool? IsAdmin { get; set; }

        [StringLength(50)]
        public string GroupID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangKH> DonHangKH { get; set; }
    }
}
