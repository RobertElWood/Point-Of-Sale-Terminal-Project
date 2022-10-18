using PointOfSale;

namespace Point_of_Sale_Terminal
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Bool to prompt Shopping Again loop
            bool shopAgain = true;
            //Bool to prompt asking to continue loop
            bool runAgain = true;
                   
            
            while (shopAgain)
            {
                //New instance of POS class
                POS storeVisit = new POS();
                //Top Console Greeting
                Logo Beauty = new Logo();

                //Main store visit loop
                while (runAgain)
                {
                    //Item List header
                    Beauty.Logo2();
                    
                    //Printing actual product inventory
                    storeVisit.PrintInventory();
                    Console.WriteLine();//Formatting
                   
                    //Calling Purchase method to inquire with the user what they'd like to purchase
                    storeVisit.Purchase();
                    Console.WriteLine();//Formatting
                   
                    //Prompt user to go again
                    runAgain = AskToContinue();
                }
                
                //Prompt user to select their pay type if they're done browsing
                storeVisit.ChoosePaymentMethod();
                storeVisit.PrintReciept();

                shopAgain = ShopAgain();
                runAgain = true;
            }
        }



        //Method to prompt user to continue
        public static bool AskToContinue()
        {
            Console.WriteLine("\nWould you like to purchase anything else? Y/N\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine("\nOkay, great!");
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nGreat, lets get you checked out!\n");
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't catch that.");
                return AskToContinue();
            }
        }

        //Method to prompt user if they want to shop again
        public static bool ShopAgain()
        {
            Console.WriteLine("\nWould you like to shop again? Y/N\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine("\nOkay, great!");
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThank you for shopping at Retro Boys, the only video game store endorsed by Samuel L. Jackson!");
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't catch that.");
                return AskToContinue();
            }

        }

    }
}