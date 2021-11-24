using DBLaag;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public List<Bestelling> Get()
        {
            List<Bestelling> bestellingen = _db.bestellingen.ToList();// alle bestellingen
            List<Bestelling> returnList = new List<Bestelling>();  // lege lijst
            for (int x = 0; x <  bestellingen.Count(); x++) {
                Bestelling bestelling = new Bestelling();   // verse kopie
                bestelling.BesteldeProducten = new List<BesteldeProducten>(); // in die kopie maak ik een lege lijst aan
                List<BesteldeProducten> productenVanBestelling = _db.besteldeProducten.Where(c => c.BestellingId == bestellingen.ElementAt(x).Id).ToList();
                for (int y = 0; y < productenVanBestelling.Count(); y++) {
                    Product p = new Product();
                    Product tempP = _db.producten.Where(t => t.Id == productenVanBestelling.ElementAt(y).ProductId).First();
                    p.Naam = tempP.Naam;
                    p.Fotonaam = tempP.Fotonaam;
                    productenVanBestelling.ElementAt(y).Product = p;
           //         productenVanBestelling.ElementAt(y).Product = _db.producten.Where(t => t.Id == productenVanBestelling.ElementAt(y).ProductId).First();
                }
                BesteldeProducten bp = new BesteldeProducten();
                bestelling.BesteldeProducten = productenVanBestelling.ToList();

                returnList.Add(bestelling);
            }
    
            return bestellingen;
        }
        [HttpGet("alleBesteldeProducten")]
        public DbSet<BesteldeProducten> alleBesteldeProducten()
        {
            foreach (BesteldeProducten bp in _db.besteldeProducten)
            {
                Debug.WriteLine(bp.ProductId);
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
        [HttpGet("test")]
        public string GetA(int id)
        {
            return "hoi";
        }
        [HttpGet("voegProductToeAanBesteldeProducten/{productId}")]
        public int voegProductToeAanBestelling(int productId)
        {
            Product hetProduct = _db.producten.Where(p => p.Id == productId).FirstOrDefault();
            BesteldeProducten besteldeProducten = new BesteldeProducten();
            EntityEntry<BesteldeProducten> bp = _db.Add(besteldeProducten);
            besteldeProducten.Product = hetProduct;

            _db.SaveChanges();
            return bp.Entity.Id;
        }
        [EnableCors("AllowOrigin")]
        [HttpGet("voegBestellingToe")]
        public int voegBestellingToe()
        {
            Bestelling bestelling = new Bestelling();
            //            bestelling.BesteldeProducten = (DbSet<BesteldeProducten>)new List<BesteldeProducten>();
            Bestelling terug = _db.Add(bestelling).Entity;
            //            Debug.WriteLine(terug.Id);
            //            Product product = _db.producten.Where<Product>(x=>x.Id == Int32.Parse(dejson[0])).FirstOrDefault();
            //            BesteldeProducten bp = new BesteldeProducten();
            //            BesteldeProducten bpb = _db.Add(bp).Entity;

            //     terug.BesteldeProducten.Add(bpb);

            _db.SaveChanges();
            return terug.Id;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("voegBestellingToe/{klantnaam}")]
        public string voegKlantAanBestelling(string klantnaam)
        {
            Bestelling bestelling = new Bestelling();
            bestelling.KlantNaam = klantnaam;
         
            _db.Add(bestelling);
            Debug.WriteLine(bestelling.KlantNaam);
            _db.SaveChanges();


            return "naam toegevoegd van voegKlantToe";
        }




        [EnableCors("AllowOrigin")]
        [HttpGet("voegProductToeAanBestelling/{bestelid}/{productid}")]
        public int voegProductToeAanBestelling(int bestelid, int productid)
        {
            Debug.WriteLine(bestelid + "<<besteldid");
            Debug.WriteLine(productid + "<<productid");
            BesteldeProducten bp = new BesteldeProducten();
            bp.BestellingId = bestelid;
            bp.ProductId = productid;
            _db.Add(bp);
            _db.SaveChanges();
            return 7;
        }
        [HttpGet("verwijderbestelling/{bestelid}")]
        public int verwijderbestelling(int bestelid)
        {
            Bestelling teverwijderen = _db.bestellingen.Where(u => u.Id == bestelid).First();
            _db.bestellingen.Remove(teverwijderen);
            _db.SaveChanges();
            return 7;
        }
    }
        
}
