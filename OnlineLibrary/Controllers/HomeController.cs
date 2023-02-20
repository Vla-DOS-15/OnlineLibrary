using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace OnlineLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        LibraryContext dbContext;

        public HomeController(LibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActionResult Index(string Name)
        {
            IEnumerable<Book> books = dbContext.Books.Include(x=>x.Category);

            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.Books = books;
            }
            else
            {
                ViewBag.Books = books.Where(s => s.Name.Contains(Name) || s.Author.Contains(Name) || s.Category.CategoryName.Contains(Name));
            }
            return View();
        }
        [HttpGet]
        public ActionResult BookInfo(int? id)
        {
            if (id == null)
                return RedirectToAction("/Home/Index");
            ViewBag.BookId = id;
            IEnumerable<Book> books = dbContext.Books.Include(x=>x.Category).Where(x => x.IdBook == id);
            ViewBag.Books = books;
            var path = "";
            foreach (Book book in books)
                path = book.Path;
            Console.WriteLine(path);    
            string[] texts = System.IO.File.ReadAllLines($"AppData/{path}.txt");
            ViewBag.Data = texts;
            
            return View();
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
