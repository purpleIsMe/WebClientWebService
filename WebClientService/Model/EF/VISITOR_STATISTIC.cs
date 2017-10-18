using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("VISITOR_STATISTIC")]
    public class VISITOR_STATISTIC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { set; get; }

        [Required]
        public DateTime VisitedDate { set; get; }

        [Required]
        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}
