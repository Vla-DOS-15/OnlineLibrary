using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearCreated { get; set; }
        public string Path { get; set; }
    }
}
