using Bookstore.Application.ViewModel.Author;
using Bookstore.Application.ViewModel.Book;

namespace Bookstore.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseViewModel>> GetAllAuthors();
        Task<AuthorResponseViewModel> GetBookByName(string authorName);
        Task<AuthorResponseViewModel> CreateAuthor(AuthorResponseViewModel newAuthor);
        Task<AuthorResponseViewModel> UpdateAuthor(AuthorResponseViewModel newBook, int id);
        string DeleteAuthor(int id);
    }
}