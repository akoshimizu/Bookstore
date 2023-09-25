namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public Book(int? id, string name, string description, decimal price, int? authorId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AuthorId = authorId;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
    }
}