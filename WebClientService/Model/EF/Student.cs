namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime Born { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Zalo { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public bool Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public int IDClass { get; set; }
        public int idlecturer { get; set; }
    }
}
