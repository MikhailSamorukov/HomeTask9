using LinqToDB;
using LinqToDB.Data;
using SubTask1.Models;

namespace SubTask1
{
    class NorthwindContext : DataConnection
    {
        public NorthwindContext() : base("Northwind")
        {
        }
        public ITable<Category> Categories
        {
            get
            {
                return GetTable<Category>();
            }
        }
        public ITable<Product> Products
        {
            get
            {
                return GetTable<Product>();
            }
        }
        public ITable<Employee> Employees
        {
            get
            {
                return GetTable<Employee>();
            }
        }
        public ITable<EmployeeTerritory> EmployeeTerritories
        {
            get
            {
                return GetTable<EmployeeTerritory>();
            }
        }
        public ITable<Territory> Territories
        {
            get
            {
                return GetTable<Territory>();
            }
        }
        public ITable<Region> Regions
        {
            get
            {
                return GetTable<Region>();
            }
        }
        public ITable<Order> Orders
        {
            get
            {
                return GetTable<Order>();
            }
        }
        public ITable<Shipper> Shippers
        {
            get
            {
                return GetTable<Shipper>();
            }
        }
        public ITable<Supplier> Suppliers
        {
            get
            {
                return GetTable<Supplier>();
            }
        }
    }
}
