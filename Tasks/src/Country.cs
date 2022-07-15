using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.src
{
    internal class Country
    {
        public CountryName Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public float[] Latlng { get; set; }
        public float Area { get; set; }
        public int Population { get; set; }
    }
}
