using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace SubTask1.Models
{
    [Table(Name = "Order Details")]
    public class OrderDetail
    {
        [PrimaryKey]
        public int OrderID { get; set; }
        [PrimaryKey]
        public int ProductID { get; set; }
        [Column]
        public decimal UnitPrice { get; set; }
        [Column]
        public short Quantity { get; set; }
        [Column]
        public double Discount { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID")]
        public Order Order { get; set; }
        [Association(ThisKey = "ProductID", OtherKey = "ProductID")]
        public Product Product { get; set; }
    }
}
