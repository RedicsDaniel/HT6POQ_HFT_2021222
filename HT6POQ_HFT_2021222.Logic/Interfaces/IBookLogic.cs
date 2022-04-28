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
        void Update(Book book);

        public double AVGPricesOfBooks();
        IEnumerable<Book> GetAll();
        IEnumerable<Shop> ExpensiveBookStores();
        IEnumerable<Shop> MostExpensiveBookStore();
        public IEnumerable<Shop> LeastExpensiveBookStore();
        public IEnumerable<KeyValuePair<string, double>> AverageBookPriceByShops();
        public IEnumerable<KeyValuePair<string, int>> MostExpensiveBooksByStores();
        public IEnumerable<KeyValuePair<string, int>> LeastExpensiveBooksByStores();
        int SumPricesOfBooks();
        public IEnumerable<Author> AveragePricedAuthor();
    }
}
