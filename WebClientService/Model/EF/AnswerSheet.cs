using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("AnswerSheet")]
    public class AnswerSheet
    {
        [Key]
        public int IDAnswer { set; get; }
        
        [Key]
        public int ThuTuCauHoi { set; get; }

        [Required]
        public int Answer { set; get; }

        public Guid QuestionID { set; get; }

        public int DapAn { set; get; }

        [ForeignKey("IDAnswer")]
        public virtual Answer ID { set; get; }

    }
}
