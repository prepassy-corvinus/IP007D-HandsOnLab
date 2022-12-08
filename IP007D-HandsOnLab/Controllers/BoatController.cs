using IP007D_HandsOnLab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IP007D_HandsOnLab.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("questions/{sorszam}")]
        public ActionResult Kerdes(int sorszam)
        {
            HajosContext context = new HajosContext();
            //var kerdesek = from x in context.Questions select x.Question1;
            var kerdes = (from x in context.Questions
                          where x.QuestionId == sorszam
                          select x).FirstOrDefault();

            if (kerdes == null) return BadRequest("Nincs ilyen sorszamu kerdes.");

            return new JsonResult(kerdes);
        }
    }
}
