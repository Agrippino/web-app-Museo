namespace web_app_Museo.Models
{
    public class ProdottiAcquisti
    { 
        public Prodotto Prodotti { get; set; }
        public List<Acquisto>? Acquisti { get; set; }
    }
}
