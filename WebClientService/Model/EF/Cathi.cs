namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaThi")]
    public partial class CaThi
    {
        public int ID { get; set; }

        public DateTime GioBD { get; set; }

        public DateTime GioKT { get; set; }

        public DateTime Ngay { get; set; }

        public Guid SubjectID { get; set; }

        public bool TrangThai { get; set; }

        public bool HoanThanh { get; set; }

        [StringLength(50)]
        public string MaGiamThi1 { get; set; }

        [StringLength(50)]
        public string MaGiamThi2 { get; set; }

        public int? IDDeChuan { get; set; }

        [StringLength(200)]
        public string TenCaThi { get; set; }

        public virtual DeChuan DeChuan { get; set; }
    }
}
