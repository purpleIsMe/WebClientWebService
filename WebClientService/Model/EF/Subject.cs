namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            QClasses = new HashSet<QClass>();
        }

        public Guid SubjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubjectNbr { get; set; }

        public Guid? ParentID { get; set; }

        [StringLength(200)]
        public string Descr { get; set; }

        [StringLength(20)]
        public string Prefix { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(100)]
        public string Office { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool AnswerOption { get; set; }

        public int? RoundMode { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        [StringLength(255)]
        public string filemau { get; set; }

        public int? NoOfAnswers { get; set; }

        public int? NoOfQuestions { get; set; }

        public int? From1 { get; set; }

        public int? NoQuest1 { get; set; }

        public int? From2 { get; set; }

        public int? NoQuest2 { get; set; }

        public int? From3 { get; set; }

        public int? NoQuest3 { get; set; }

        public short? MarkOpt { get; set; }

        public float? Minus { get; set; }

        [StringLength(255)]
        public string Text1 { get; set; }

        [StringLength(255)]
        public string Text2 { get; set; }

        [StringLength(255)]
        public string Text3 { get; set; }

        [StringLength(255)]
        public string Text4 { get; set; }

        [StringLength(255)]
        public string Text5 { get; set; }

        public DateTime? ExecuteDate { get; set; }

        public DateTime? ExecuteTime { get; set; }

        public int? ExecutingTimeAmt { get; set; }

        public Guid? HeaderID { get; set; }

        public Guid? FooterID { get; set; }

        public Guid? TemplateID { get; set; }

        public bool Locked { get; set; }

        public int? GroupCount { get; set; }

        public int? ParQSpaceBefore { get; set; }

        public int? ParMQSpaceBefore { get; set; }

        public double? ParQLeftIndent { get; set; }

        public double? ParMQLeftIndent { get; set; }

        public int? ParFontSize { get; set; }

        [StringLength(100)]
        public string ParFontName { get; set; }

        public float? Double1 { get; set; }

        public float? Double2 { get; set; }

        public float? Double3 { get; set; }

        public float? Double4 { get; set; }

        public bool SkipSwap { get; set; }

        public int? cblank { get; set; }

        public int? cdouble { get; set; }

        public bool clogic { get; set; }

        public int? pfsbd { get; set; }

        public int? pnsbd { get; set; }

        public int? pfmade { get; set; }

        public int? pnmade { get; set; }

        public int? pftraloi { get; set; }

        public int? pntraloi { get; set; }

        public int? pflo { get; set; }

        public int? pnlo { get; set; }

        public int? pfimage { get; set; }

        public int? pnimage { get; set; }

        [StringLength(50)]
        public string pblank { get; set; }

        [StringLength(50)]
        public string pdouble { get; set; }

        public bool roundToZero { get; set; }

        public bool skipMinus { get; set; }

        public float? MaxPoint { get; set; }

        public float? MinPoint { get; set; }

        public bool qBack { get; set; }

        public int? loop { get; set; }

        public int? MaxUsed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QClass> QClasses { get; set; }
    }
}
