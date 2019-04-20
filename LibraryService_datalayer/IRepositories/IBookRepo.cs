using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.IRepositories
{
    public interface IBookRepo
    {
        List<Book> GetAllBook();
        Book GetBook(int id);
        Book AddNewBook(Book book);
        Book UpdateBook(int id, Book book);
        bool RemoveBook(int id);
        Book AddCost(int bookId, Cost cost);
        string GetAuthorByBookId(int id);
        List<Book> GetBooksByAuthorId(int authorId);
        List<Book> GetBooksByAuthorName(string authorName);
        List<Book> GetBooksByTitle(string title);
    }
}
