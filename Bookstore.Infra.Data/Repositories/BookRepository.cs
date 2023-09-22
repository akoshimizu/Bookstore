using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _context;
        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var booksContext = await _context.Books.ToListAsync();
            return booksContext;
        }

        public async Task<Book> GetBookByName(string name)
        {
            var book = await _context.Books.FirstOrDefaultAsync(n => n.Name.Equals(name));
            return book;
        }

        public async Task<Book> CreateBook(Book newBook)
        {
            try
            {
                await _context.Books.AddAsync(newBook);
                await _context.SaveChangesAsync();
                return newBook;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Error creating book: {ex.Message}");
            }
        }

        public async Task<Book> UpdateBook(Book model, int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(book is null) return null;

            book.Name = model.Name;
            book.Description = model.Description;
            book.Price = model.Price;

            _context.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public string DeleteBook(int id)
        {
            var deletedBook = _context.Books.FirstOrDefault(x => x.Id.Equals(id));
            if(deletedBook is null) return null;
            
            _context.Books.Remove(deletedBook); //VERIFY
            _context.SaveChanges();
            return $"Deleted book: {deletedBook.Name}";
        }
    }
}