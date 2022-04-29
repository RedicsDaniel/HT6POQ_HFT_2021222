using HT6POQ_HFT_2021222.Logic.Interfaces;
using HT6POQ_HTF_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HT6POQ_HFT_2021222_endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAuthorLogic al;
        IShopLogic sl;
        IBookLogic bl;
        public StatController(IAuthorLogic Al, IShopLogic Sl, IBookLogic Bl)
        {
            this.al = Al;
            this.sl = Sl;
            this.bl = Bl;
        }

        // GET: api/<StatController>
        [HttpGet]
        public double AVGPricesOfBooks()
        {
            return bl.AVGPricesOfBooks();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> AverageBookPriceByShops()
        {
            return bl.AverageBookPriceByShops();
        }

        [HttpGet]
        public IEnumerable<Author> AveragePricedAuthors()
        {
            return bl.AveragePricedAuthor();
        }
        [HttpGet]
        public IEnumerable<Shop> ExpensiveBookStores()
        {
            return bl.ExpensiveBookStores();
        }

        [HttpGet]
        public IEnumerable<Shop> MostExpensiveBookStore()
        {
            return bl.MostExpensiveBookStore();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string,int>> MostExpensiveBooksByStores()
        {
            return bl.MostExpensiveBooksByStores();
        }
        [HttpGet]
        public IEnumerable<Shop> LeastExpensiveBookStore()
        {
            return bl.LeastExpensiveBookStore();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> LeastExpensiveBooksByStores()
        {
            return bl.LeastExpensiveBooksByStores();
        }
        [HttpGet]
        public IEnumerable<string> AuthorWithMostBook()
        {
            return al.AuthorWithMostBook();
        }
    }
}
