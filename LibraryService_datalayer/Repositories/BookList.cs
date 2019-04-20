using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Repositories
{
    public class BookList : IBookRepo
    {
        List<Book> bookList = new List<Book>()
        {
            new Book{Id = 1, Title="Nonai", PublicationYear=1998, IsAvailable=true, AuthorId=1, CostId=null, Created=DateTime.Now},
            new Book{Id = 2, Title="Cast away", PublicationYear=2001, IsAvailable=false, AuthorId=2, CostId=null, Created=DateTime.Now}
        };

        public Book AddNewBook(Book book)
        {
            bookList.Add(book);
            return book;
        }

        public List<Book> GetAllBook()
        {
            return bookList;
        }

        public string GetAuthorByBookId(int id)
        {
            return bookList.FirstOrDefault(x => x.Id == id).Author.FullName;
        }

        public Book GetBook(int id)
        {
            return bookList.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooksByAuthorId(int authorId)
        {
            return bookList.Where(x => x.AuthorId == authorId).ToList();
        }

        public List<Book> GetBooksByAuthorName(string authorName)
        {
            return bookList.Where(x => x.Author.FirstName.Contains(authorName) || x.Author.LastName.Contains(authorName)).ToList();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            return bookList.Where(x => x.Title == title).ToList();
        }

        public bool RemoveBook(int id)
        {
            Book book = this.GetBook(id);
            if(book == null)
            {
                return false;
            }
            bookList.Remove(book);
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
            return book;
        }
    }
}
