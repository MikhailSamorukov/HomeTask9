using SubTask1.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Data;


namespace SubTask1
{
    public class Queries
    {
        NorthwindContext _context;

        public Queries()
        {
            _context = new NorthwindContext();
        }
        /// <summary>
        /// Query 2.1 Список продуктов с категорией и поставщиком
        /// </summary>
        public void Query2_1()
        {
            var query = _context.Products.LoadWith(product => product.Category).LoadWith(product => product.Supplier).ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Category - CategoryName: {item.Category.Name}");
                Console.WriteLine($"Supplier - CompanyName: {item.Supplier.CompanyName}");
            }
        }
        /// <summary>
        /// Query 2.2 Список сотрудников с указанием региона, за который они отвечают
        /// </summary>
        public void Query2_2()
        {
            var query = (from emp in _context.Employees
                         join empTerrritory in _context.EmployeeTerritories on emp.EmployeeID equals empTerrritory.EmployeeID
                         join territory in _context.Territories on empTerrritory.TerritoryID equals territory.TerritoryID
                         join region in _context.Regions on territory.RegionID equals region.RegionID
                         select new
                         {
                             EmployeeName = $"{emp.FirstName} {emp.LastName}",
                             RegionDesc = region.RegionDescription
                         }).ToList().Distinct();
            foreach (var item in query)
            {
                Console.WriteLine($"Employee: {item.EmployeeName} - Region: {item.RegionDesc}");
            }
        }
        /// <summary>
        /// Query 2.3 Список сотрудников с указанием региона, за который они отвечают
        /// </summary>
        public void Query2_3()
        {
            var query = (from emp in _context.Employees
                         join empTerrritory in _context.EmployeeTerritories on emp.EmployeeID equals empTerrritory.EmployeeID
                         join territory in _context.Territories on empTerrritory.TerritoryID equals territory.TerritoryID
                         join region in _context.Regions on territory.RegionID equals region.RegionID
                         group emp by new { region.RegionID, region.RegionDescription } into regionGroup
                         select new
                         {
                             EmployeeCount = regionGroup.Count(),
                             RegionDesc = regionGroup.Key.RegionDescription
                         }).ToList().OrderBy(employeegroup => employeegroup.EmployeeCount);
            foreach (var item in query)
            {
                Console.WriteLine($"EmployeeCount: {item.EmployeeCount} - Region: {item.RegionDesc}");
            }
        }
        /// <summary>
        /// Query 2.4 Списка «сотрудник – с какими грузоперевозчиками работал» (на основе заказов)
        /// </summary>
        public void Query2_4()
        {
            var query = (from emp in _context.Employees
                         join order in _context.Orders on emp.EmployeeID equals order.EmployeeID
                         join shipper in _context.Shippers on order.ShipVia equals shipper.ShipperID
                         select new
                         {
                             emp,
                             shipper
                         }).ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Employee: {item.emp.LastName} {item.emp.FirstName} - Shipper: {item.shipper.CompanyName}");
            }
        }
        /// <summary>
        /// Query 3.1	Добавить нового сотрудника, и указать ему список территорий, за которые он несет ответственность. 
        /// </summary>
        public void Query3_1()
        {
            var emp = new Employee()
            {
                FirstName = "test",
                LastName = "test",
            };
            emp.EmployeeID = _context.InsertWithInt32Identity(emp);
            _context.BulkCopy(new List<EmployeeTerritory> { new EmployeeTerritory
            {
                EmployeeID = emp.EmployeeID,
                TerritoryID = "01581",
            }, new EmployeeTerritory
            {
                EmployeeID = emp.EmployeeID,
                TerritoryID = "01730",
            }
            });
        }
        /// <summary>
        /// Query 3.2	Перенести продукты из одной категории в другую
        /// </summary>
        public void Query3_2()
        {
            var categoryFrom = 1;
            var categoryTo = 4;

            _context.Products
                       .Where(product => product.CategoryID == categoryFrom)
                       .Set(product => product.CategoryID, product => categoryTo)
                       .Update();
        }
        /// <summary>
        /// Query 3.3	Добавить список продуктов со своими поставщиками и категориями (массовое занесение), при этом если поставщик или категория с таким названием есть, то использовать их – иначе создать новые. 
        /// </summary>
        public void Query3_3()
        {
            var products = new List<Product> {
               new Product{
                   Category = new Category{
                       Name = "teest",
                   },
                   ProductName = "test1",
                   Supplier = new Supplier{
                       CompanyName = "test1"
                   }
               },
               new Product{
                   Category = new Category{
                       Name = "teest3",
                   },
                   ProductName = "test2",
                   Supplier = new Supplier{
                       CompanyName = "test2"
                   }
               }
            };

            InsertProducts(products);
        }
        /// <summary>
        /// Query 3.4 Замена продукта на аналогичный: во всех еще неисполненных заказах (считать таковыми заказы, у которых ShippedDate = NULL) заменить один продукт на другой.
        /// </summary>
        public void Query3_4()
        {
            var ordersDetails = GetOrderDetailsWithoutShippedDate();
            var modifiedCollection = ordersDetails.ToList();
            foreach (var item in modifiedCollection)
            {
                var categoryId = _context.Products
                                    .Where(product => product.ProductID == item.ProductID)
                                    .Select(i => i.CategoryID)
                                    .FirstOrDefault();
                var products = _context.Products.Where(product => product.CategoryID == categoryId).ToList();
                var newProductId = 0;
                var keys = ordersDetails.Select(orderDetail => new { orderDetail.OrderID, orderDetail.ProductID }).ToList();
                foreach (var product in products)
                {
                    if (keys.Any(key => key.ProductID == product.ProductID && key.OrderID == item.OrderID))
                    {
                        continue;
                    }
                    else
                    {
                        newProductId = product.ProductID;
                        break;
                    }
                }

                if (newProductId == 0)
                    throw new Exception("No matching key found");

                UpdateProduct(ordersDetails, item, newProductId);
            }
        }

        private static void UpdateProduct(IQueryable<OrderDetail> ordersDetails, OrderDetail item, int newProductId)
        {
            ordersDetails
                .Where(orderDetail => orderDetail.OrderID == item.OrderID && orderDetail.ProductID == item.ProductID)
                .Set(orderDetail => orderDetail.ProductID, orderDetail => newProductId)
                .Update();
        }

        private IQueryable<OrderDetail> GetOrderDetailsWithoutShippedDate()
        {
            return _context.Orders
                        .LoadWith(order => order.OrderDetails)
                         .Where(order => order.ShippedDate == null).SelectMany(order => order.OrderDetails);
        }

        private void InsertProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                int categoryId = _context.Categories.Any(category => category.Name == products[i].Category.Name) ?
                    _context.Categories
                        .Where(category => category.Name == products[i].Category.Name)
                        .Select(category => category.Id)
                        .FirstOrDefault() :
                    _context.InsertWithInt32Identity(products[i].Category);

                int supplierId = _context.Suppliers.Any(supplier => supplier.CompanyName == products[i].Supplier.CompanyName) ?
                    _context.Suppliers
                        .Where(supplier => supplier.CompanyName == products[i].Supplier.CompanyName)
                        .Select(supplier => supplier.SupplierID)
                        .FirstOrDefault() :
                    _context.InsertWithInt32Identity(products[i].Supplier);

                products[i].SupplierID = supplierId;
                products[i].CategoryID = categoryId;
                _context.InsertWithInt32Identity(products[i]);
            }
        }
    }
}
