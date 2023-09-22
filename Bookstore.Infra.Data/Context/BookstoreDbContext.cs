using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Context
{
    public class BookstoreDbContext : DbContext
    {
        
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) {   }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var model = modelBuilder.Entity<Book>();
           model.HasKey(x => x.Id);

           model.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            
            model.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            model.Property(x => x.Price)
            .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasMaxLength(80);
        }
    }
}