using PointOfSale;

namespace Point_of_Sale_Terminal
{
    public class Program
    {

        static void Main(string[] args)
        {


            bool runAgain = true;
            POS storeVisit = new POS();
            string greeting1 = "Welcome to Retro Boys Gaming";
            string greeting2 = "Have a look at our products below!\n";
            Console.SetCursorPosition((Console.WindowWidth - greeting1.Length) / 2, Console.CursorTop);
            Console.WriteLine(greeting1);

            while (runAgain)
            {

                Console.SetCursorPosition((Console.WindowWidth - greeting2.Length) / 2, Console.CursorTop);
                Console.WriteLine(greeting2);

                storeVisit.PrintInventory();
                Console.WriteLine();
                storeVisit.Purchase();
                Console.WriteLine();
                runAgain = AskToContinue();
            }
            storeVisit.ChoosePaymentMethod();
        }


        public static bool AskToContinue()
        {
            Console.WriteLine("YOU WANT MORE MOTHERFUCKA?! y/n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine("THAT'S CORRECT MOTHAFUCKA!");
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Have a nice day! MOTHAFUCKA!");
                return false;
            }
            else
            {
                Console.WriteLine("WHAT? MOTHAFUCKA!?");
                return AskToContinue();
            }
        }

    }
}