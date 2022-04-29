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
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopLogic logic;

        public ShopController(IShopLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<ShopController>
        [HttpGet]
        public IEnumerable<Shop> GetAll()
        {
            return this.logic.GetAll();
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public Shop Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<ShopController>
        [HttpPost]
        public void Post([FromBody] Shop value)
        {
            this.logic.Create(value);
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Shop value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
