namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int ID { get; set; }

        public Guid? QuestionID { get; set; }

        public int? CountTrue { get; set; }

        public int? CountFalse { get; set; }

        public int? IDCaThi { get; set; }

        [StringLength(50)]
        public string IDKhoaThi { get; set; }

        [StringLength(200)]
        public string ContentQS { get; set; }

        public int? QuestionNbr { get; set; }

        public DateTime? DateCreate { get; set; }
    }
}
