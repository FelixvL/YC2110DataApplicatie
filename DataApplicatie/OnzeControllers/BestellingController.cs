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
        public DbSet<Bestelling> Get()
        {
       //     Bestelling b = _db.bestellingen.First<Bestelling>();
         //   Debug.WriteLine("=================");
          //  Debug.WriteLine(b.BesteldeProducten.Count());
            //            _db.besteldeProducten.Where<BesteldeProducten>(t => t.ProductId == );
            return _db.bestellingen;
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
    }
        
}
