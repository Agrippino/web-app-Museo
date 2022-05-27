using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_app_Museo.Models
{
    public class Prodotto
    {   
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Per favore inserisci un'imamgine, questo campo obbligatorio")]
        [Url(ErrorMessage = "Non hai inserito un Url valido")]
        public string Immagine { get; set; }
        [Required(ErrorMessage ="Per favore inserisci un nome prodotto, questo campo è obbligatorio")]
        [StringLength(30, ErrorMessage = "Hai superato il limite di caratteri massimo di 30")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Per favore inserisci una descrizone del prodotto, questo campo è obbligatorio")]
        [StringLength(400, ErrorMessage = "Hai superato il limite di caratteri massimo di 250")]
        [Column(TypeName="Text")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Per favore inserisci il prezzo del prodotto, questo campo è obbligatorio")]
        [Range(0.01,1000, ErrorMessage = "Mi dispaice hai inserito un prezzo non valido, i minimo è 0.01€ mentre il massimo è 10000€ ")]

        public double Prezzo { get; set; }
        [Required(ErrorMessage = "Per favore inserisci la quantità disponibile del prodotto, questo campo è obbligatorio")]
        [Range(1, 1000, ErrorMessage = "Mi dispaice hai inserito una quantità non valida, il minimo è 1 mentre il massimo è 10000")]
        public int QuantitaDisponibile { get; set; }

        public Prodotto()
        {

        }

        public int? CategoriaId { get; set; }
        public Categoria? Categorie { get; set; }
        public List<Acquisto>? Acquisti { get; set; }
        public List<Rifornimento>? Rifornimenti { get; set; }

        public Prodotto(string immagine,string nome, string descrizione, double prezzo, int quantitadisponibile)
        {
            this.Immagine= immagine;
            this.Nome= nome;
            this.Descrizione= descrizione; 
            this.Prezzo= prezzo;
            this.QuantitaDisponibile= quantitadisponibile;

        }

    }
}
