using Autodoc.SeoAdmin.Application.GenerateUrls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.API.Controllers
{
    //[Authorize(Roles = "Admin, SEO")]
    public class UrlsController : ApiControllerBase
    {
        [HttpGet]
        [Route("generate")]
        public async Task<IActionResult> GetNodeArticles ()
        {
            var result = await Mediator.Send(new GenerateUrlsCommand());
            return Ok(); 
        }
    }
}
