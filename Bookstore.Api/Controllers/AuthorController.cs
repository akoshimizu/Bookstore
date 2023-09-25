using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Application.Interfaces;
using Bookstore.Application.ViewModel.Author;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("v1/authors")]
        [SwaggerOperation(Summary = "Get all book values", Description = "Returns values: id, name, description, price.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but no value found.")]
        public async Task<ActionResult> GetAllBooks()
        {
            var authorList = await _authorService.GetAllAuthors();
            return Ok(authorList);
        }

        [HttpGet("v1/authors/{name}")]
        [SwaggerOperation(Summary = "Get author by name", Description = "Returns a author that your requested by name.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but no value found.")]
        public async Task<ActionResult> GetauthorByName([FromRoute]string name)
        {
            var author = await _authorService.GetBookByName(name);
            if(author is null) return NoContent();
            return Ok(author);
        }

        [HttpPost("v1/authors")]
        [SwaggerOperation(Summary = "Create a new author.", Description = "You'll can create a new author. When finish, It's will returns the inserted author informations.")]
        [SwaggerResponse(200, "Success request.")]
        public async Task<ActionResult> CreateAuthor([FromBody]AuthorResponseViewModel author)
        {
            var authorCreated = await _authorService.CreateAuthor(author);
            return Ok(authorCreated);
        }
        
        [HttpPut("v1/authors/{id:int}")]
        [SwaggerOperation(Summary = "Update a author.", Description = "You'll can update a author in database.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but wasn't author found to update.")]
        public async Task<ActionResult> UpdateAuthor([FromBody]AuthorResponseViewModel model, [FromRoute]int id)
        {
            var UpdatedAuthor = await _authorService.UpdateAuthor(model, id);
            if(UpdatedAuthor is null) return StatusCode(204, "Author no found");

            return Ok(UpdatedAuthor);
        }

        [HttpDelete("v1/authors/{id:int}")]
        [SwaggerOperation(Summary = "Delete a Author.", Description = "You'll can delete a book in database by your id.")]
        [SwaggerResponse(200, "Success request.")]
        [SwaggerResponse(204, "Success request, but wasn't book found to delete.")]
        public ActionResult DeleteBook([FromRoute]int id)
        {
            var result = _authorService.DeleteAuthor(id);
            if(result is null) return StatusCode(204, "Author no found");
            return Ok(result);
        }
    }
}