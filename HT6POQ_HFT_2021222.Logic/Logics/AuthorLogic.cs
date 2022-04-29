using HT6POQ_HFT_2021222.Logic.Interfaces;
using HT6POQ_HFT_2021222.Repository.Interfaces;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Logic.Logics
{
    public class AuthorLogic : IAuthorLogic
    {
        IAuthorRepository ar;

        public AuthorLogic(IAuthorRepository ar)
        {
            this.ar = ar;
        }

        public IEnumerable<string> AuthorWithMostBook()
        {
            return ar.GetAll().OrderByDescending(x => x.Books.Count).Select(x => x.Name).Take(1);
        }

        public void Create(Author author)
        {
            if (author == null  || author.Name =="")
            {
                throw new ArgumentException("Cant create!");
            }
            ar.Create(author);
        }

        public void Delete(int id)
        {
            ar.Delete(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return ar.GetAll();
        }

        public Author Read(int id)
        {
            return ar.Read(id);
        }

        public void Update(Author author)
        {
            ar.Update(author);
        }
        
    }
}
