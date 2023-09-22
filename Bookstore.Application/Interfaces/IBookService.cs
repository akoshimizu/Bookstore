using Bookstore.Application.ViewModel.Book;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<EditorBookViewModel>> GetAllBooks();
        Task<EditorBookViewModel> GetBookByName(string name);
        Task<EditorBookViewModel> CreateBook(EditorBookViewModel newBook);
        Task<EditorBookViewModel> UpdateBook(EditorBookViewModel newBook, int id);
        string DeleteBook(int id);
    }
}