namespace web_app_Museo.Models
{
    public class Acquisti
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int QuantitaDaAcquistare { get; set; }

        public Acquisti()
        {

        }

        public Acquisti (DateTime data, int quantitadaacquistare)
        {
            this.Data = data;
            this.QuantitaDaAcquistare = quantitadaacquistare;
        }

    }
}
