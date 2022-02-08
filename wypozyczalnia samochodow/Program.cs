using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace wypozyczalnia_samochodow
{
    internal class Program
    {

        static void Main(string[] args)
        {
           CarRental carRental = new CarRental();
           while (true)
            {
                int option = Screen.MenuOption();
                if (option == 1)
                {
                    Screen.ShowAll(carRental.AllClients, carRental.AllCars);
                }
                else if (option == 2)
                {
                    Clients client = null;
                    bool firstTimeAsking = true;
                    while (client == null)
                    {
                        client = carRental.GetClientByID(Screen.ClientID(firstTimeAsking));
                        firstTimeAsking = false;
                    }
                    string Segment = Screen.GetItemFromList(carRental.GetSegmentListByClient(client));
                }
                else
                {
                    return;
                }
                
            }



        }

    }
}