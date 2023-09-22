using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Book;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private IMemoryCache _cache;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(IMemoryCache cache, IMapper mapper, IBookRepository bookRepository)
        {
            _cache = cache;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookResponseViewModel>> GetAllBooks()
        {
            try
            {
                var allBooks = await _cache.GetOrCreateAsync("GetBooks", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return GetFirstTimeBooks();
                });
                
                return allBooks;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<BookResponseViewModel> GetBookByName(string bookName)
        {
            return _mapper.Map<BookResponseViewModel>(await _bookRepository.GetBookByName(bookName));
        }

        public async Task<BookResponseViewModel> CreateBook(BookResponseViewModel model)
        {
            var book = await _bookRepository.CreateBook( _mapper.Map<Book>(model));
            
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

        private async Task<IEnumerable<BookResponseViewModel>> GetFirstTimeBooks()
        {
            var listBooks = await _bookRepository.GetAllBooks();
            if(listBooks is null) return null;
            
            var books = _mapper.Map<IEnumerable<BookResponseViewModel>>(listBooks);

            return books;
        }
    }
}