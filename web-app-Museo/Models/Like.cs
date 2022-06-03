using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace web_app_Museo.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public int LikeInseriti { get; set; }

        public int ProdottoId { get; set; }
        [JsonIgnore]
        public Prodotto? Prodotto { get; set; }
    }
}
