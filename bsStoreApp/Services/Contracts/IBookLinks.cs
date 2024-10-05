using Entities.DataTransferObjects;
using Entities.LinkModel;
using Microsoft.AspNetCore.Http;


namespace Services.Contracts
{
    public interface IBookLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<BookDto> bookDtos,
            string fields, HttpContext httpContext);
            
    }
}
