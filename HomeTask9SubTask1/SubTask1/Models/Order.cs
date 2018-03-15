using System;
using LinqToDB.Mapping;
using System.Collections.Generic;

namespace SubTask1.Models
{
    [Table(Name = "Orders")]
    public class Order 
    {
        [PrimaryKey, Identity]
        public int OrderID { get; set; }
        [Column]
        public string CustomerID { get; set; }
        [Column]
        public int? EmployeeID { get; set; }
        [Column]
        public DateTime? OrderDate { get; set; }
        [Column]
        public DateTime? RequiredDate { get; set; }
        [Column]
        public DateTime? ShippedDate { get; set; }
        [Column]
        public int? ShipVia { get; set; }
        [Column]
        public decimal Freight { get; set; }
        [Column]
        public string ShipName { get; set; }
        [Column]
        public string ShipAddress { get; set; }
        [Column]
        public string ShipCity { get; set; }
        [Column]
        public string ShipRegion { get; set; }
        [Column]
        public string ShipPostalCode { get; set; }
        [Column]
        public string ShipCountry { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID")]
        public List<OrderDetail> OrderDetails { get; set; }
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public Employee Employee { get; set; }
        [Association(ThisKey = "ShipVia", OtherKey = "ShipperID")]
        public Shipper Shipper { get; set; }
    }
}
