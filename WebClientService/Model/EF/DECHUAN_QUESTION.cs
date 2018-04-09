namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DECHUAN_QUESTION
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
        public Guid QuestionID { get; set; }

        public int QID { get; set; }
    }
}
