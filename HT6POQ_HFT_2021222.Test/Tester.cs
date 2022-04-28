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

            Book b1 = new Book() { Id = 1, Title = "Halott város", PageNumber = 300, Type = BookType.Horror, AuthorId = 2, ShopId = s1.Id, Price = 1000 ,Author =a1,Shop = s1};
            Book b2 = new Book() { Id = 2, Title = "Ego hatalma", PageNumber = 340, Type = BookType.Classic, AuthorId = 3, ShopId = s2.Id, Price = 2000,Author = a2 ,Shop = s2};
            Book b3 = new Book() { Id = 3, Title = "Ember a Holdon", PageNumber = 100, Type = BookType.Comic, AuthorId = 1, ShopId = s3.Id, Price = 2000,Author = a3,Shop = s3 };
            Book b4 = new Book() { Id = 4, Title = "Sherlock Holmes", PageNumber = 500, Type = BookType.Detective, AuthorId = 2, ShopId = s3.Id, Price = 5000 , Author = a3,Shop = s2};
            Book b5 = new Book() { Id = 5, Title = "Egy kutya 7 élete", PageNumber = 80, Type = BookType.Fantasy, AuthorId = 3, ShopId = s2.Id, Price = 8000,Author = a2,Shop = s2 };
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
            
            Assert.That(res, Is.EqualTo(18000));
        }
        [Test]
        public void AVGBPricedBookAuthors()
        {
            var res = bookLogic.AveragePricedAuthor();
            var exp = new List<Author>()
            { new Author
            {
                Name = "Aaron Ramsey"
            }
            };
            Assert.That(res.ToArray().FirstOrDefault().Name, Is.EqualTo(exp.ToArray().FirstOrDefault().Name));
            
        }
        [Test]
        public void LeastExpensiveBookStore()
        {
            var res = bookLogic.LeastExpensiveBookStore();
            var exp = new List<Shop>()
            { new Shop()
            {
                Name = "Boulvar",
                Location = "Budapest",
                Id = 1
            }
            };
            Assert.That(res.ToArray().FirstOrDefault().Name, Is.EqualTo(exp.ToArray().FirstOrDefault().Name));
            
        }
        [Test]
        public void MostExpensiveBookStore()
        {
            var res = bookLogic.MostExpensiveBookStore();
            ;
            var exp = new List<Shop>()
            { new Shop()
            {
                Name = "Paul Street",
                Location = "London",
                Id = 2
            }
            };
            Assert.That(res.ToArray().FirstOrDefault().Name, Is.EqualTo(exp.ToArray().FirstOrDefault().Name));
        }
        [Test]
        public void MostExpensiveBooksByStores()
        {
            var res = bookLogic.MostExpensiveBooksByStores();
            var exp = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Boulvar",1000),
                new KeyValuePair<string, int>("Paul Street",8000),
                new KeyValuePair<string, int>("Elm Street",2000)
            };
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void AverageBookPricesByShops()
        {
            var res = bookLogic.AverageBookPriceByShops();
            
            var exp = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Boulvar",1000),
                new KeyValuePair<string, double>("Paul Street",5000),
                new KeyValuePair<string, double>("Elm Street",2000)
            };
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void LeastExpensiveBOoksByStore()
        {
            var res = bookLogic.LeastExpensiveBooksByStores();
            
            var exp = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Boulvar",1000),
                new KeyValuePair<string, int>("Paul Street",2000),
                new KeyValuePair<string, int>("Elm Street",2000)
            };
            Assert.That(res, Is.EqualTo(exp));
        }
        public void 
        [Test]
        public void CreateFakeExistingBOok()
        {
            Book testBook = new Book() { Title = "XX", AuthorId = 1,Price = 5000,ShopId =1 };
            bookLogic.create(testBook);
            mockBookRepo.Verify(t => t.Create(It.IsAny<Book>()), Times.Once);

        }
        [Test]
        public void CreateFakeShop()
        {
            Assert.Throws<ArgumentException>(() => shopLogic.Create(null));
            mockShopRepo.Verify(t => t.Create(It.IsAny<Shop>()), Times.Never);
        }
        [Test]
        public void CreateFakeAuthor()
        {
            Author testauthor = new Author()
            {
                Age = 15,
                Id = 1,
                Name = "Josef"
            };
            authorLogic.Create(testauthor);
            mockAuthorRepo.Verify(t => t.Create(It.IsAny<Author>()), Times.Once);
        }

    }
}
