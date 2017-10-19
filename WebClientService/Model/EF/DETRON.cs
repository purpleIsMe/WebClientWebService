namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeTron")]
    public partial class DeTron
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeTron()
        {
            DeTronQuestions = new HashSet<DeTronQuestion>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDeTron { get; set; }

        [StringLength(50)]
        public string TenDeTron { get; set; }

        public int MaDeChuan { get; set; }

        public virtual DeChuan DeChuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeTronQuestion> DeTronQuestions { get; set; }
    }
}
