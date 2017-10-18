using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column(Order =1)]
        public int OrderID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductID")]
        public virtual QUESTION_BUY ID { set; get; }
    }
}