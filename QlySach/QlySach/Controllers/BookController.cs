using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QlySach.Models;

namespace QlySach.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var book = _appDbContext.Books.Include(p => p.Category).ToList();
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Books.Add(book);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _appDbContext.Books.Find(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteBook(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _appDbContext.Books.Find(id);
            if (book == null) return NotFound();

            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
