namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cathi")]
    public partial class Cathi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cathi()
        {
            DeChuans = new HashSet<DeChuan>();
        }

        public int ID { get; set; }

        public DateTime GioBD { get; set; }

        public DateTime GioKT { get; set; }

        public DateTime Ngay { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeChuan> DeChuans { get; set; }
    }
}
