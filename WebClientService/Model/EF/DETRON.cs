namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETRON")]
    public partial class DETRON
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDeTron { get; set; }

        [StringLength(50)]
        public string TenDeTron { get; set; }

        public int MaDeChuan { get; set; }

        public virtual DECHUAN DECHUAN { get; set; }
    }
}
