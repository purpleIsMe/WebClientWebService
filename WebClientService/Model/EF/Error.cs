namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Error")]
    public partial class Error
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Messages { get; set; }

        [StringLength(300)]
        public string StackTrace { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
