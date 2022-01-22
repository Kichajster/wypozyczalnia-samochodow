using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    public class Samochod
    {
        public int Id { get; set; } 
        public string Marka { get; set; }
        public string Segment { get; set; }
        public string RodzajPaliwa { get; set; }
        public int Cena { get; set; }
        public bool CzyDostepny { get; set; }
    }
}
