using HT6POQ_HFT_2021222.Logic.Logics;
using HT6POQ_HFT_2021222.Repository.Interfaces;
using HT6POQ_HTF_2021222.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Test
{
    [TestFixture]
    class Tester
    {
        Mock<IAuthorRepository> mockAuthorRepo;
        Mock<IShopRepository> mockShopRepo;
        Mock<IBookRepository> mockBookRepo;
        AuthorLogic authorLogic;
        ShopLogic shopLogic;
        BookLogic bookLogic;
        [SetUp]
        public void Init()
        {
            mockAuthorRepo = new Mock<IAuthorRepository>();
            mockShopRepo = new Mock<IShopRepository>();
            mockBookRepo = new Mock<IBookRepository>();
            Author a1 = new Author() { Id = 1, Age = 20, Name = "Aaron Ramsey", Nationality = "cseh", NumberOfBooks = 2 };
            Author a2 = new Author() { Id = 2, Age = 30, Name = "Peter Wright", Nationality = "lengyel", NumberOfBooks = 3 };
            Author a3 = new Author() { Id = 3, Age = 40, Name = "Lindsey Lohan", Nationality = "amerikai", NumberOfBooks = 5 };
            List<Author> authors = new List<Author>() { a1, a2, a3 };

            Shop s1 = new Shop() { Id = 1, Name = "Boulvar", Location = "Budapest" };
            Shop s2 = new Shop() { Id = 2, Name = "Paul Street", Location = "London" };
            Shop s3 = new Shop() { Id = 3, Name = "Elm Street", Location = "Bukarest" };
            List<Shop> shops = new List<Shop> { s1, s2, s3 };

            Book b1 = new Book() { Id = 1, Title = "Halott város", PageNumber = 300, Type = BookType.Horror, AuthorId = 2, ShopId = s1.Id, Price = 500 };
            Book b2 = new Book() { Id = 2, Title = "Ego hatalma", PageNumber = 340, Type = BookType.Classic, AuthorId = 3, ShopId = s2.Id, Price = 1500 };
            Book b3 = new Book() { Id = 3, Title = "Ember a Holdon", PageNumber = 100, Type = BookType.Comic, AuthorId = 1, ShopId = s3.Id, Price = 2500 };
            Book b4 = new Book() { Id = 4, Title = "Sherlock Holmes", PageNumber = 500, Type = BookType.Detective, AuthorId = 2, ShopId = s3.Id, Price = 5500 };
            Book b5 = new Book() { Id = 5, Title = "Egy kutya 7 élete", PageNumber = 80, Type = BookType.Fantasy, AuthorId = 3, ShopId = s2.Id, Price = 10500 };
            List<Book> books = new List<Book> { b1, b2, b3, b4, b5 };

            mockAuthorRepo.Setup((t) => t.GetAll()).Returns(authors.AsQueryable());
            mockBookRepo.Setup((t) => t.GetAll()).Returns(books.AsQueryable());
            mockShopRepo.Setup((t) => t.GetAll()).Returns(shops.AsQueryable());

            bookLogic = new BookLogic(mockBookRepo.Object);
            shopLogic = new ShopLogic(mockShopRepo.Object);
            authorLogic = new AuthorLogic(mockAuthorRepo.Object);
        }
        [Test]
        public void SUM()
        {
            var res = bookLogic.SumPricesOfBooks();
            
            Assert.That(res, Is.EqualTo(20500));
        }
        [Test]
        public void 

    }
}
