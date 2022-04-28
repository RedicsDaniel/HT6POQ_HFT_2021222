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

        public IEnumerable<Author> AveragePricedAuthor()
        {
            return from x in br.GetAll()
                   where x.Price > 900 && x.Price < 2000
                   select x.Author;
        }

        public IEnumerable<KeyValuePair<string, double>> AverageBookPriceByShops()
        {
            return from x in br.GetAll()
                   group x by x.Shop.Name into grp
                   select new KeyValuePair<string, double>
                   (grp.Key, grp.Average(s => s.Price));
        }

        public double AVGPricesOfBooks()
        {
            return br.GetAll().Average(b => b.Price);
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

        public IEnumerable<Shop> ExpensiveBookStores()
        {
            return from x in br.GetAll()
                   where x.Price > 1000
                   select x.Shop;
        }

        public IEnumerable<Book> GetAll()
        {
            return br.GetAll();
        }

        public IEnumerable<Shop> MostExpensiveBookStore()
        {
            return (from x in br.GetAll()
                    orderby x.Price descending
                    select x.Shop).Take(1);
        }

        public IEnumerable<KeyValuePair<string, int>> MostExpensiveBooksByStores()
        {
            return from x in br.GetAll()
                   group x by x.Shop.Name into grp
                   select new KeyValuePair<string, int>
                   (grp.Key, grp.Max(b => b.Price));
        }

        public IEnumerable<Shop> LeastExpensiveBookStore()
        {
            return (from x in br.GetAll()
                    orderby x.Price
                    select x.Shop).Take(1);
        }

        public Book Read(int id)
        {
            return br.Read(id);
        }

        public int SumPricesOfBooks()
        {
            return br.GetAll().Sum(b => b.Price);
        }

        public void Update(Book book)
        {
            br.Update(book);
        }

        public IEnumerable<KeyValuePair<string, int>> LeastExpensiveBooksByStores()
        {
            return from x in br.GetAll()
                   group x by x.Shop.Name into grp
                   select new KeyValuePair<string, int>
                   (grp.Key, grp.Min(b => b.Price));
        }
    }
}
