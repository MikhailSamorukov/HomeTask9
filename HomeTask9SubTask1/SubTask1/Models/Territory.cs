using System.Collections.Generic;
using LinqToDB.Mapping;

namespace SubTask1.Models
{
    [Table(Name = "Territories")]
    public class Territory
    {
        [PrimaryKey, NotNull]
        public string TerritoryID { get; set; }
        [Column, NotNull]
        public string TerritoryDescription { get; set; }
        [Column]
        public int RegionID { get; set; }

        public EmployeeTerritory EmployeeTerritory { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public List<EmployeeTerritory> EmployeeTerritories;

        [Association(ThisKey = "RegionID", OtherKey = "RegionID")]
        public Region Region;
    }
}
