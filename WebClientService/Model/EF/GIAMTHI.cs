namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAMTHI")]
    public partial class GIAMTHI
    {
        [Key]
        [StringLength(50)]
        public string MaGiamThi { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public bool GioTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public bool? TrangThai { get; set; }
    }
}
