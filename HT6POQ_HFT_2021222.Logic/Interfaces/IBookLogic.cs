using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Logic.Interfaces
{
    public interface IBookLogic
    {
        void create(Book book);
        Book Read(int id);
        void Delete(int id);
        void Update(Book car);

        public double AVGPricesX();
        IEnumerable<Book> GetAll();
        IEnumerable<Book> ExpensiveCarSellerS();
        IEnumerable<Book> MostExpensiveCarSeller();
        public IEnumerable<Book> LeastExpensiveCarSeller();
        public IEnumerable<KeyValuePair<string, double>> AveragePrice();
        public IEnumerable<KeyValuePair<string, int>> MostExpensiveCarPricesByBrands();
        int SumPicesOfCars();
        public IEnumerable<Book> AverageCarSellers();
    }
}
