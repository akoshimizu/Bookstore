using System.ComponentModel.DataAnnotations;
using Bookstore.Application.ViewModel.Book;

namespace Bookstore.Application.ViewModel.Author
{
    public class AuthorResponseViewModel
    {
        public AuthorResponseViewModel(int? id, string name)
        {
            Id = id;
            Name = name;
        }
        public int? Id { get; private set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; private set; }

        public List<EditorBookViewModel>? Books { get; set; } = new();
    }
}