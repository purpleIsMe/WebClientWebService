namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogIn")]
    public partial class LogIn
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string IDAddress { get; set; }

        public int? IDUser { get; set; }

        public DateTime DateAccess { get; set; }
    }
}
