using AutoMapper;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Author;
using Bookstore.Application.ViewModel.Book;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Bookstore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IMemoryCache cache, IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorResponseViewModel>> GetAllAuthors()
        {
            var listAuthors = await _authorRepository.GetAllAuthors();
            if(listAuthors is null) return null;

            var authors = _mapper.Map<IEnumerable<AuthorResponseViewModel>>(listAuthors);

            return authors;
        }

        public async Task<AuthorResponseViewModel> GetBookByName(string authorName)
        {
            return _mapper.Map<AuthorResponseViewModel>(await _authorRepository.GetAuthorByName(authorName));
        }

        public async Task<AuthorResponseViewModel> CreateAuthor(AuthorResponseViewModel newAuthor)
        {
            var author = await _authorRepository.CreateAuthor( _mapper.Map<Author>(newAuthor));
            
            return _mapper.Map<AuthorResponseViewModel>(author);
        }

        public async Task<AuthorResponseViewModel> UpdateAuthor(AuthorResponseViewModel newBook, int id)
        {
            var UpdatedAuthor = _mapper.Map<Author>(newBook);
            UpdatedAuthor = await _authorRepository.UpdateAuthor(UpdatedAuthor, id);
            return _mapper.Map<AuthorResponseViewModel>(UpdatedAuthor);
        }

        public string DeleteAuthor(int id)
        {
            return _authorRepository.DeleteAuthor(id);
        }
    }
}