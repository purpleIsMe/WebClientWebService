namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
