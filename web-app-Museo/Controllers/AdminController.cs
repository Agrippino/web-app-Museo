using Microsoft.AspNetCore.Mvc;
using web_app_Museo.Data;

namespace web_app_Museo.Controllers
{
    public class AdminController : Controller
    {
   

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

        public IActionResult Crea()
        {
            return View();
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(Prodotto nuovoProdotto)
        {
            if (!ModelState.IsValid)
            {
                return View("Crea", nuovoProdotto);
            }


            using (MuseoContext db = new MuseoContext())
            {
                Prodotto nuovoProdottoDaAggiungere = new Prodotto(nuovoProdotto.Name, nuovoProdotto.Description, nuovoProdotto.Image, nuovoProdotto.Price);

                db.Prodotti.Add(nuovoProdottoDaAggiungere);
                db.SaveChanges();
            }
            //Controlla questo
            return RedirectToAction("Index");
        }


        public IActionResult Elimina(int? id)
        {

            using (MuseoContext db = new MuseoContext())
            {
                //Se il database è vuoto o l'id nullo ritorno notfound
                if (id == null || db.Prodotti == null)
                {
                    return NotFound();
                }

                var prodottoDaEliminare = db.Prodotti
                    .Where(prodotto => prodotto.Id == id)
                    .FirstOrDefault();
                //Controlla se è corretto
                if (prodottoDaEliminare == null)
                {
                    return NotFound();
                }
            }
           

            return View(prodottoDaEliminare);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(int id)
        {
            Prodotto? prodottoDaRimuovere = null;

            using (MuseoContext db = new MuseoContext())
            {
                /*
                if (db.Prodotti == null)
                {
                    return Problem("Il database è vuoto");
                }
                */
                prodottoDaRimuovere = db.Prodotti
                    .Where(prodotto => prodotto.Id == id)
                    .FirstOrDefault();

                if (prodottoDaRimuovere != null)
                {
                    db.Prodotti.Remove(prodottoDaRimuovere);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
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
