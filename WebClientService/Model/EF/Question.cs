namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            DeChuanQuestions = new HashSet<DeChuanQuestion>();
            DeTronQuestions = new HashSet<DeTronQuestion>();
            DeTronQuestions1 = new HashSet<DeTronQuestion>();
        }

        public Guid QuestionID { get; set; }

        [StringLength(50)]
        public string QuestionNbr { get; set; }

        public Guid? ClassID { get; set; }

        public Guid? MentalityTypeID { get; set; }

        public Guid? SubjectID { get; set; }

        public Guid? OSubjectID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        [Column("Question", TypeName = "image")]
        public byte[] Question1 { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeChuanQuestion> DeChuanQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTronQuestion> DeTronQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTronQuestion> DeTronQuestions1 { get; set; }

        public virtual QClass QClass { get; set; }
    }
}
