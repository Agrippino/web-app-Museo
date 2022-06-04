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
            List<QuantitaDisponibile> listaProdotti = new List<QuantitaDisponibile>();
            using (MuseoContext db = new MuseoContext())
            {
                
                listaProdotti = db.QuantitaDisponibili.ToList();
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
        

        //GET RIFORNIMENTO utilizzando un modello dinamico, in modo da ricevere sia il modello prodotto che la tabella view di entity framework con la quanità totale
        [HttpGet]
        public IActionResult Rifornimento(int id)
        {
            using (MuseoContext db = new MuseoContext())
            {
                var quantitaDisponibili = db.QuantitaDisponibili.Where(prodotto => prodotto.Id == id).FirstOrDefault();
                var prodotti = db.Prodotti.Where(prodotto => prodotto.Id == id).FirstOrDefault();
                var rifornimenti = db.Rifornimenti.Where(prodotto => prodotto.ProdottoId == id).ToList();
                dynamic myDynamicmodel = new System.Dynamic.ExpandoObject();
                myDynamicmodel.QuantitaDisponibili = quantitaDisponibili;
                myDynamicmodel.Prodotti = prodotti;
                myDynamicmodel.Rifornimenti = rifornimenti;
                return View(myDynamicmodel);
            }


        }


        [HttpPost]
        public IActionResult Rifornimento(int id, int quantitaDaAggiungere, string nomeFornitore)
        {
            /*
            if (!ModelState.IsValid)
            {
                return View("Rifornimento", model);
            }
            */
            Rifornimento nuovoRifornimento = new Rifornimento();
            using (MuseoContext db = new MuseoContext())
            {
                nuovoRifornimento.QuantitaDaAggiungere = quantitaDaAggiungere;
                nuovoRifornimento.NomeFornitore = nomeFornitore;
                nuovoRifornimento.ProdottoId = id;

                db.Rifornimenti.Add(nuovoRifornimento);
                db.SaveChanges();

                

                return RedirectToAction("Index");
              
            }

        }


    }        
}

