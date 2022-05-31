using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_Museo.Data;
using web_app_Museo.Models;

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

        [HttpGet]
        public IActionResult Crea()
        {

            using (MuseoContext db = new MuseoContext())
            {
                List<Categoria> categorie = db.Categorie.ToList();

                CategorieProdotti model = new CategorieProdotti();
                model.Prodotti = new Prodotto();
                model.Categorie = categorie;
                return View("Crea", model);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(CategorieProdotti nuovoProdotto)
        {
            if (!ModelState.IsValid)
            {

                using (MuseoContext db = new MuseoContext())
                {
                    List<Categoria> categorie = db.Categorie.ToList();

                    nuovoProdotto.Categorie = categorie;
                }

                return View("Crea", nuovoProdotto);


            }



            using (MuseoContext db = new MuseoContext())
            {
                Prodotto nuovoProdottoDaAggiungere = new Prodotto();
                nuovoProdottoDaAggiungere.Immagine = nuovoProdotto.Prodotti.Immagine;
                nuovoProdottoDaAggiungere.Nome = nuovoProdotto.Prodotti.Nome;
                nuovoProdottoDaAggiungere.Descrizione = nuovoProdotto.Prodotti.Descrizione;
                nuovoProdottoDaAggiungere.Prezzo = nuovoProdotto.Prodotti.Prezzo;
                nuovoProdottoDaAggiungere.QuantitaDisponibile = 0;
                nuovoProdottoDaAggiungere.CategoriaId = nuovoProdotto.Prodotti.CategoriaId;
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
                return View(prodottoDaEliminare);
            }

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


        [HttpGet]
        public IActionResult Modifica(int id)
        {
            Prodotto? prodottoDaModificare = null;
            List<Categoria> categorie = new List<Categoria>();
            using (MuseoContext db = new MuseoContext())
            {
                    prodottoDaModificare = db.Prodotti
                    .Where(prodotto => prodotto.Id == id)
                    .FirstOrDefault();
                categorie = db.Categorie.ToList<Categoria>();
            }


            if (prodottoDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                CategorieProdotti model = new CategorieProdotti();
                model.Prodotti = prodottoDaModificare;
                model.Categorie = categorie;
                return View("Modifica", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modifica(int id, CategorieProdotti model)
        {
            if (!ModelState.IsValid)
            {
                
                using (MuseoContext db = new MuseoContext())
                {
                    List<Categoria> categorie = db.Categorie.ToList();

                    model.Categorie = categorie;
                    return View("Modifica", model);
                }
            }

            Prodotto? prodottoOriginale = null;

            using (MuseoContext db = new MuseoContext())
            {
                    prodottoOriginale = db.Prodotti
                    .Where(prodotto => prodotto.Id == id)
                    .FirstOrDefault();


                if (prodottoOriginale != null)
                {
                    prodottoOriginale.Immagine = model.Prodotti.Immagine;
                    prodottoOriginale.Nome = model.Prodotti.Nome;
                    prodottoOriginale.Descrizione = model.Prodotti.Descrizione;
                    prodottoOriginale.Prezzo = model.Prodotti.Prezzo;
                    prodottoOriginale.QuantitaDisponibile = prodottoOriginale.QuantitaDisponibile;
                    prodottoOriginale.CategoriaId = model.Prodotti.CategoriaId;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Rifornimento(int id, ProdottiRifornimenti model)
        {
            if (!ModelState.IsValid)
            {
                using (MuseoContext db = new MuseoContext())
                {
                    List<Rifornimento> rifornimenti= db.Rifornimenti.ToList();
                    model.Rifornimenti = rifornimenti;

                }
                return View("Rifornimento", model);
            }
            Prodotto ProdottoDaRifornire = null;
            using (MuseoContext db = new MuseoContext())
            {
                ProdottoDaRifornire = db.Prodotti
                    .Where(Prodotto => Prodotto.Id == id)
                    .FirstOrDefault();

                if (ProdottoDaRifornire != null)
                {   
                                    
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }


    }        
}

