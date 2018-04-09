namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DECHUAN")]
    public partial class DECHUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DECHUAN()
        {
            DETRONs = new HashSet<DETRON>();
        }

        [Key]
        public int MaDeChuan { get; set; }

        [StringLength(50)]
        public string TenDeChuan { get; set; }

        public Guid MaMon { get; set; }

        public int MaCaThi { get; set; }

        public int SoDeHoanVi { get; set; }

        public bool? TrangThaiTron { get; set; }

        public int ThoiGian { get; set; }

        public bool? Lock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETRON> DETRONs { get; set; }
    }
}
