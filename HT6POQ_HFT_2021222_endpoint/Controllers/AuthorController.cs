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
    public class AuthorController : ControllerBase
    {
        IAuthorLogic logic;

        public AuthorController(IAuthorLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> GetAll()
        {
            return this.logic.GetAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.logic.Create(value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Update( [FromBody] Author value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
