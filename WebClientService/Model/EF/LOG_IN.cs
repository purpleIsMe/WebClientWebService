using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("LOG_IN")]
    public class LOG_IN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(50)]
        public string IPAddrress { set; get; }

        public int IDUser { set; get; }

        [Required]
        public DateTime DateAccess { set; get; }
    }
}
