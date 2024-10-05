using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 23.6 gereksizmiş postman config
namespace Presentation.Controllers
{
    [ApiVersion ("2.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiExplorerSettings(GroupName = "2.0")]
    [ApiController]
    [Route("api/{v:apiversion}/books")]
    public class BooksV2Controller : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksV2Controller(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _bookService.GetAllBooksAync(trackChanges);
            var booksV2 = books.Select(b => new
            {
                Title = b.Title,
                Id = b.Id
            });
            
            
            return Ok(books);
        }
    }
}
