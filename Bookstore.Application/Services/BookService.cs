using AutoMapper;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Book;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookResponseViewModel>> GetAllBooks()
        {
            var listBooks = await _bookRepository.GetAllBooks();
            if(listBooks is null) return null;
            
            var books = _mapper.Map<IEnumerable<BookResponseViewModel>>(listBooks);
            // var books = new List<BookResponseViewModel>();

            // foreach (var item in listBooks)
            // {
            //     books.Add(new BookResponseViewModel(item.Name, item.Description, item.Price));
            // }

            return books;
        }

        public async Task<BookResponseViewModel> GetBookByName(string name)
        {
            return _mapper.Map<BookResponseViewModel>(await _bookRepository.GetBookByName(name));
            // var bookResp = _mapper.Map<BookResponseViewModel>(book);
            // return book;
        }

        public async Task<BookResponseViewModel> CreateBook(BookResponseViewModel model)
        {
            // var newBook = new Book(model.Name, model.Description, model.Price);
            var book = await _bookRepository.CreateBook( _mapper.Map<Book>(model));
            // var bookCreated = new BookResponseViewModel(book.Name, book.Description, book.Price);
            
            return _mapper.Map<BookResponseViewModel>(book);
        }

        public async Task<BookResponseViewModel> UpdateBook(BookResponseViewModel model, int id)
        {
            var Updatedbook = _mapper.Map<Book>(model);
            Updatedbook = await _bookRepository.UpdateBook(Updatedbook, id);
            return _mapper.Map<BookResponseViewModel>(Updatedbook);
        }

        public string DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }
    }
}