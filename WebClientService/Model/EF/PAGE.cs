using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebClient.Model.Abstract;

namespace Model.EF
{
    [Table("PAGE")]
    public class PAGE:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(200)]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        [Required]
        [MaxLength(500)]
        public string PContent { set; get; }

        [Required]
        public bool Active { set; get; }

    }
}
