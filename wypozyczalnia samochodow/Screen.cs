using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    public static class Screen
    {
        
        public static void ShowMenu()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA KLIENTÓW I SAMOCHODÓW");
            Console.WriteLine("2 => WYPOŻYCZENIE SAMOCHODU");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");
        }//pokaż menu

        public static int MenuOption()
        {
            ShowMenu();
            string option = Console.ReadLine();
            List<string> Response = new List<string> { "1", "2", "3" };
            
            while (!Response.Contains(option))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wybrałeś niepoprawną opcję!");
                Console.ForegroundColor = ConsoleColor.White;
                ShowMenu();
                option = Console.ReadLine();

            }
            return int.Parse(option);


        } //menu opcji

        public static void ShowClients(List<Clients> AllClients)
        {
            Console.WriteLine("LISTA KLIENTÓW:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Id | Imię i Nazwisko | Data wydania prawa jazdy");

            for (int i = 0; i < AllClients.Count; i++)
            {
                Console.WriteLine(AllClients[i].Id + " | " + AllClients[i].FullName + " | " + AllClients[i].LicenceDate.ToShortDateString());
            }
        }//lista klientów
        public static void ShowCars(List<Cars> AllCars)
        {
            Console.WriteLine();
            Console.WriteLine("LISTA SAMOCHODÓW:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Id | Model | Segment | Rodzaj paliwa | Cena za dobę");

            for (int i = 0; i < AllCars.Count; i++)
            {
                Console.WriteLine(AllCars[i].Id + " | " + AllCars[i].Brand + " | " + AllCars[i].Segment + " | " + AllCars[i].FuelType + " | " + AllCars[i].Price);
            }
        }//lista samochodów

        public static void ShowAll(List<Clients> AllClients, List<Cars> AllCars)
        {
            Console.Clear();
            ShowClients(AllClients);
            ShowCars(AllCars);
        }//pokaż liste klientów i samochodów

        public static string ClientID(bool FirstTimeAsking)
        {
            Console.Clear();
            if (!FirstTimeAsking)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NIE ZNALEZIONO KLIENTA O PODANYM ID");
                Console.ForegroundColor = ConsoleColor.White;
            }
                Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD:");
                string option = Console.ReadLine();
                return option;
        }
        public static string GetItemFromList(List<string> Items)
        {
            bool FirstTimeAsking = true;
            while (true)
            {
                Console.Clear();
                if (!FirstTimeAsking)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEPOPRAWNY WYBÓR");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                FirstTimeAsking = false;
                Console.WriteLine("WYBIERZ SEGMENT:");
                for(int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Items[i]);
                }
                string response = Console.ReadLine();
                int Parsed;
                if (int.TryParse(response, out Parsed))
                {
                    if (Parsed >= 1 && Parsed <= Items.Count)
                        return Items[Parsed - 1];
                }
            }
        }

    }
}
