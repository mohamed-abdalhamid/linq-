namespace LinqBooksDemo.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int PublisherId { get; set; }
        public int SubjectId { get; set; }
    }
}
