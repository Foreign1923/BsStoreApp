using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequiredFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiExplorerSettings(GroupName = "1.0")]
    [ApiController]
    [Route("api/books")]// burada bir sıkıntı var
    //[ResponseCache(CacheProfileName = "5mins")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 80 )]
    
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookservice;
        public BooksController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }
        [HttpHead]
        [HttpGet(Name = "GetAllBooksAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters)
        {
            var linkParameters = new LinkParameters()
            {
                BookParameters = bookParameters,
                HttpContext = HttpContext
            };
            var result = await _bookservice.GetAllBooksAsync(linkParameters, false);
            //var pagedResult = await _bookservice.GetAllBooksAsync(bookParameters,false);
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ?
                Ok(result.linkResponse.LinkedEntities) :
                Ok(result.linkResponse.ShapedEntities);
            //return Ok(pagedResult.books); bu başka bir şey için pagination
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _bookservice.GetOneBookByIdAsync(id, false);
            return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneBookAsync")]
        public async Task <IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _bookservice.CreateOneBookAsync(bookDto);

            return StatusCode(201, book); // CreatedAtRoute()
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task <IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        { 
           await _bookservice.UpdateOneBookAsync(id, bookDto, false);
            return NoContent(); // 204
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
            await _bookservice.DeleteOneBookAsync(id, false);
            return NoContent();
        }


        [HttpPatch("{id:int}")]
        public async Task <IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {

            if (bookPatch is null)
                return BadRequest(); // 400

            var result = await _bookservice.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _bookservice.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);
          
            return NoContent(); // 204
        }
        [HttpOptions]
        public IActionResult GetBooksOption()
        {
            Response.Headers.Add("Allow","GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
        
    }
}
