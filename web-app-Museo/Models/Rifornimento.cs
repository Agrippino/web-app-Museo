using System.ComponentModel.DataAnnotations;

namespace web_app_Museo.Models
{
    public class Rifornimento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo quantita è obbligatorio")]
        [Range(1, 1000, ErrorMessage = "Il valore inserito non è corretto")]
        public int QuantitaDaAggiungere { get; set; }

        public int ProdottoId { get; set; }

        public Prodotto Prodotto { get; set; }

        public DateTime?  DataRifornimento { get; set; }
        [Required(ErrorMessage = "Il nome fornitore è obbligatorio")]
        public string NomeFornitore { get; set; }

        public Rifornimento()
        {

        }
        public Rifornimento(int id, int quantitaDaAggiungere)
        {
            this.Id = id;
            this.QuantitaDaAggiungere = quantitaDaAggiungere;
        }

    }
}
