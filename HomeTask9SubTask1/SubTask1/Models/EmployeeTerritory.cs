using LinqToDB.Mapping;


namespace SubTask1.Models
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [PrimaryKey]
        public int EmployeeID { get; set; }
        [PrimaryKey, NotNull]
        public string TerritoryID { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public Employee Employee { get; set; }
        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public Territory Territory { get; set; }
    }
}
