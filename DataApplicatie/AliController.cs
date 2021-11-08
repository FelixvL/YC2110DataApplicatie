using DBLaag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //-----------------------------------------------------------------------------------------------//

        
        //----------------------------------------------------------------------------------------------//

        // POST api/<BestellingController>
        [HttpPost("voegProductToe")]
        public void Post([FromBody] Product product)
        {
            Debug.WriteLine(product);
            Debug.WriteLine(product.Naam);

            Debug.WriteLine("Ja aangekomen");
            _db.Add(product);
            _db.SaveChanges();
            
        }
        //----------------------------------------------------------------------------------------------//
        // DELETE api/<BestellingController>
        [HttpDelete("verwijderProduct/{Id}")]
        public void DeleteProduct(int Id)
        {
            Product product = _db.producten.Find(Id);
            Debug.WriteLine("verwijderd " + Id);
            _db.Remove(product);
            _db.SaveChanges();
        }

        //----------------------------------------------------------------------------------------------//

        // GET: api/<BestellingController>
        [HttpGet("alleProducten")]
        public DbSet<Product> GetProducts()
        {
            return _db.producten;
        }

        //----------------------------------------------------------------------------------------------//
        // GET: api/<BestellingController>
        [HttpGet("filterProducten")]
        public List<Product> FilterProducts()
        {
            var producten = _db.producten
                    .Where(p => p.Prijs >= 100).ToList(); //where laat zien waar je zoekt.
                     //find alle eerste resultaat of een default geven

            return producten;
        }

        

        //----------------------------------------------------------------------------------------------//




        // GET api/<PersoonController>/5
        [HttpGet("Product1/{denaam}")] //link 
        public Product SaveNaam(string denaam)
        {
            Product product1 = new Product();
            product1.Naam = denaam;

            _db.Add(product1);
            _db.SaveChanges();

            return product1; //wat return ik hier? is het niet alleen save?

        }


        [HttpGet("LijstProducten")]
        public DbSet<Product> namenVerkrijgen()
        {
            return _db.producten;
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
