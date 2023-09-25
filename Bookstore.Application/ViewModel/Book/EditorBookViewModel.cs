using System.ComponentModel.DataAnnotations;

namespace Bookstore.Application.ViewModel.Book
{
    public class EditorBookViewModel
    {
        public EditorBookViewModel(int? id, string name, string description, decimal price, int? authorId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AuthorId = authorId;
        }
        public int? Id { get; private set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; private set; }
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; private set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; private set; }
        public int? AuthorId { get; private set;}
    }
}