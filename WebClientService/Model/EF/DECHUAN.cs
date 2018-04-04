namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeChuan")]
    public partial class DeChuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeChuan()
        {
            CaThis = new HashSet<CaThi>();
            DeChuanQuestions = new HashSet<DeChuanQuestion>();
            DeTrons = new HashSet<DeTron>();
        }

        [Key]
        public int MaDeChuan { get; set; }

        [StringLength(50)]
        public string TenDeChuan { get; set; }

        public Guid MaMon { get; set; }

        public int SoDeHoanVi { get; set; }

        public bool? TrangThaiTron { get; set; }

        public int ThoiGian { get; set; }

        public bool? Lock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CaThi> CaThis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeChuanQuestion> DeChuanQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTron> DeTrons { get; set; }
    }
}
