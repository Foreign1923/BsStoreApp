﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Entities.LinkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "1.0")]
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public RootController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRoot")]
        public async Task<IActionResult> GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.btkakademi.apiroot"))
            {
                // config
                var list = new List<Link>()
                {
                    new Link() {

                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot),new{}),
                        Rel ="_self",
                        Method = "GET",
                    },
                    new Link() {

                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.GetAllBooksAsync),new{}),
                        Rel ="books",
                        Method = "GET",
                    },
                    new Link() {

                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.CreateOneBookAsync),new{}),
                        Rel ="books",
                        Method = "POST",
                    }
                    //22.5
                };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
