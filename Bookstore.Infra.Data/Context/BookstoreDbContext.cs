using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Context
{
    public class BookstoreDbContext : DbContext
    {
        
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) {   }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
        }
    }
}