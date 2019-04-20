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
    public class UnitTest_Books
    {
        [TestMethod]
        public void TestBooksGet()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", PublicationYear=2011,IsAvailable=true, AuthorId=1, Created=DateTime.Now },
                new Book{Id=2,  Title="Ruposhi Bangla", PublicationYear=1968, IsAvailable=true, AuthorId=1, Created=DateTime.Now }              
            };

            BookRepoMockClass.Setup(x => x.GetAllBook()).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            List<Book> result = booksController.Get();

            //Assert
            Assert.AreEqual(result[0].Title, "Nonai");
            Assert.AreEqual(result[1].PublicationYear, 1968);
        }
        
        [TestMethod]
        public void testBooksGetbook()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            var getBookObj = new Book { Id = 1, Title = "Nonai", PublicationYear = 2011, IsAvailable = true, AuthorId = 1, Created = DateTime.Now };
            BookRepoMockClass.Setup(x => x.GetBook(2)).Returns(getBookObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.Get(2);
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(resultBook.Content.Id, 1);
            Assert.AreEqual(resultBook.Content.Title, "Nonai");
        }

        [TestMethod]
        public void testBooksGetAuthorByBookId()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            string expected = "Huma";
            BookRepoMockClass.Setup(x => x.GetAuthorByBookId(2)).Returns(expected);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetAuthorByBookId(2);
            var resultBook = result as OkNegotiatedContentResult<string>;

            //Assert
            Assert.AreEqual(resultBook.Content, expected);
        }

        [TestMethod]
        public void testBooksGetBooksByAuthorId()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", PublicationYear=2011,IsAvailable=true, AuthorId=1, Created=DateTime.Now },
                new Book{Id=2,  Title="Cast away", PublicationYear=1968, IsAvailable=true, AuthorId=1, Created=DateTime.Now }
            };

            BookRepoMockClass.Setup(x => x.GetBooksByAuthorId(1)).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetBooksByAuthorId(1);
            var resultBook = result as OkNegotiatedContentResult<List<Book>>;

            //Assert
            Assert.AreEqual(resultBook.Content[0].Title, "Nonai");
            Assert.AreEqual(resultBook.Content[1].Id, 2);
        }

        [TestMethod]
        public void testBooksGetBooksByAuthorName()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", PublicationYear=2011,IsAvailable=true, AuthorId=1, Created=DateTime.Now },
                new Book{Id=2,  Title="Cast away", PublicationYear=1968, IsAvailable=true, AuthorId=1, Created=DateTime.Now }
            };

            BookRepoMockClass.Setup(x => x.GetBooksByAuthorName("Huma")).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetBooksByAuthorName("Huma");
            var resultBook = result as OkNegotiatedContentResult<List<Book>>;

            //Assert
            Assert.AreEqual(resultBook.Content[0].Title, "Nonai");
            Assert.AreEqual(resultBook.Content[1].Id, 2);
        }

        [TestMethod]
        public void testBooksPost()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
           var book = new Book { Id = 1, Title = "Nonai", PublicationYear = 2011, IsAvailable = true, AuthorId = 1, Created = DateTime.Now };
            BookRepoMockClass.Setup(x => x.AddNewBook(book)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);
            
           //Act
            IHttpActionResult result = booksController.Post(book);
            var resultBook = result as OkNegotiatedContentResult<Book>;
           
            //Assert
            Assert.AreEqual(resultBook.Content.Title, "Nonai");
        }

        [TestMethod]
        public void testBooksDelete()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            var expected = true;
            BookRepoMockClass.Setup(x => x.RemoveBook(2)).Returns(expected);
            var booksController = new BooksController(BookRepoMockClass.Object);
            //Act
            IHttpActionResult result = booksController.Delete(2);
            var resultDel = result as OkNegotiatedContentResult<bool>;
            //Assert
            Assert.AreEqual(resultDel.Content, true);
        }

        [TestMethod]
        public void testBooksPut()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            int id = 1;
            var book = new Book { Id = 1, Title = "Nonai", PublicationYear = 2011, IsAvailable = true, AuthorId = 1, Created = DateTime.Now };

            BookRepoMockClass.Setup(x => x.UpdateBook(id, book)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.Put(id, book);
            var resultBooks = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(resultBooks.Content, book);
        }

        [TestMethod]
        public void testBooksAddCost()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            int id = 2;
            Cost cost = new Cost { Price = 220, Discount = true };
            var book = new Book { Id = 1, Title = "Nonai", PublicationYear = 2011, IsAvailable = true, AuthorId = 1, Created = DateTime.Now };
            book.Cost = cost;
            BookRepoMockClass.Setup(x => x.AddCost(id, cost)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);
            //Act
            IHttpActionResult result = booksController.Put(id, cost);
            var resultBooks = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(resultBooks.Content.Cost.Price, 220);
        }

        [TestMethod]
        public void testBooksSearchBook()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", PublicationYear=2011,IsAvailable=true, AuthorId=1, Created=DateTime.Now },
                new Book{Id=2,  Title="Cast away", PublicationYear=1968, IsAvailable=true, AuthorId=1, Created=DateTime.Now }
            };

            BookRepoMockClass.Setup(x => x.GetBooksByTitle("nonai")).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.SearchBook("nonai");
            var resultBook = result as OkNegotiatedContentResult<List<Book>>;

            //Assert
            Assert.AreEqual(resultBook.Content[0].Title, "Nonai");
            Assert.AreEqual(resultBook.Content[1].Id, 2);

        }

    }
}
