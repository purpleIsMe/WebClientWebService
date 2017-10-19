namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Page")]
    public partial class Page
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Alias { get; set; }

        [Required]
        [StringLength(500)]
        public string PContent { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        [Required]
        [StringLength(100)]
        public string UpdateBy { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(100)]
        public string MetaKeyword { get; set; }

        [Required]
        [StringLength(100)]
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }
    }
}
