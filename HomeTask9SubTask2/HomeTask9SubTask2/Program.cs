using HomeTask9SubTask2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask9SubTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Query1();
            Console.ReadLine();
        }
        public static void Query1()
        {
            var categoryId = 2;

            using (var context = new NorthwindContext())
            {
                var query = (from order in context.Orders
                             join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                             join customer in context.Customers on order.CustomerID equals customer.CustomerID
                             join product in context.Products on orderDetail.ProductID equals product.ProductID
                             join category in context.Categories on product.CategoryID equals category.CategoryID
                             where category.CategoryID == categoryId
                             select new
                             {
                                 Details = orderDetail,
                                 ProductName = product.ProductName,
                                 CustomerCompany = customer.CompanyName
                             }).ToList();
                foreach (var item in query)
                {
                    Console.WriteLine($"Product name: {item.ProductName}");
                    Console.WriteLine($"Customer company: {item.CustomerCompany}");
                    Console.WriteLine($"Details - Discount: {item.Details.Discount}, Quantity: {item.Details.Quantity}");
                }
            }
        }
    }
}
