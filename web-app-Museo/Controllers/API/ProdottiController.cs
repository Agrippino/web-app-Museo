using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Prodotto> listaProdotti = new List<Prodotto>();
            using (MuseoContext db = new MuseoContext())
            {
                listaProdotti = db.Prodotti.ToList();

            }
                return Ok(listaProdotti);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int? id)
        {
            using (MuseoContext db = new MuseoContext())
            {
                if (id != null)
                {

                    Prodotto info = db.Prodotti.Where(info => info.Id == id).FirstOrDefault<Prodotto>();
                    return Ok(info);
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
