using HT6POQ_HFT_2021222.Logic.Interfaces;
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

        // GET api/<StatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
