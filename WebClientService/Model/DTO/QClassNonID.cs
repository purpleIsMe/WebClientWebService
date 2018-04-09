using System;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class QClassNonID
    {
        [Key]
        public Guid ClassID { get; set; }

        public Guid? SubjectID { get; set; }

        public int? ClassNbr { get; set; }

        [StringLength(200)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string ChuThich { get; set; }

        public bool? TrangThai { get; set; }
    }
}
