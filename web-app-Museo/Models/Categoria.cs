namespace web_app_Museo.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Prodotto> Prodotti { get; set; }

        public Categoria()
        {

        }
        public Categoria(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
