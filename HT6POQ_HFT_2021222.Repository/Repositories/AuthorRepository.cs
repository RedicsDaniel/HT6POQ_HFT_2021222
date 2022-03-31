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
    public class AuthorRepository : IAuthorRepository
    {
        BookDbContext db;
        public AuthorRepository(BookDbContext DB)
        {
            this.db = DB;
        }
        public void Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var AuthorToDelete = Read(id);
            db.Authors.Remove(AuthorToDelete);
            db.SaveChanges();
        }

        public IQueryable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Read(int id)
        {
            return db.Authors.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Author author)
        {
            var NewAuthor = Read(author.Id);
            NewAuthor.Name = author.Name;
            NewAuthor.Nationality = author.Nationality;
            NewAuthor.NumberOfBooks = author.NumberOfBooks;
            db.SaveChanges();


        }
    }
}
