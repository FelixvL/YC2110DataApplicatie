using System;
using System.Collections.Generic;
using System.Text;

namespace DBLaag
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public string Specificaties { get; set; }
        public string Fotonaam { get; set; }
        public int Discount { get; set; }
        public BesteldeProducten BesteldeProduct { get; set; }
    }
}
