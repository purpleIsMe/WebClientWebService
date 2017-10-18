using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Model.EF
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuestionID { set; get; }

        [MaxLength(50)]
        public string QuestionNbr { set; get; }

        public Guid ClassID { set; get; }

        public Guid MentalityTypeID { set; get; }

        public Guid SubjectID { set; get; }
    
        public Guid OSubjectID { set; get; }
      
        public Image Content { set; get; }

        public Image Questions { set; get; }

        public int NoOfAnswers { set; get; }

        public int TheAnswer { set; get; }

        public Image Answer1 { set; get; }

        public Image Answer2 { set; get; }

        public Image Answer3 { set; get; }

        public Image Answer4 { set; get; }

        public Image CustomAnswer { set; get; }

        [Required]
        public bool Answer1SwapYN { set; get; }

        [Required]
        public bool Answer2SwapYN { set; get; }

        [Required]
        public bool Answer3SwapYN { set; get; }

        [Required]
        public bool Answer4SwapYN { set; get; }

        [Required]
        public bool Answer5SwapYN { set; get; }

        public int MaxAnswerLen { set; get; }

        [Required]
        public bool SkipAnswersYN { set; get; }

        [Required]
        public bool GroupYN { set; get; }

        [Required]
        public bool ChildYN { set; get; }

        public Guid ParentID { set; get; }
        
        public int NoOfChildren { set; get; }

        [Required]
        public bool ChildSwapYN { set; get; }

        public int ChildOrderNo { set; get; }

        public int TestOrderNo { set; get; }
        
        public int GroupNo { set; get; }

        [MaxLength(8)]
        public string QVersion { set; get; }

        public int DiffID { set; get; } //trong SQL: DiffID(smallint,null)

        public int Used { set; get; }

        [Required]
        public int QID { set; get; }

        public DateTime DateAdd { set; get; }

        [MaxLength(50)]
        public string UserAccess { set; get; }

        [MaxLength(50)]
        public string HostName { set; get; }

        public bool Active { set; get; }
    }
}
