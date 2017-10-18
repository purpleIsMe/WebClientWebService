using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("DETRON_QUESTION")]
    public class DETRON_QUESTION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAuto { set; get; }

        [Key]
        public int IDDeTron { set; get; }

        [Key]
        public Guid QuestionID { set; get; }

        [Required]
        public int Answer1 { set; get; }

        [Required]
        public int Answer2 { set; get; }

        [Required]
        public int Answer3 { set; get; }

        [Required]
        public int Answer4 { set; get; }

        [Required]
        public int DapAn { set; get; }

        public int TheAnswer { set; get; }
    }
}
