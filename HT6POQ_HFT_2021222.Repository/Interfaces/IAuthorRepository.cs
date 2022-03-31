using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Delete(int id);
        IQueryable<Author> GetAll();
        Author Read(int id);
        void Update(Author author);
    }
}
