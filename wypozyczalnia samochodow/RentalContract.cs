using System;

namespace wypozyczalnia_samochodow
{
    public class RentalContract
    {
        public RentalContract(Clients clients, Cars cars, DateTime agreementDate, DateTime returnDate, double totalCost)
        {
            Clients = clients;
            Cars = cars;
            AgreementDate = agreementDate;
            ReturnDate = returnDate;
            TotalCost = totalCost;
        }

        public Clients Clients;
        public Cars Cars;
        public DateTime AgreementDate;
        public DateTime ReturnDate;
        public double TotalCost;
    }
}
