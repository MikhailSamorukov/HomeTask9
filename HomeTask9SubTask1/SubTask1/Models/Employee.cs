using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using LinqToDB;

namespace SubTask1.Models
{
    [Table(Name = "Employees")]
    public class Employee 
    {
        [PrimaryKey, Identity]
        public int EmployeeID { get; set; }
        [Column, NotNull]
        public string LastName { get; set; }
        [Column, NotNull]
        public string FirstName { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string TitleOfCourtesy { get; set; }
        [Column]
        public DateTime? BirthDate { get; set; }
        [Column]
        public DateTime? HireDate { get; set; }
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
        public string HomePhone { get; set; }
        [Column]
        public string Extension { get; set; }
        [Column]
        public string Notes { get; set; }
        [Column]
        public int? ReportsTo { get; set; }
        [Column]
        public string PhotoPath { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "ReportsTo")]
        public List<Employee> Employees { get; set; }
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public List<EmployeeTerritory> EmployeeTerritories { get; set; }
        [Association(ThisKey = "ReportsTo", OtherKey = "EmployeeID")]
        public Employee ReportsToEmployee { get; set; }
        public EmployeeTerritory EmployeeTerritory { get; set; }
    }
}
