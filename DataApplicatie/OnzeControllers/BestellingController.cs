using DBLaag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApplicatie.OnzeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        private DatabaseToegang _db; //verbinding met database wordt hier gedaan.
        public BestellingController(DatabaseToegang db)
        {
            _db = db;
        }
        // GET: api/<BestellingController>
        [HttpGet("alleBestellingen")]
        public DbSet<Bestelling> Get()
        {
            return _db.bestellingen;
        }


        // GET api/<BestellingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BestellingController>
        [HttpPost("voegBestellingToe")]
        public void Post([FromBody] Bestelling bestelling)
        {
            Debug.WriteLine(bestelling.KlantNaam);
            Debug.WriteLine("Ja aangekomen");
        }

        // PUT api/<BestellingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BestellingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
