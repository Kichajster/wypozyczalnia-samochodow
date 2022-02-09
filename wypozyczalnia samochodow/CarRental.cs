using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace wypozyczalnia_samochodow
{
    class CarRental
    {
        public List<Cars> AllCars = new List<Cars>();
        public List<Clients> AllClients = new List<Clients>();

        //wczytywanie listy
        public CarRental()
        {
            string path = Directory.GetCurrentDirectory() + "\\clients.json";
            string content = File.ReadAllText(path);
            AllClients = JsonConvert.DeserializeObject<List<Clients>>(content);

            path = Directory.GetCurrentDirectory() + "\\cars.json";
            content = File.ReadAllText(path);
            AllCars = JsonConvert.DeserializeObject<List<Cars>>(content);
        }
       
        //pobieranie klienta po ID
        public Clients GetClientByID(String StrID)
        {
            int IntID;
            if (!int.TryParse(StrID, out IntID))
                return null;
            for (int i = 0; i < AllClients.Count; i++)
                if (AllClients[i].Id == IntID)
                    return AllClients[i];
            return null;
        }
        //tworzenie listy segmentu na podstawie klienta
        public List<string> GetSegmentListByClient(Clients client)
        {
            int difference = DateTime.Now.Year - client.LicenceDate.Year;
            List<string> segments = new List<string>();
            segments.Add("mini");
            segments.Add("kompakt");
            if (difference >= 4)
                segments.Add("premium");
            return segments;
        }
        //tworzenie listy typów paliw
        public List<string> GetFuelTypes()
        {
            List<string> FuelTypes = new List<string>();
            FuelTypes.Add("benzyna");
            FuelTypes.Add("elektryczny");
            FuelTypes.Add("diesel");
            return FuelTypes;
        }
        //tworzenie kontraktu
        public RentalContract GetRentalAgreement(Clients c, string segment, string fuelType, int daysCount)
        {
            List<Cars> AvailableCars = AllCars.Where(s => s.Segment == segment)
                .Where(s => s.FuelType == fuelType)
                .Where(s => s.isAvailable).ToList();
            if (AvailableCars.Count == 0)
            {
                return null;
            }
            Cars carToRent = AvailableCars.First();
            carToRent.isAvailable = false;
            int paidDays = daysCount;
            if (daysCount > 30)
            {
                paidDays -= 3;
            }
            else if (daysCount > 7)
            {
                paidDays -= 1;
            }

            double TotalCost = paidDays * carToRent.Price;

            int difference = DateTime.Now.Year - c.LicenceDate.Year;
            if (difference < 4)
            {
                TotalCost *= 1.2;
            }

            DateTime rentUntil = DateTime.Now.AddDays(daysCount);

            return new RentalContract(c, carToRent, DateTime.Now, rentUntil, TotalCost);

        }
    }
}
