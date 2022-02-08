using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    class CarRental
    {
        public List<Cars> AllCars = new List<Cars>();
        public List<Clients> AllClients = new List<Clients>();

        public CarRental()
        {
            string path = Directory.GetCurrentDirectory() + "\\clients.json";
            string content = File.ReadAllText(path);
            AllClients = JsonConvert.DeserializeObject<List<Clients>>(content);

            path = Directory.GetCurrentDirectory() + "\\cars.json";
            content = File.ReadAllText(path);
            AllCars = JsonConvert.DeserializeObject<List<Cars>>(content);
        }


       
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
    }
}
