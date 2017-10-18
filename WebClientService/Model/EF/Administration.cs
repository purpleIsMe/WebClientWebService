using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Administration")]
    public class Administration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        [Required]
        public DateTime Born { set; get; }

        [Required]
        [MaxLength(200)]
        public string Address { set; get; }

        [Required]
        [MaxLength(100)]
        public string Position { set; get; }

        [Required]
        [MaxLength(15)]
        public string Mobile { set; get; }

        [MaxLength(100)]
        public string Skype { set; get; }

        public string Email { set; get; }

        [MaxLength(100)]
        public string Zalo { set; get; }

        [MaxLength(100)]
        public string Facebook { set; get; }

        [Required]
        public bool Active { set; get; }

        
    }
}
