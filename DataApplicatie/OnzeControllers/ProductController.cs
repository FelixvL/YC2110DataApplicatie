using DBLaag;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApplicatie.OnzeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase

    {
        private DatabaseToegang _db; //verbinding met database wordt hier gedaan.
        public ProductController(DatabaseToegang db)
        {
            _db = db;
        }

        //---------------------------------------------------------------------------
        //TEST
        [HttpGet("multiplier/{num1}/{num2}")]
        public int Welcome(int num1, int num2)
        {
            int result = num1 * num2;

            return result;
        }
        //---------------------------------------------------------------------------


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product hetProduct = _db.producten.Where(c => c.Id == id).FirstOrDefault();
            return hetProduct;
        }

        // POST api/<ValuesController>
        [EnableCors("AllowOrigin")]
        [HttpPost("nieuwproduct")]
        public void Post([FromBody] Product hetproduct)
        {
            _db.Add(hetproduct);
            _db.SaveChanges();
        }

        // GET: api/<BestellingController>
        [EnableCors("AllowOrigin")]
        [HttpGet("alleProducten")]
        public DbSet<Product> GetProducts()
        {
            return _db.producten;
        }

        [EnableCors("AllowOrigin")]
        [HttpDelete("verwijderProduct/{Id}")]
        public void DeleteProduct(int Id)
        {
            Product product = _db.producten.Find(Id);
            Debug.WriteLine("verwijderd " + Id);
            _db.Remove(product);
            _db.SaveChanges();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
