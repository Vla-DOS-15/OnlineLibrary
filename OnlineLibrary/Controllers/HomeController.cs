using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        LibraryContext dbContext;
        //private IAllBooks allBooks;

        public HomeController(LibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public void Add()
        {
            using (dbContext = new LibraryContext())
            {
                Book book = new Book
                {
                    Name = "qwe",
                    Author = "12",
                    YearCreated = 2000,
                    Path = "Sample.txt"

                };
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }

        }
        // GET: Home
        public ActionResult Index()
        {

                //Book book = new Book
                //{
                //    Name = "qwe",
                //    Author = "12",
                //    YearCreated = 2000,
                //    Path = "Sample.txt"

                //};
                //dbContext.Books.Add(book);
                //dbContext.SaveChanges();
            IEnumerable<Book> books = dbContext.Books;

            //if (string.IsNullOrEmpty(Name))
            //{
                ViewBag.Books = books;
            //}
            //else
            //{
                //ViewBag.Books = books.Where(s => s.Name.Contains(Name) || s.Author.Contains(Name));
            //}
            return View();
            // string[] texts = System.IO.File.ReadAllLines(@"AppData/Sample.txt");
            // ViewBag.Data = texts;
            // return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
