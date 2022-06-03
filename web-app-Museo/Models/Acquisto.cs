using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace web_app_Museo.Models
{
    public class Acquisto
    {   [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }

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
