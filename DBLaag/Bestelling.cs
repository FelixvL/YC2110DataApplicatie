using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLaag
{
    public class Bestelling
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }
        public string KlantNaam { get; set; }
        public DbSet<BesteldeProducten> BesteldeProducten { get; set; }
    }
}
