namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [Key]
        [StringLength(50)]
        public string MaPhong { get; set; }

        [StringLength(50)]
        public string TenPhong { get; set; }

        public int? SoLuongMay { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public bool TrangThai { get; set; }
    }
}
