using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Titel")]
        public string Titel { get; set; }

        public DateTime isDeleted { get; set; } = DateTime.MaxValue;

        [Display(Name = "Auteur")]
        [ForeignKey ("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
