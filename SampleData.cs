using System.Collections.Generic;
using LinqBooksDemo.Models;

namespace LinqBooksDemo.Data
{
    public static class SampleData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Title="C# Basics", ISBN="111", Price=30, PublisherId=1, SubjectId=1 },
                new Book { Title="ASP.NET Core", ISBN="222", Price=45, PublisherId=1, SubjectId=2 },
                new Book { Title="LINQ in Action", ISBN="333", Price=28, PublisherId=2, SubjectId=1 },
                new Book { Title="SQL Server", ISBN="444", Price=18, PublisherId=2, SubjectId=3 },
                new Book { Title="Entity Framework", ISBN="555", Price=50, PublisherId=3, SubjectId=2 },
            };
        }

        public static List<Publisher> GetPublishers()
        {
            return new List<Publisher>
            {
                new Publisher { Id=1, Name="O'Reilly" },
                new Publisher { Id=2, Name="Apress" },
                new Publisher { Id=3, Name="Packt" },
            };
        }

        public static List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject { Id=1, Name="Programming" },
                new Subject { Id=2, Name="Web Development" },
                new Subject { Id=3, Name="Database" },
            };
        }
    }
}
