using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;


namespace Presentation.ActionFilters
{
    public class ValidateMediaTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var acceptHeaderPresent = context.HttpContext
                .Request.Headers
                .ContainsKey("Accept");
            if (!acceptHeaderPresent)
            {
                context.Result =
                    new BadRequestObjectResult($"Accept header is missing!");
            }
            var mediaType = context.HttpContext
                .Response
                .Headers["Accept"]
                .FirstOrDefault();
            if(MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? outMediaType))
            {
                context.Result = 
                    new BadRequestObjectResult($"Media Type not present."
                    + $"Please add accept header with required media type.");
                return;
            }
            context.HttpContext.Items.Add("AcceptHeaderMediaType", outMediaType);
        
        
        }
    }
}
