using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Repositories
{
    public class AuthorDB : IAuthorRepo
    {
        LibraryContext db = new LibraryContext();
        public Author AddNewAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author;
        }

        public List<Author> GetAllAuthor()
        {
            return db.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            //Author author = db.Authors.Find(id);
            return db.Authors.FirstOrDefault(x => x.Id == id);
        }     

        public bool RemoveAuthor(int id)
        {
            Author author = this.GetAuthor(id);
            if(author == null)
            {
                return false;
            }
            db.Authors.Remove(author);
            db.SaveChanges();
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
