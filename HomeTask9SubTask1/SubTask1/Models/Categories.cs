using LinqToDB.Mapping;
using System.Collections.Generic;

namespace SubTask1.Models
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, Identity, Column("CategoryID")]
        public int Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
        [Association(ThisKey = "Id", OtherKey = "CategoryID")]
        public List<Product> Products { get; set; }
    }
}
