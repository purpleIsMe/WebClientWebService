namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(256)]
        public string URL { get; set; }

        public int IDGroup { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public bool Active { get; set; }

        public virtual MenuGroup MenuGroup { get; set; }
    }
}
