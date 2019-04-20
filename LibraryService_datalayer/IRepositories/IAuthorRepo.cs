using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.IRepositories
{
    public interface IAuthorRepo
    {
        List<Author> GetAllAuthor();
        Author GetAuthor(int id);
        Author AddNewAuthor(Author author);
        bool RemoveAuthor(int id);
        Author UpdateAuthor(int id, Author author);
        
    }
}
