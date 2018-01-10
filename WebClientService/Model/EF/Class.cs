namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [Key]
        public int IDClass { get; set; }

        public int IDLecturer { get; set; }

        [StringLength(200)]
        public string NameClass { get; set; }
    }
}
