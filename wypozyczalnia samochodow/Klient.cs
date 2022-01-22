using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public DateTime Data { get; set; } 
        public int Dzien { get; set; }
        public int Miesiac { get; set; }
        public int Rok { get; set; }

    }
}
