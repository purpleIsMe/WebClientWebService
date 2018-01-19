namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QClass")]
    public partial class QClass
    {
        [Key]
        public Guid ClassID { get; set; }

        public Guid? SubjectID { get; set; }

        public int? ClassNbr { get; set; }

        [StringLength(200)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string ChuThich { get; set; }

        public bool TrangThai { get; set; }

        public int idsu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQClass { get; set; }
    }
}
