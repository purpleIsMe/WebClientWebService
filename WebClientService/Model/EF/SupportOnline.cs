namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupportOnline")]
    public partial class SupportOnline
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(256)]
        public string Skype { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string google { get; set; }

        [StringLength(500)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Zalo { get; set; }

        public bool Active { get; set; }
    }
}
