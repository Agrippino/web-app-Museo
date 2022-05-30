using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AcquistiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            using (MuseoContext db = new MuseoContext())
            {
                // Load all blogs and related posts.
               var acquistiMensili = db.Acquisti
                                    .Include(b => b.Prodotti)
                                    .ToList();

                return Ok(acquistiMensili);
            }
        }
    }
}
