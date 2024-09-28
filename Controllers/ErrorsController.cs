using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError()
        {
            return Problem();
        }
    }
}
