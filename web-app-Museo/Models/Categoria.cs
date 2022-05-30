using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace web_app_Museo.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }

        [JsonIgnore]
        public List<Prodotto> Prodotti { get; set; }

        public Categoria()
        {

        }
    }
}
