using Microsoft.AspNetCore.Mvc;
using web_app_Museo.Data;
using web_app_Museo.Models;

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
        public IActionResult Acquisto()
        {
            using (MuseoContext db = new MuseoContext())
            {
                List<Prodotto> prodotti = db.Prodotti.ToList();

                ProdottiAcquisti model = new ProdottiAcquisti();
                model.Acquisti = new Acquisto();
                model.Prodotti = prodotti;
                return View("Acquisto", model);
            }
        }
        [HttpPost]
        public IActionResult Acquisto(ProdottiAcquisti model)
        {
            model.Acquisti.Data = DateTime.Now;
            if (!ModelState.IsValid)
            {
                using (MuseoContext db = new MuseoContext())
                {
                    List<Prodotto> prodotti = db.Prodotti.ToList();

                    model.Prodotti = prodotti;
                }
                return View("Acquisto", model);
            }



            using (MuseoContext db = new MuseoContext())
            {
                Acquisto nuovoAcquisto = new Acquisto();
                nuovoAcquisto.QuantitaDaAcquistare = model.Acquisti.QuantitaDaAcquistare;
                nuovoAcquisto.Data = DateTime.Now;
                nuovoAcquisto.ProdottoId = model.Acquisti.ProdottoId;
                db.Acquisti.Add(nuovoAcquisto);
                db.SaveChanges();
            }
            //Controlla questo
            return RedirectToAction("Index");
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

                var quantita = db.QuantitaAggiunte.ToList();
                return View(quantita);
            }

        }

    }
}

    