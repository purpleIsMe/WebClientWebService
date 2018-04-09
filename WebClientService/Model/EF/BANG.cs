namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANG")]
    public partial class BANG
    {
        public int ID { get; set; }

        public int? DA { get; set; }
    }
}
