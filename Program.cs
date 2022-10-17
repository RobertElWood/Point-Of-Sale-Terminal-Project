using PointOfSale;

namespace Point_of_Sale_Terminal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Retro Boys Gaming and accessories here's what we have avaliable");
            POS storeVisit = new POS();
            storeVisit.PrintInventory();
            storeVisit.Purchase();
            storeVisit.ChoosePaymentMethod();


        }
    }
}