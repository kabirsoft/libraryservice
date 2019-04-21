using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;

namespace LibraryService_FrontEnd.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext db = new LibraryContext();
        private IBookRepo bookrepo;
        public BooksController(IBookRepo _bookrepo)
        {
            this.bookrepo = _bookrepo;
        }

        // GET: Books
        public ActionResult Index()
        {            
            var books = bookrepo.GetAllBook();
            return View(books);            
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {   
            Book book = bookrepo.GetBook(id);
            if (book == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FullName");
            ViewBag.CostId = new SelectList(db.Costs, "Id", "Id");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PublicationYear,IsAvailable,AuthorId,CostId,Created,RowVersion")] Book book)
        {
            if (ModelState.IsValid)
            {                
                bookrepo.AddNewBook(book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", book.AuthorId);
            ViewBag.CostId = new SelectList(db.Costs, "Id", "Id", book.CostId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {   
            Book book = bookrepo.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FullName", book.AuthorId);
            ViewBag.CostId = new SelectList(db.Costs, "Id", "Id", book.CostId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PublicationYear,IsAvailable,AuthorId, CostId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", book.AuthorId);
            ViewBag.CostId = new SelectList(db.Costs, "Id", "Id", book.CostId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id )
        {   
            Book book = bookrepo.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            bookrepo.RemoveBook(id);            
            return RedirectToAction("Index");
        }

        // POST: Books/AddCost
        [HttpPost]
        public ActionResult AddCost(Cost cost)
        {           
            var bookid = Convert.ToInt32(Request["Id"]);
            Book book = bookrepo.AddCost(bookid, cost);
            if (book == null)
            {
                return HttpNotFound();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult SearchBook(string searchtext)
        {
            List<Book> books = bookrepo.GetBooksByTitle(searchtext);
            if( books == null)
            {
                return HttpNotFound();
            }
            ViewBag.searchText = searchtext;
            return View(books);
        }

        [HttpPost]
        public ActionResult GetBooksByAuthorName(string authorName)
        {
            List<Book> books = bookrepo.GetBooksByAuthorName(authorName);
            if(books == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorName = authorName;
            return View(books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
