using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryService.Controllers
{
    //[EnableCors(origins: "http://localhost:50751/", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        private IBookRepo bookRepo;
        public BooksController(IBookRepo _bookRepo)
        {
            this.bookRepo = _bookRepo;
        }
        
        [HttpGet]
        public List<Book> Get()
        {
            return bookRepo.GetAllBook();
        }

        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult Get(int id)
        {           
            Book book = bookRepo.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        [Route("api/books/{id}/getauthor")]
        public IHttpActionResult GetAuthorByBookId(int id)
        {
            string authorName = bookRepo.GetAuthorByBookId(id);
            if(authorName == null)
            {
                return NotFound();
            }
            return Ok(authorName);
        }

        [HttpGet]
        [Route("api/books/author/{authorId}")]
        public IHttpActionResult GetBooksByAuthorId(int authorId)
        {
            List<Book> books = bookRepo.GetBooksByAuthorId(authorId);
            if(books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("api/books/authorname/{authorname}")]
        public IHttpActionResult GetBooksByAuthorName(string authorName)
        {
            List<Book> books = bookRepo.GetBooksByAuthorName(authorName);
            if(books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("api/books/search/{searchtext}")]
        public IHttpActionResult SearchBook(string searchtext)
        {
            List<Book> books = bookRepo.GetBooksByTitle(searchtext);
            if (books == null)
            {
                return NotFound();
            }
            
            return Ok(books);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            Book bk = bookRepo.AddNewBook(book);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(bk);
            
        }

        [HttpDelete]
        [Route("api/books/{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool res = bookRepo.RemoveBook(id);
            if(res == false)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut]
        [Route("api/books/{id}")]
        public IHttpActionResult Put(int id, Book book)
        {
            Book ubook = bookRepo.UpdateBook(id, book);
            if(ubook == null)
            {
                return NotFound();
            }
            return Ok(ubook);
        }

        [HttpPut]
        [Route("api/books/{id}/addcost/")]
        public IHttpActionResult Put(int id, Cost cost)
        {
            Book bk = bookRepo.AddCost(id, cost);
            if(bk == null)
            {
                return NotFound();
            }
            return Ok(bk);
        }
    }
}
