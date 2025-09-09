using System;
using System.Linq;
using LinqBooksDemo.Data;
using LinqBooksDemo.Models;

namespace LinqBooksDemo.Services
{
    public class BookService
    {
        private readonly System.Collections.Generic.List<Book> _books;
        private readonly System.Collections.Generic.List<Publisher> _publishers;
        private readonly System.Collections.Generic.List<Subject> _subjects;

        public BookService()
        {
            _books = SampleData.GetBooks();
            _publishers = SampleData.GetPublishers();
            _subjects = SampleData.GetSubjects();
        }

        public void Query1()
        {
            var result = _books.Select(b => new { b.Title, b.ISBN });
            foreach (var b in result) Console.WriteLine($"{b.Title} - {b.ISBN}");
        }

        public void Query2()
        {
            var result = _books.Where(b => b.Price > 25).Take(3);
            foreach (var b in result) Console.WriteLine($"{b.Title} - {b.Price}");
        }

        public void Query3()
        {
            var joinQuery = _books.Join(_publishers,
                b => b.PublisherId,
                p => p.Id,
                (b, p) => new { b.Title, PublisherName = p.Name });

            foreach (var item in joinQuery) Console.WriteLine($"{item.Title} - {item.PublisherName}");

            Console.WriteLine("\n--- Method 2 ---");
            var secondQuery = from b in _books
                              from p in _publishers
                              where b.PublisherId == p.Id
                              select new { b.Title, PublisherName = p.Name };

            foreach (var item in secondQuery) Console.WriteLine($"{item.Title} - {item.PublisherName}");
        }

        public void Query4()
        {
            var count = _books.Count(b => b.Price > 20);
            Console.WriteLine($"Books with price > 20: {count}");
        }

        public void Query5()
        {
            var result = from b in _books
                         join s in _subjects on b.SubjectId equals s.Id
                         orderby s.Name ascending, b.Price descending
                         select new { b.Title, b.Price, SubjectName = s.Name };

            foreach (var item in result) Console.WriteLine($"{item.SubjectName} - {item.Title} - {item.Price}");
        }

        public void Query6()
        {
            var groupJoin = from s in _subjects
                            join b in _books on s.Id equals b.SubjectId into sb
                            select new { Subject = s.Name, Books = sb };

            foreach (var g in groupJoin)
            {
                Console.WriteLine($"{g.Subject}:");
                foreach (var b in g.Books) Console.WriteLine($"   {b.Title}");
            }

            Console.WriteLine("\n--- Method 2 ---");
            var groupBy = _books.GroupBy(b => b.SubjectId)
                                .Select(g => new
                                {
                                    Subject = _subjects.First(s => s.Id == g.Key).Name,
                                    Books = g
                                });

            foreach (var g in groupBy)
            {
                Console.WriteLine($"{g.Subject}:");
                foreach (var b in g.Books) Console.WriteLine($"   {b.Title}");
            }
        }

        public void Query7()
        {
            var result = SampleData.GetBooks().Select(b => new { b.Title, b.Price });
            foreach (var b in result) Console.WriteLine($"{b.Title} - {b.Price}");
        }

        public void Query8()
        {
            var result = from b in _books
                         join p in _publishers on b.PublisherId equals p.Id
                         join s in _subjects on b.SubjectId equals s.Id
                         group b by new { Publisher = p.Name, Subject = s.Name } into g
                         select g;

            foreach (var g in result)
            {
                Console.WriteLine($"{g.Key.Publisher} - {g.Key.Subject}:");
                foreach (var b in g) Console.WriteLine($"   {b.Title}");
            }
        }

        public void FindBooksSorted(string publisherName, string sortCriteria, string sortWay)
        {
            var pubId = _publishers.FirstOrDefault(p => p.Name.Equals(publisherName, StringComparison.OrdinalIgnoreCase))?.Id;
            if (pubId == null)
            {
                Console.WriteLine("Publisher not found.");
                return;
            }

            var query = _books.Where(b => b.PublisherId == pubId);

            if (sortCriteria.Equals("Title", StringComparison.OrdinalIgnoreCase))
                query = sortWay.Equals("ASC", StringComparison.OrdinalIgnoreCase)
                    ? query.OrderBy(b => b.Title)
                    : query.OrderByDescending(b => b.Title);
            else if (sortCriteria.Equals("Price", StringComparison.OrdinalIgnoreCase))
                query = sortWay.Equals("ASC", StringComparison.OrdinalIgnoreCase)
                    ? query.OrderBy(b => b.Price)
                    : query.OrderByDescending(b => b.Price);

            foreach (var b in query) Console.WriteLine($"{b.Title} - {b.Price}");
        }
    }
}
