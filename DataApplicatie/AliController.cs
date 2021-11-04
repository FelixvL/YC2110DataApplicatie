using DBLaag;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApplicatie
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliController : ControllerBase
    {
        private DatabaseToegang _db; //verbinding met database wordt hier gedaan.
        public AliController(DatabaseToegang db)
        {
            _db = db;
        }

        // GET: api/<AliController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AliController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<AliController>/5
        [HttpGet("Ali/{id}")]
        public string AliGet(int id)
        {
            Product product1 = new Product();

            product1.Naam = "Energydrank";
            product1.Prijs = id;
            _db.Add(product1);
            _db.SaveChanges();
            return "value";
        }

        // POST api/<AliController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AliController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AliController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
