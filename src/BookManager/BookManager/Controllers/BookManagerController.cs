using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nb.BookLibrary;

namespace BookManager.Controllers
{
    public class BookManagerController : Controller
    {
        BookRepository bookRepo = new BookRepository();

        // GET: BookManager
        public ActionResult Index()
        {   
            return View(bookRepo.ListBooks());
        }

        // GET: BookManager/Details/5
        public ActionResult Details(int id)
        {
            return View(bookRepo.getBookById(id));
        }

        // GET: BookManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book newBook, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                bookRepo.Add(newBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bookRepo.getBookById(id));
        }

        // POST: BookManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book updatedBook, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                bookRepo.Edit(updatedBook);
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookRepo.getBookById(id));
        }

        // POST: BookManager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bookRepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}