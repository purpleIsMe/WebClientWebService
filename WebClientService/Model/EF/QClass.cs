namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QClass")]
    public partial class QClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QClass()
        {
            Questions = new HashSet<Question>();
            QuestionTemps = new HashSet<QuestionTemp>();
        }

        [Key]
        public Guid ClassID { get; set; }

        public Guid? SubjectID { get; set; }

        public int? ClassNbr { get; set; }

        [StringLength(200)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string ChuThich { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionTemp> QuestionTemps { get; set; }

        public int idsu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDQClass { get; set; }
    }
}
