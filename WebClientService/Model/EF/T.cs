namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T
    {
        public Guid? QuestionID { get; set; }

        [StringLength(50)]
        public string QuestionNbr { get; set; }

        public Guid? SubjectID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        [Column(TypeName = "image")]
        public byte[] Question { get; set; }

        public int? NoOfAnswers { get; set; }

        public int? TheAnswer { get; set; }

        [Column(TypeName = "image")]
        public byte[] Answer1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Answer2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Answer3 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Answer4 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Answer5 { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool Answer1SwapYN { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Answer2SwapYN { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Answer3SwapYN { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Answer4SwapYN { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Answer5SwapYN { get; set; }

        public int? MaxAnswerLen { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool SkipAnswersYN { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool GroupYN { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool ChildYN { get; set; }

        public Guid? ParentID { get; set; }

        public int? NoOfChildren { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool ChildSwapYN { get; set; }

        public int? ChildOrderNo { get; set; }

        public int? TestOrderNo { get; set; }

        public int? GroupNo { get; set; }
    }
}
