using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wypozyczalnia_samochodow
{
    class Program
    {
        static void Main(string[] args)

            //sprawdzam czy wyswietla dobrze listy
        {
            string path = Directory.GetCurrentDirectory() + "\\Samochody.json";
            string content = File.ReadAllText(path);
            List<Samochod> WszystkieSamochody = JsonConvert.DeserializeObject<List<Samochod>>(content);

            for (int i = 0; i < WszystkieSamochody.Count; i++)
            {
                Console.WriteLine(WszystkieSamochody[i].Marka);
            }
             
            path = Directory.GetCurrentDirectory() + "\\Klienci.json";
            content = File.ReadAllText(path);
            List<Klient> WszyscyKlienci = JsonConvert.DeserializeObject<List<Klient>>(content);

            for (int i = 0; i < WszyscyKlienci.Count; i++)
            {
                Console.WriteLine(WszyscyKlienci[i].Imie);
            }
            
        }
    }
}



