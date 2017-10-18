using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("SLIDE")]
    public class SLIDE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        [Required]
        [MaxLength(200)]
        public string Image { set; get; }

        [Required]
        [MaxLength(500)]
        public string URL { set; get; }

        [Required]
        public bool Active { set; get; }
    }
}
