using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_app_Museo.Data;
using web_app_Museo.Models;

namespace web_app_Museo.Controllers.API
{
    [Route("api/[controller/Action]")]
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
    }
}
