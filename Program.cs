using System;
using LinqBooksDemo.Services;

namespace LinqBooksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new BookService();

            Console.WriteLine("1) Book Title and ISBN:");
            service.Query1();
            Console.WriteLine();

            Console.WriteLine("2) First 3 books with price > 25:");
            service.Query2();
            Console.WriteLine();

            Console.WriteLine("3) Book with Publisher:");
            service.Query3();
            Console.WriteLine();

            Console.WriteLine("4) Number of books with price > 20:");
            service.Query4();
            Console.WriteLine();

            Console.WriteLine("5) Books sorted by subject ASC, price DESC:");
            service.Query5();
            Console.WriteLine();

            Console.WriteLine("6) Subjects with books:");
            service.Query6();
            Console.WriteLine();

            Console.WriteLine("7) Books from GetBooks():");
            service.Query7();
            Console.WriteLine();

            Console.WriteLine("8) Books grouped by Publisher & Subject:");
            service.Query8();
            Console.WriteLine();

            Console.Write("Enter publisher name: ");
            string pubName = Console.ReadLine();
            Console.Write("Sort by (Title/Price): ");
            string sortCriteria = Console.ReadLine();
            Console.Write("Sort way (ASC/DESC): ");
            string sortWay = Console.ReadLine();

            service.FindBooksSorted(pubName, sortCriteria, sortWay);
        }
    }
}
