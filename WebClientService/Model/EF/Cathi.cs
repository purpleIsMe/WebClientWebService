namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATHI")]
    public partial class CATHI
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKhoaThi { get; set; }

        [StringLength(50)]
        public string Ca { get; set; }

        public DateTime GioBatDau { get; set; }

        public DateTime GioKetThuc { get; set; }

        public DateTime Ngay { get; set; }

        public bool TrangThai { get; set; }

        public bool DaHoanThanh { get; set; }
    }
}
