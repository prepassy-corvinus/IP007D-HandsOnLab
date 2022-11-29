using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IP007D_HandsOnLab.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("corvinus/szerverido")]
        public IActionResult GetPontosIdo()
        {
            string pontosIdo = DateTime.Now.ToShortTimeString();
            return new ContentResult
            {
                ContentType = System.Net.Mime.MediaTypeNames.Text.Plain,
                Content = pontosIdo,
            };
        }
    }
}
