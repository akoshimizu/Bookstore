using AutoMapper;
using Bookstore.Api.Hypermedia.Filters;
using Bookstore.Api.ValueObject;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Book;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet("v1/books")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [SwaggerOperation(Summary = "Get all book values", Description = "Returns values: id, name, description, price.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but no value found.")]
        public async Task<ActionResult> GetAllBooks()
        {
            var booksList = await _bookService.GetAllBooks();
            var bookListHateoas = _mapper.Map<IEnumerable<EditorBookValueObject>>(booksList);
            if(bookListHateoas.Count() <1) return NoContent();
            return Ok(bookListHateoas);
        }

        [HttpGet("v1/books/{name}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [SwaggerOperation(Summary = "Get book by name", Description = "Returns a book that your requested by name.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but no value found.")]
        public async Task<ActionResult> GetBookByName([FromRoute]string name)
        {
            var book = await _bookService.GetBookByName(name);
            // var hateo = new EditorBookValueObject(book.Id, book.Name, book.Description, book.Price);
            var bookResp = _mapper.Map<EditorBookValueObject>(book);
            if(bookResp is null) return NoContent();
            return Ok(bookResp);
        }

        [HttpPost("v1/books")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [SwaggerOperation(Summary = "Create a new Book.", Description = "You'll can create a new book. When finish, It's will returns the inserted book informations.")]
        [SwaggerResponse(200, "Success request.")]
        public async Task<ActionResult> CreateBook([FromBody]EditorBookViewModel book)
        {
            var bookCreated = await _bookService.CreateBook(book);
            return Ok(bookCreated);
        }

        [HttpPut("v1/books/{id:int}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [SwaggerOperation(Summary = "Update a Book.", Description = "You'll can update a book in database.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but wasn't book found to update.")]
        public async Task<ActionResult> UpdateBook([FromBody]EditorBookViewModel model, [FromRoute]int id)
        {
            var Updatedbook = await _bookService.UpdateBook(model, id);
            if(Updatedbook is null) return StatusCode(204, "Book no found");

            return Ok(Updatedbook);
        }

        [HttpDelete("v1/books/{id:int}")]
        [SwaggerOperation(Summary = "Delete a Book.", Description = "You'll can delete a book in database by your id.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but wasn't book found to delete.")]
        public ActionResult DeleteBook([FromRoute]int id)
        {
            var result = _bookService.DeleteBook(id);
            if(result is null) return StatusCode(204, "Book no found");
            return Ok(result);
        }
    }
}