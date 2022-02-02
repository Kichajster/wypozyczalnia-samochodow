using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia_samochodow
{
    internal class Screen
    {
        static void Main(string[] args)
        {
            Screen.MainMenu();
            Rental rental = new Rental();
            while (true)
            {
                rental.menu();
                if (odp == 1)
                {
                    ConsoleWrite(List<Clients>);
                    ConsoleWrite(List<Cars>);
                    return;
                }
                else if (odp == 2)
                {
                    Screen.RentMenu();
                }
                else
                {
                Screen.end;
                return;
                }
            }
        }
    }
}
