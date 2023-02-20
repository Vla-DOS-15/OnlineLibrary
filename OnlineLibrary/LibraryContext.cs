using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
