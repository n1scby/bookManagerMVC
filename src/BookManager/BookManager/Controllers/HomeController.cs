using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookManager.Models;
using nb.BookLibrary;

namespace BookManager.Controllers
{
    public class HomeController : Controller
    {

        private BookRepository bookRepo = new BookRepository();
        private static bool repoBuilt = false;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult BookExample()
        {
            ViewData["Message"] = "This is a book example.";
            // List<Book> Books = new List<Book>();

            if (!repoBuilt)   //If first time through - add books.
            {
                Book newBook = new Book
                {
                    Id = 0,
                    Author = "Stephen King",
                    Title = "The Dark Tower"
                };

                //   Books.Add(newBook);
                bookRepo.Add(newBook);

                newBook = new Book
                {
                    Id = 1,
                    Author = "Dean Koontz",
                    Title = "Odd Thomas"
                };

                // Books.Add(newBook);
                bookRepo.Add(newBook);

                newBook = new Book
                {
                    Id = 2,
                    Author = "Jim Butcher",
                    Title = "Storm Front"
                };
                // Books.Add(newBook);
                bookRepo.Add(newBook);
                repoBuilt = true;
            }

            // show random book
            Random rnd = new Random();
            int num = rnd.Next(0, 3);


            return View(bookRepo.getBookById(num));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
