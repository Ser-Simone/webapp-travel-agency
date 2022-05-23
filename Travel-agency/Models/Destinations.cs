using System.ComponentModel.DataAnnotations;

namespace Travel_agency.Models
{
    public class Destinations
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Il Titolo è obbligatorio")]
        public string title { get; set; }
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        public string description { get; set; }

        public string image { get; set; }
        public double price { get; set; }

        public Destinations()
        {

        }

        public Destinations(string title, string description, string image, double price)
        {
            this.title = title;
            this.description = description;
            this.image = image;
            this.price = price;
        }
    }
}
