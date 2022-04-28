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
    public class BookLogic : IBookLogic
    {
        IBookRepository br;

        public BookLogic(IBookRepository br)
        {
            this.br = br;
        }

        public IEnumerable<Book> AverageCarSellers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, double>> AveragePrice()
        {
            throw new NotImplementedException();
        }

        public double AVGPricesX()
        {
            throw new NotImplementedException();
        }

        public void create(Book book)
        {
            if (book == null || book.Title =="")
            {
                throw new ArgumentException("Cant create!");
            }
            br.Create(book);
        }

        public void Delete(int id)
        {
            br.Delete(id);
        }

        public IEnumerable<Book> ExpensiveCarSellerS()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            return br.GetAll();
        }

        public IEnumerable<Book> LeastExpensiveCarSeller()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, int>> MostExpensiveCarPricesByBrands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> MostExpensiveCarSeller()
        {
            throw new NotImplementedException();
        }

        public Book Read(int id)
        {
            return br.Read(id);
        }

        public int SumPicesOfCars()
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            br.Update(book);
        }
    }
}
