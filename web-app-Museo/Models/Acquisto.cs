using System.ComponentModel.DataAnnotations;

namespace web_app_Museo.Models
{
    public class Acquisto
    {   [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage ="Per favore inserisci un parametro, questo campo è obbligatorio")]
        [Range(1,1000,ErrorMessage ="Mi dispiace questa quantità non è disponibile, il minomo è 1 pezzo e il massimo è 1000 pezzi")]
        public int QuantitaDaAcquistare { get; set; }

        public Acquisto()
        {

        }

        public int ProdottoId { get; set; }
        public Prodotto Prodotti { get; set; }

        public Acquisto (DateTime data, int quantitaDaAcquistare)
        {
            this.Data = data;
            this.QuantitaDaAcquistare = quantitaDaAcquistare;
            
        }

    }
}
