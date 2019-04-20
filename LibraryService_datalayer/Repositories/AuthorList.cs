using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Repositories
{
    public class AuthorList : IAuthorRepo
    {
        List<Author> authorList = new List<Author>()
        {
            new Author{ Id=1, FirstName="Huma", LastName="Shadu", Email="shadu@email.com", DOB= DateTime.Now, Book=null, Created=DateTime.Now},
            new Author{ Id=2, FirstName="John", LastName="Doe", Email="john@email.com", DOB= DateTime.Now, Book=null, Created=DateTime.Now}

        };
        public Author AddNewAuthor(Author author)
        {
            authorList.Add(author);
            return author;
        }

        public List<Author> GetAllAuthor()
        {
            return authorList;
        }

        public Author GetAuthor(int id)
        {
            Author author = authorList.FirstOrDefault(x=>x.Id == id);            
            if(author == null)
            {
                return null;
            }
            return author;
        }

        public bool RemoveAuthor(int id)
        {
            Author author = this.GetAuthor(id);
            if(author == null)
            {
                return false;
            }
            authorList.Remove(author);
            return true;
        }

        public Author UpdateAuthor(int id, Author author)
        {
            if (this.RemoveAuthor(id))
            {
                this.AddNewAuthor(author);
            }
            return author;
        }
    }
}
