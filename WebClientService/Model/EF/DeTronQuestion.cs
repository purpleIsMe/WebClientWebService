namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeTronQuestion")]
    public partial class DeTronQuestion
    {
        [Key]
        [Column(Order = 0)]
        public int IDAuto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDeTron { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid QuestionID { get; set; }

        public int Answer1 { get; set; }

        public int Answer2 { get; set; }

        public int Answer3 { get; set; }

        public int Answer4 { get; set; }

        public int DapAn { get; set; }

        public int? TheAnswer { get; set; }

        public virtual DeTron DeTron { get; set; }

        public virtual Question Question { get; set; }

        public virtual Question Question1 { get; set; }
    }
}
