using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("SYSTEMCONFIG")]
    public class SYSTEMCONFIG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }


        [Required]
        [MaxLength(50)]
        public string Code { set; get; }

        [Required]
        [MaxLength(50)]
        public string ValueString { set; get; }

        [Required]
        public int ValueInt { set; get; }
    }
}
