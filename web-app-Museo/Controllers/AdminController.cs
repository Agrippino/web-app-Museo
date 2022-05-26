using Microsoft.AspNetCore.Mvc;

namespace web_app_Museo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Index()
        {
            List<Prodotto> listaProdotti = new List<Prodotto>();
            using (MuseoContext db = new MuseoContext())
            {
                listaProdotti = db.Prodotti.ToList();
            }

          
            return View("Index", listaProdotti);
        }

        /*
        public IActionResult Modifica(int? id)
        {
            //Se il database è vuoto o l'id nullo ritorno notfound
            if (id == null || db.Prodotti == null)
            {
                return NotFound();
            }
            //Se non c'è l'id ritorno notfound
            var travelPackageModel =  db.Prodotti.FindAsync(id);
            if (travelPackageModel == null)
            {
                return NotFound();
            }
            return View(travelPackageModel);
        }

        */



    }
}
