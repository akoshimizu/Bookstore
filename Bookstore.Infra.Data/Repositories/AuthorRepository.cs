using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _context;
        public AuthorRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authorsContext = await _context.Authors.Include(b => b.Books).ToListAsync();
            return authorsContext;
        }

        public async Task<Author> GetAuthorByName(string name)
        {
            var author = await _context.Authors.Include(b => b.Books).FirstOrDefaultAsync(n => n.Name.Equals(name));
            return author;
        }

        public async Task<Author> CreateAuthor(Author newAuthor)
        {
            try
            {
                await _context.Authors.AddAsync(newAuthor);
                await _context.SaveChangesAsync();
                return newAuthor;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Error creating author: {ex.Message}");
            }
        }

        public async Task<Author> UpdateAuthor(Author model, int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if(author is null) return null;

            author.Name = model.Name;

            _context.Update(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public string DeleteAuthor(int id)
        {
            try
            {
                var deletedAuthor = _context.Authors.FirstOrDefault(x => x.Id.Equals(id));
                if(deletedAuthor is null) return null;
                
                _context.Authors.Remove(deletedAuthor);
                _context.SaveChanges();
                return $"Deleted book: {deletedAuthor.Name}";
                
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}