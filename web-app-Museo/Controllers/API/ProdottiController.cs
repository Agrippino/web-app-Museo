using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? cerca)
      {
            //List<Prodotto> listaProdotti = new List<Prodotto>();
            using (MuseoContext db = new MuseoContext())
            {
                var listaProdotti = db.ConteggioLikes.ToList();
                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (cerca != null && cerca != "")
                {
                    listaProdotti = db.ConteggioLikes
                        .Where(p => p.Nome
                        .Contains(cerca))
                        .ToList();
                }
                return Ok(listaProdotti);
            }
                
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

        [HttpPost]
        public IActionResult Like([FromBody] Like model)
        {
            Prodotto modello = null;

            using (MuseoContext db = new MuseoContext())
            {

                modello = db.Prodotti
                    .Where(n => n.Id == model.ProdottoId)
                    .FirstOrDefault();
                if (modello == null)
                {
                    return NotFound();
                }
                else
                {
                
                    model.LikeInseriti = 1;
                    model.ProdottoId = modello.Id;
                    db.Add(model);
                    db.SaveChanges();
                    return Ok();
                }


            }
        }

    }
}
