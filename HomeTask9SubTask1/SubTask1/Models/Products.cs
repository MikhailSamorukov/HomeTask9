using LinqToDB.Mapping;
using System.Collections.Generic;

namespace SubTask1.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, Identity, Column]
        public int ProductID { get; set; }
        [Column]
        public string ProductName { get; set; }
        [Column]
        public int CategoryID { get; set; }
        [Column]
        public int? SupplierID;
        [Column]
        public string QuantityPerUnit { get; set; }
        [Column]
        public decimal UnitPrice { get; set; }
        [Column]
        public short UnitsInStock { get; set; }
        [Column]
        public short UnitsOnOrder { get; set; }
        [Column]
        public short ReorderLevel { get; set; }
        [Column]
        public byte Discontinued { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public Supplier Supplier { get; set; }
        [Association(ThisKey = "CategoryID", OtherKey = "Id")]
        public Category Category { get; set; }
        [Association(ThisKey = "ProductID", OtherKey = "ProductID")]
        public List<OrderDetail> OrderDetails;
    }
}
