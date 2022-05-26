using System.ComponentModel.DataAnnotations;

namespace web_app_Museo.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
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
