using System.Collections.Generic;
using LinqToDB.Mapping;

namespace SubTask1.Models
{
    [Table(Name = "Region")]
    public class Region
    {
        [PrimaryKey]
        public int RegionID { get; set; }
        [Column, NotNull]
        public string RegionDescription { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "RegionID")]
        public List<Territory> Territories;
    }
}
