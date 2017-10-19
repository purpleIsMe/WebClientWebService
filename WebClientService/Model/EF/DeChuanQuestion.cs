namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeChuanQuestion")]
    public partial class DeChuanQuestion
    {
        [Key]
        [Column(Order = 0)]
        public int IDAuto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDe { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid QuesID { get; set; }

        public int QID { get; set; }

        public virtual DeChuan DeChuan { get; set; }

        public virtual Question Question { get; set; }
    }
}
