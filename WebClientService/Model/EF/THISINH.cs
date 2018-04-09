namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THISINH")]
    public partial class THISINH
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDuThi { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public int MaCaThi { get; set; }

        public int MaDeThi { get; set; }

        public bool TrangThai { get; set; }

        [StringLength(50)]
        public string SoMay { get; set; }

        public bool DaHoanThanh { get; set; }

        public int ThoiGian { get; set; }
    }
}
