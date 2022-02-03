using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    public class Screen
    {

        public static void ShowMenu()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA KLIENTÓW I SAMOCHODÓW");
            Console.WriteLine("2 => WYPOŻYCZENIE SAMOCHODU");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");
            Console.ReadLine();
        }

        public static void ShowClients()
        {
            string path = Directory.GetCurrentDirectory() + "\\clients.json";
            string content = File.ReadAllText(path);
            List<Clients> AllClients = JsonConvert.DeserializeObject<List<Clients>>(content);

            Console.WriteLine("LISTA KLIENTÓW:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Id | Imię i Nazwisko | Data wydania prawa jazdy");

            for (int i = 0; i < AllClients.Count; i++)
            {
                Console.WriteLine(AllClients[i].Id + " | " + AllClients[i].FullName + " | " + AllClients[i].LicenceDate.ToShortDateString());
            }
        }
        public static void ShowCars()
        {
            string path = Directory.GetCurrentDirectory() + "\\cars.json";
            string content = File.ReadAllText(path);
            List<Cars> AllCars = JsonConvert.DeserializeObject<List<Cars>>(content);

            Console.WriteLine();
            Console.WriteLine("LISTA SAMOCHODÓW:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Id | Model | Segment | Rodzaj paliwa | Cena za dobę");

            for (int i = 0; i < AllCars.Count; i++)
            {
                Console.WriteLine(AllCars[i].Id + " | " + AllCars[i].Brand + " | " + AllCars[i].Segment + " | " + AllCars[i].FuelType + " | " + AllCars[i].Price);
            }
        }



    }
}
