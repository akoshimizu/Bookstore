using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Application.ViewModel;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseViewModel>> GetAllBooks();
        Task<BookResponseViewModel> GetBookByName(string name);
        Task<BookResponseViewModel> CreateBook(Book newBook);
        Task<Book> UpdateBook(Book newBook);
        void DeleteBook(Book newBook);
    }
}