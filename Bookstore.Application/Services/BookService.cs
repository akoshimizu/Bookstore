using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookResponseViewModel>> GetAllBooks()
        {
            var listBooks = await _bookRepository.GetAllBooks();
            var books = new List<BookResponseViewModel>();

            foreach (var item in listBooks)
            {
                books.Add(new BookResponseViewModel(item.Name, item.Description, item.Price));
            }

            return books;
        }

        public async Task<BookResponseViewModel> GetBookByName(string name)
        {
            var book = await _bookRepository.GetBookByName(name);
            var bookResp = new BookResponseViewModel(book.Name, book.Description, book.Price);
            return bookResp;
        }

        public Task<BookResponseViewModel> CreateBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book newBook)
        {
            throw new NotImplementedException();
        }
    }
}