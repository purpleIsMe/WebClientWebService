namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionTemp")]
    public partial class QuestionTemp
    {
        [Key]
        public Guid QuestionID { get; set; }

        [StringLength(50)]
        public string QuestionNbr { get; set; }

        public Guid? ClassID { get; set; }

        public Guid? MentalityTypeID { get; set; }

        public Guid? SubjectID { get; set; }

        public Guid? OSubjectID { get; set; }

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

        [Column(TypeName = "image")]
        public byte[] CustomAnswer { get; set; }

        public bool Answer1SwapYN { get; set; }

        public bool Answer2SwapYN { get; set; }

        public bool Answer3SwapYN { get; set; }

        public bool Answer4SwapYN { get; set; }

        public bool Answer5SwapYN { get; set; }

        public int? MaxAnswerLen { get; set; }

        public bool SkipAnswersYN { get; set; }

        public bool GroupYN { get; set; }

        public bool ChildYN { get; set; }

        public Guid? ParentID { get; set; }

        public int? NoOfChildren { get; set; }

        public bool ChildSwapYN { get; set; }

        public int? ChildOrderNo { get; set; }

        public int? TestOrderNo { get; set; }

        public int? GroupNo { get; set; }

        [StringLength(8)]
        public string QVersion { get; set; }

        public short? DiffID { get; set; }

        public int? Used { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QID { get; set; }

        public DateTime? DateAdd { get; set; }

        [StringLength(50)]
        public string UserAccess { get; set; }

        [StringLength(50)]
        public string HostName { get; set; }

        public bool? Active { get; set; }
    }
}
