using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {

        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public DateTime isDeleted { get; set; } = DateTime.MaxValue;

        [Display(Name = "Boeken")]
        public List<Book> Books { get; set; } = new List<Book>();

    }
}
