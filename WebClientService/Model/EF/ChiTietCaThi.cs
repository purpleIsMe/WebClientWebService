namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietCaThi")]
    public partial class ChiTietCaThi
    {
        public int ID { get; set; }

        public int IDCa { get; set; }

        [StringLength(50)]
        public string MaChiTietCa { get; set; }

        public Guid SubjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPhong { get; set; }

        public bool TrangThai { get; set; }

        public bool HoanThanh { get; set; }

        [StringLength(50)]
        public string MaGiamThi1 { get; set; }

        [StringLength(50)]
        public string MaGiamThi2 { get; set; }

        public int? IDDeChuan { get; set; }
    }
}
