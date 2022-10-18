using PointOfSale;

namespace Point_of_Sale_Terminal
{
    public class Program
    {

        static void Main(string[] args)
        {

            //Bool to prompt loop
            bool runAgain = true;
            //New instance of POS class
            POS storeVisit = new POS();
            //Top Console Greeting
            Logo Beauty = new Logo();            


            //Main store visit loop
            while (runAgain)
            {
                //Beautify3 + repeated product list header
                Console.WriteLine("∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞");
                Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Browse our products below ¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤");
                Console.WriteLine("∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞");

                //Printing actual product inventory
                storeVisit.PrintInventory();
                Console.WriteLine();//Formatting
                //Calling Purchase method to inquire with the user what they'd like to purchase TODO: Add something that says the user can just exit right away maybe?
                storeVisit.Purchase();
                Console.WriteLine();//Formatting
                //Prompt user to go again
                runAgain = AskToContinue();
            }
            //Prompt user to select their pay type if they're done browsing
            storeVisit.ChoosePaymentMethod();
        }


        //Method to prompt user to continue
        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to purchase anything else? y/n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine("Okay, great!");
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you for stopping by!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't catch that.");
                return AskToContinue();
            }
        }

    }
}