using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Repository.Interfaces
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Delete(int id);
        IQueryable<Book> GetAll();
        Book Read(int id);
        void Update(Book book);
    }
}
