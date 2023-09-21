using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = new List<Book>()
            {
                new Book("1", "Livro 1", "Descrição Livro 1", 19.99m),
                new Book("2", "Livro 2", "Descrição Livro 2", 59.99m),
                new Book("3", "Livro 3", "Descrição Livro 3", 29.99m)
            };

            return books;
        }

        public async Task<Book> GetBookByName(string name)
        {
            var book = new Book("1", name, "Descrição Livro 1", 19.99m);
            return book;
        }

        public Task<Book> CreateBook(Book newBook)
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