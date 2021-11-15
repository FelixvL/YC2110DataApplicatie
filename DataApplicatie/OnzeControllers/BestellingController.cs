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

        [HttpGet("alleBestellingen")]
        public DbSet<Bestelling> Get()
        {
            return _db.bestellingen;
        }
        [HttpGet("alleBesteldeProducten")]
        public DbSet<BesteldeProducten> alleBesteldeProducten()
        {
            foreach (BesteldeProducten bp in _db.besteldeProducten) {
                Debug.WriteLine( bp.ProductId );
                Debug.WriteLine(">>");
            }
            return _db.besteldeProducten;
        }
        [HttpGet("{id}")]
        public Bestelling Get(int id)
        {
            Bestelling deBestelling = _db.bestellingen.Where(c => c.Id == id).FirstOrDefault();
            return deBestelling;
        }
        [HttpGet("voegProductToeAanBesteldeProducten/{productId}")]
        public string voegProductToeAanBestelling(int productId, int bestellingId)
        {
            Debug.WriteLine("Er is een product aan toegevoegd");
            Debug.WriteLine(productId +"><"+bestellingId);
            Bestelling deBestelling = _db.bestellingen.Where(c => c.Id == bestellingId).FirstOrDefault();
            Product hetProduct = _db.producten.Where(p => p.Id == productId).FirstOrDefault();
            BesteldeProducten besteldeProducten = new BesteldeProducten();
            _db.Add(besteldeProducten);
            besteldeProducten.Product = hetProduct;
            _db.SaveChanges();
            return "yes";
        }
    }
}
