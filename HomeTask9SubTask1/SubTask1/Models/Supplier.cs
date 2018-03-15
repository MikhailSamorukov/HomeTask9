using System.Collections.Generic;
using LinqToDB.Mapping;

namespace SubTask1.Models
{
    [Table(Name = "Suppliers")]
    public class Supplier
    {
        [PrimaryKey, Identity]
        public int SupplierID { get; set; }
        [Column, NotNull]
        public string CompanyName { get; set; }
        [Column]
        public string ContactName { get; set; }
        [Column]
        public string ContactTitle { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string City { get; set; }
        [Column]
        public string Region { get; set; }
        [Column]
        public string PostalCode { get; set; }
        [Column]
        public string Country { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string Fax { get; set; }
        [Column]
        public string HomePage { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public List<Product> Products { get; set; }
    }
}
