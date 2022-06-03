using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AcquistoUtenteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (MuseoContext db = new MuseoContext())
            {
                List<Acquisto> listaAcquistí = db.Acquisti.ToList();
                return Ok(listaAcquistí);
            }
        }

        [HttpPost]
        public IActionResult post([FromBody] Acquisto model)
        {

            if (ModelState.IsValid)
            {

                using (MuseoContext db = new MuseoContext())
                {

                List<Prodotto> item = db.Prodotti.Where(item => item.Id == model.ProdottoId).ToList<Prodotto>();
                    if (item.Count == 1)
                    {
                        model.Prodotti = item[0];
                        model.Data = DateTime.Now;
                    }

                    if (model.Prodotti != null)
                    {
                        db.Add(model);
                        db.SaveChanges();
                    }
                }

                return Ok("Message received");
            }       
            else
            {
                return BadRequest("Model not correct");
            }
        }

    }
}
