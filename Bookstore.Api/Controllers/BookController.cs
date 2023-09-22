using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Book;
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
        public async Task<ActionResult> GetBookByName([FromRoute]string name)
        {
            var book = await _bookService.GetBookByName(name);
            return Ok(book);
        }

        [HttpPost("v1/books")]
        public async Task<ActionResult> CreateBook([FromBody]EditorBookViewModel book)
        {
            var bookCreated = await _bookService.CreateBook(book);
            return Ok(bookCreated);
        }

        [HttpPut("v1/books/{id:int}")]
        public async Task<ActionResult> UpdateBook([FromBody]EditorBookViewModel model, [FromRoute]int id)
        {
            var Updatedbook = await _bookService.UpdateBook(model, id);
            if(Updatedbook is null) return StatusCode(204, "Livro não encontrado");

            return Ok(Updatedbook);
        }

        [HttpDelete("v1/books/{id:int}")]
        public ActionResult DeleteBook([FromRoute]int id)
        {
            var result = _bookService.DeleteBook(id);
            return Ok(result);
        }
    }
}