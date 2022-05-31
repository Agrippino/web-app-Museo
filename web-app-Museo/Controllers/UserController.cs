using Microsoft.AspNetCore.Mvc;
using web_app_Museo.Data;

namespace web_app_Museo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dettagli()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AcquistiMensili()
        {
            return View();
        }
        public IActionResult prova()
        {
            using (MuseoContext db = new MuseoContext())
            {

                var quantita = db.QuantitaDisponibili.ToList();
                return View(quantita);
            }

        }

    }
}
