using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorByName(string name);
        Task<Author> CreateAuthor(Author newAuthor);
        Task<Author> UpdateAuthor(Author newAuthor, int id);
        string DeleteAuthor(int id);
    }
}