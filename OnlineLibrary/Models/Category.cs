using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
