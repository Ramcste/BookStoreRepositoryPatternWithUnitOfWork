using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreUW.Data;
using BookStoreUW.Core.Data;

namespace BookStoreUW.Controllers
{
    public class BookController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        private Repository<Book> bookRepository;
    
        public BookController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }
     

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<Book> books = bookRepository.Table.ToList();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = bookRepository.GetById(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult CreateEdit(int? id)
        {
            Book book = new Book();

            if (id.HasValue)
            {
                book = bookRepository.GetById(id);
            }
            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult CreateEdit(Book book)
        {
            if (book.Id == 0)
            {
                book.ModifiedDate = System.DateTime.Now;
                book.AddedDate = System.DateTime.Now;
                book.IP = Request.UserHostAddress;
                bookRepository.Insert(book);
            }
            else
            {
                var editbook = bookRepository.GetById(book.Id);
                editbook.Title = book.Title;
                editbook.Author = book.Author;
                editbook.ISBN = book.ISBN;
                editbook.Published = book.Published;
                editbook.ModifiedDate = System.DateTime.Now;
                editbook.IP = Request.UserHostAddress;
                bookRepository.Update(editbook);

            }

            if (book.Id > 0)
            {
                return RedirectToAction("Index");
            }

           return View(book);
        }

        // GET: Book/Edit/5
     
  

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = bookRepository.GetById(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Book model = bookRepository.GetById(id);
                bookRepository.Delete(model);

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
