using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using LibraryService.Controllers;
using LibraryService_datalayer.IRepositories;
using LibraryService_datalayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest_libraryService
{
    [TestClass]
    public class UnitTest_authors
    {
        [TestMethod]
        public void TestAuthorsGet()
        {
            //Arrange         

            var AuthorRepoMockClass = new Mock<IAuthorRepo>();
            List<Author> getAuthorsObj = new List<Author>()
            {
                new Author{Id=1, FirstName="Huma", LastName="shadu", DOB= DateTime.Now, Email ="shadu@email.com", Book=null, Created= DateTime.Now},
                new Author{Id=2, FirstName="John", LastName="Doe", DOB= DateTime.Now, Email="john@email.com", Book=null, Created= DateTime.Now}
            };

            AuthorRepoMockClass.Setup(x => x.GetAllAuthor()).Returns(getAuthorsObj);
            var authorsController = new AuthorsController(AuthorRepoMockClass.Object);

            ////Act
            List<Author> result = authorsController.Get();

            ////Assert
            Assert.AreEqual(result[0].FirstName, "Huma");
            Assert.AreEqual(result[1].Email,"john@email.com");

        }

        [TestMethod]
        public void TestAuthorsGetAuthor()
        {
            //Arrange
            var AuthorRepoMockClass = new Mock<IAuthorRepo>();

            var getAuthorObj = new Author { Id = 1, FirstName = "Huma", LastName = "shadu", DOB = DateTime.Now, Email = "shadu@email.com", Book = null, Created = DateTime.Now };
            AuthorRepoMockClass.Setup(x => x.GetAuthor(2)).Returns(getAuthorObj);
            var authorsController = new AuthorsController(AuthorRepoMockClass.Object);

            //Act
            IHttpActionResult result = authorsController.GetAuthor(2);
            var resultAuthor = result as OkNegotiatedContentResult<Author>;

            //Assert
            Assert.AreEqual(resultAuthor.Content.FirstName, "Huma");
            Assert.AreEqual(resultAuthor.Content.Id, 1);

        }

        [TestMethod]
        public void TestAuthorsPost()
        {
            //Arrange
            var AuthorRepoMockClass = new Mock<IAuthorRepo>();

            var author = new Author { FirstName = "Huma", LastName = "shadu", DOB = DateTime.Now, Email = "shadu@email.com", Created = DateTime.Now };
            AuthorRepoMockClass.Setup(x => x.AddNewAuthor(author)).Returns(author);
            var authorsController = new AuthorsController(AuthorRepoMockClass.Object);

            //Act
            IHttpActionResult result = authorsController.Post(author);
            var resultAuthor = result as OkNegotiatedContentResult<Author>;

            //Assert
            Assert.AreEqual(resultAuthor.Content.FirstName, "Huma");
            Assert.AreEqual(resultAuthor.Content.Email, "shadu@email.com");
        }

        [TestMethod]
        public void testAuhtorsDelete()
        {
            //Arrange
            var AuthorRepoMockClass = new Mock<IAuthorRepo>();
            var expected = true;
            AuthorRepoMockClass.Setup(x => x.RemoveAuthor(2)).Returns(expected);
            var authorsController = new AuthorsController(AuthorRepoMockClass.Object);

            //Act
            IHttpActionResult result = authorsController.Delete(2);
            var resultDel = result as OkNegotiatedContentResult<bool>;

            //Assert
            Assert.AreEqual(resultDel.Content, true);

        }

        [TestMethod]
        public void testAuthorsPut()
        {
            //Arrange
            var AuthorRepoMockClass = new Mock<IAuthorRepo>();
            var author = new Author { FirstName = "Huma", LastName = "shadu", DOB = DateTime.Now, Email = "shadu@email.com", Created = DateTime.Now };
            AuthorRepoMockClass.Setup(x => x.UpdateAuthor(2, author)).Returns(author);
            var authorsController = new AuthorsController(AuthorRepoMockClass.Object);

            //Act
            IHttpActionResult result = authorsController.Put(2, author);
            var resultAuthor = result as OkNegotiatedContentResult<Author>;

            //Assert
            Assert.AreEqual(resultAuthor.Content, author);
        }
    }
}
