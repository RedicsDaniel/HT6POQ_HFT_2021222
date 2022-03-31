using HT6POQ_HFT_2021222.Repository.Data;
using HT6POQ_HFT_2021222.Repository.Interfaces;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        BookDbContext db;
        public BookRepository(BookDbContext DB)
        {
            this.db = DB;
        }
        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var BookToDelete = Read(id);
            db.Books.Remove(BookToDelete);
            db.SaveChanges();
        }

        public IQueryable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Read(int id)
        {
            return db.Books.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Book book)
        {
            var NewBook = Read(book.Id);
            NewBook.Title = book.Title;
            NewBook.PageNumber = book.PageNumber;
            NewBook.Shop = book.Shop;
            NewBook.ShopId = book.ShopId;
            NewBook.Author = book.Author;
            NewBook.AuthorId = book.AuthorId;
            NewBook.Type = book.Type;
            db.SaveChanges();
        }
    }
}
