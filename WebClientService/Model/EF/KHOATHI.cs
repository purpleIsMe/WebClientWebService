namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOATHI")]
    public partial class KHOATHI
    {
        [Key]
        [StringLength(50)]
        public string MaKhoaThi { get; set; }

        [StringLength(50)]
        public string TenKhoaThi { get; set; }

        public bool TrangThai { get; set; }
        public int id { get; set; }
    }
}
