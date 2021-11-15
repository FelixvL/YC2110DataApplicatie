using System;
using System.Collections.Generic;
using System.Text;

namespace DBLaag
{
    public class BesteldeProducten
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int aantalVanHetProduct { get; set; }
    }
}
