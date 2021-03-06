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
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;

        public BookController(IBookLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return this.logic.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.create(value);

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Update( [FromBody] Book value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
