using Bookstore.Application.ViewModel.Book;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseViewModel>> GetAllBooks();
        Task<BookResponseViewModel> GetBookByName(string name);
        Task<BookResponseViewModel> CreateBook(BookResponseViewModel newBook);
        Task<BookResponseViewModel> UpdateBook(BookResponseViewModel newBook, int id);
        string DeleteBook(int id);
    }
}