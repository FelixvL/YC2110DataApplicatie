using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLaag
{
    public class DatabaseToegang : DbContext
    {
        public DatabaseToegang(DbContextOptions options) : base(options) { }
        public DbSet<Product> producten { get; set; }
        public DbSet<Bestelling> bestellingen { get; set; }
    }
}
