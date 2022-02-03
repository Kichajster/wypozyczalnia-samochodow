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

            for (int i = 0; i < AllClients.Count; i++)
            {
                Console.WriteLine(AllClients[i].Id + " | " + AllClients[i].FullName + " | " + AllClients[i].LicenceDate.ToShortDateString());
            }
        }




    }
}
