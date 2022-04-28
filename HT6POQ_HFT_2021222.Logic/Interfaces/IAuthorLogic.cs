using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Logic.Interfaces
{
    public interface IAuthorLogic
    {
        void Create(Author brand);
        Author Read(int id);
        void Delete(int id);
        void Update(Author brand);
        IEnumerable<Author> GetAll();
        IEnumerable<string> BrandWithMostCar();
    }
}
