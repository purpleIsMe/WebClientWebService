namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionBuy")]
    public partial class QuestionBuy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int IDQClass { get; set; }

        public int CountQS { get; set; }

        public int IDUser { get; set; }

        public double Fee { get; set; }

        public int IDHinhThucTra { get; set; }
    }
}
