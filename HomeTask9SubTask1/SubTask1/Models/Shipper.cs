using System.Collections.Generic;
using LinqToDB.Mapping;

namespace SubTask1.Models
{
    [Table(Name = "Shippers")]
    public class Shipper
    {
        [PrimaryKey, Identity]
        public int ShipperID { get; set; }
        [Column, NotNull]
        public string CompanyName { get; set; }
        [Column]
        public string Phone { get; set; }

        [Association(ThisKey = "ShipperID", OtherKey = "ShipVia")]
        public List<Order> Orders { get; set; }
    }
}
