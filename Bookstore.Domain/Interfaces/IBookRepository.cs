using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookByName(string name);
        Task<Book> CreateBook(Book newBook);
        Task<Book> UpdateBook(Book newBook, int id);
        string DeleteBook(int id);
    }
}