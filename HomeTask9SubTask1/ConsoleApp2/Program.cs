using System;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubTask1;
using SubTask1.Models;

namespace ConsoleApp2
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Queries queries = new Queries();
            queries.Query2_1();
            //queries.Query2_2();
            //queries.Query2_3();
            //queries.Query2_4();
            //queries.Query3_1();
            //queries.Query3_2();
            //queries.Query3_3();
            //queries.Query3_4();
            Console.ReadLine();
        }
    }
}
