using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Repositories
{
    public class BookDB : IBookRepo
    {
        LibraryContext db = new LibraryContext();
        public Book AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public List<Book> GetAllBook()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            //Book book = db.Books.FirstOrDefault(x => x.Id == id);
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public bool RemoveBook(int id)
        {
            Book book = this.GetBook(id);
            if( book == null)
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;            
        }

        public Book UpdateBook(int id, Book book)
        {
            if (this.RemoveBook(id))
            {
                this.AddNewBook(book);
            }
            return book;
        }

        public Book AddCost(int bookId, Cost cost)
        {
            Book book = this.GetBook(bookId);
            book.Cost = cost;
            db.SaveChanges();
            return book;
        }

        public string GetAuthorByBookId(int id)
        {                
            return db.Books.Find(id).Author.FullName;
        }

        public List<Book> GetBooksByAuthorId(int authorId)
        {
            return db.Books.Where(x => x.AuthorId == authorId).ToList();            
        }

        public List<Book> GetBooksByAuthorName(string authorName)
        {
            return db.Books.Where(x => x.Author.FirstName.Contains(authorName) || x.Author.LastName.Contains(authorName)).ToList();            
        }

        public List<Book> GetBooksByTitle(string title)
        {
            return db.Books.Where(x => x.Title.Contains(title)).ToList();
        }
    }
}
