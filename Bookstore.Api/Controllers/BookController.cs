using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("v1/books")]
        public async Task<ActionResult> GetAllBooks()
        {
            var booksList = await _bookService.GetAllBooks();
            return Ok(booksList);
        }

        [HttpGet("v1/books/{name}")]
        public async Task<ActionResult> GetBookByName(string name)
        {
            var book = await _bookService.GetBookByName(name);
            return Ok(book);
        }
    }
}