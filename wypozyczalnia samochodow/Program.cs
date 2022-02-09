

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
                    //określ clienta
                    Clients client = null;
                    bool firstTimeAsking = true;
                    while (client == null)
                    {
                        client = carRental.GetClientByID(Screen.ClientID(firstTimeAsking));
                        firstTimeAsking = false;
                    }
                    //określ segment
                    string Segment = Screen.GetItemFromList(carRental.GetSegmentListByClient(client), " SEGMENT");
                    //określ typ paliwa
                    string FuelType = Screen.GetItemFromList(carRental.GetFuelTypes(), "RODZAJ PALIWA");
                    //określ ilość dni wynajmu
                    int DaysCount = Screen.GetDaysCount();
                    //pokaż agreement
                    Screen.ShowAgreement(carRental.GetRentalAgreement(client, Segment, FuelType, DaysCount));

                }
                else
                {
                    return;
                }
                
            }



        }

    }
}