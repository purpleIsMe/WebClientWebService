using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubjectID { set; get; }

        [Required]
        [MaxLength(50)]
        public string SubjectNbr { set; get; }

        public Guid ParentID { set; get; }

        [MaxLength(200)]
        public string Descr { set; get; }

        [MaxLength(20)]
        public string Prefix { set; get; }

        [MaxLength(100)]
        public string Author { set; get; }

        [MaxLength(100)]
        public string Office { set; get; }

        public DateTime CreateDate { set; get; }

        [Required]
        public bool AnswerOption { set; get; }

        public int RoundMode { set; get; }

        [MaxLength(255)]
        public string Path { set; get; }

        [MaxLength(255)]
        public string filemau { set; get; }

        public int NoOfAnswers { set; get; }

        public int NoOfQuestions { set; get; }

        public int From1 { set; get; }

        public int NoQuest1 { set; get; }

        public int From2 { set; get; }

        public int NoQuest2 { set; get; }

        public int From3 { set; get; }

        public int NoQuest3 { set; get; }

        public int MarkOpt { set; get; } //SQL: smallint

        public float Minus { set; get; } //SQL: real

        [MaxLength(255)]
        public string Text1 { set; get; }

        [MaxLength(255)]
        public string Text2 { set; get; }

        [MaxLength(255)]
        public string Text3 { set; get; }

        [MaxLength(255)]
        public string Text4 { set; get; }

        public string Text5 { set; get; }

        public DateTime ExecuteDate { set; get; }

        public DateTime ExecuteTime { set; get; }
        
        public int ExecutingTimeAmt { set; get; }

        public Guid HeaderID { set; get; }

        public Guid FooterID { set; get; }

        public Guid TemplateID { set; get; }

        [Required]
        public bool Locked { set; get; }

        public int GroupCount { set; get; }

        public int ParQSpaceBefore { set; get; }
        
        public int ParMQSpaceBefore { set; get; }
        
        public float ParQLeftIndent { set; get; }
        
        public float ParMQLeftIndent { set; get; }
        
        public int ParFontSize { set; get; }

        [MaxLength(100)]
        public string ParFontName { set; get; }
        
        public float Double1 { set; get; } //SLQ: Double1(real, null)

        public float Double2 { set; get; }
        
        public float Double3 { set; get; }
        
        public float Double4 { set; get; }
        
        public bool SkipSwap { set; get; }

        public int cblank { set; get; }

        public int cdouble { set; get; }

        [Required]
        public bool clogic { set; get; }

        [Required]
        public int pfsbd { set; get; }

        [Required]
        public int pnsbd { set; get; }

        public int pfmade { set; get; }

        public int pnmade { set; get; }

        public int pftraloi { set; get; }

        public int pntraloi { set; get; }

        public int pflo { set; get; }

        public int pnlo { set; get; }

        public int pfimage    { set; get; }

        [Required]
        public int pnimage { set; get; }

        [MaxLength(50)]
        public string pblank { set; get; }

        [MaxLength(50)]
        public string pdouble { set; get; }

        [Required]
        public bool roundToZero { set; get; }

        [Required]
        public bool skipMinus { set; get; }

        public float MaxPoint { set; get; }//Real

        public float MinPoint { set; get; } //Real

        [Required]
        public bool qBack { set; get; }

        public int loop { set; get; }

        public int MaxUsed { set; get; }
    }
}
