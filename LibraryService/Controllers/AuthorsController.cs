using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryService.Controllers
{
    public class AuthorsController : ApiController
    {
        private IAuthorRepo authorRepo;
        public AuthorsController(IAuthorRepo _authorRepo)
        {
            this.authorRepo = _authorRepo;
        }

        [HttpGet]
        public List<Author> Get()
        {
            return authorRepo.GetAllAuthor();
        }

        [HttpGet]
        [Route("api/authors/{id}")]
        public IHttpActionResult GetAuthor(int id)
        {
            Author author = authorRepo.GetAuthor(id);
            if(author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public IHttpActionResult Post(Author author)
        {
            Author newAuthor = authorRepo.AddNewAuthor(author);
            if(newAuthor == null)
            {
                return NotFound();
            }
            return Ok(newAuthor);
        }

        [HttpDelete]
        [Route("api/authors/{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool res = authorRepo.RemoveAuthor(id);
            if( res == false)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut]
        [Route("api/authors/{id}")]
        public IHttpActionResult Put(int id, Author author)
        {
            Author uauthor = authorRepo.UpdateAuthor(id, author);
            if( uauthor == null)
            {
                return NotFound();
            }
            return Ok(uauthor);
        }

    }
}
