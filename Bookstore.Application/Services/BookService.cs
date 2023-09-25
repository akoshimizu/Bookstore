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

        public async Task<IEnumerable<EditorBookViewModel>> GetAllBooks()
        {
            try
            {
                var allBooks = await _cache.GetOrCreateAsync("GetBooks", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                    return GetFirstTimeBooks();
                });
                
                return allBooks;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EditorBookViewModel> GetBookByName(string bookName)
        {
            return _mapper.Map<EditorBookViewModel>(await _bookRepository.GetBookByName(bookName));
        }

        public async Task<EditorBookViewModel> CreateBook(EditorBookViewModel model)
        {
            var book = await _bookRepository.CreateBook( _mapper.Map<Book>(model));
            
            return _mapper.Map<EditorBookViewModel>(book);
        }

        public async Task<EditorBookViewModel> UpdateBook(EditorBookViewModel model, int id)
        {
            var Updatedbook = _mapper.Map<Book>(model);
            Updatedbook = await _bookRepository.UpdateBook(Updatedbook, id);
            return _mapper.Map<EditorBookViewModel>(Updatedbook);
        }

        public string DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }

        private async Task<IEnumerable<EditorBookViewModel>> GetFirstTimeBooks()
        {
            var listBooks = await _bookRepository.GetAllBooks();
            if(listBooks is null) return null;
            
            var books = _mapper.Map<IEnumerable<EditorBookViewModel>>(listBooks);

            return books;
        }
    }
}