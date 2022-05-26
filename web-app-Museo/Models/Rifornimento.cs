namespace web_app_Museo.Models
{
    public class Rifornimento
    {
        public int Id { get; set; }
        public int QuantitaDaAggiungere { get; set; }


        public int? ProdottoId { get; set; }
        public Prodotto? Prodotto { get; set; }

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
