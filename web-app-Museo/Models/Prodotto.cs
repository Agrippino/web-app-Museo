namespace web_app_Museo.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Immagine { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public int QuantitaDisponibile { get; set; }

        public Prodotto()
        {

        }      
        public Prodotto(string immagine,string nome, string descrizione, double prezzo, int quantitadisponibile)
        {
            this.Immagine= immagine;
            this.Nome= nome;
            this.Descrizione= descrizione; 
            this.Prezzo= prezzo;
            this.QuantitaDisponibile= quantitadisponibile;

        }

    }
}
