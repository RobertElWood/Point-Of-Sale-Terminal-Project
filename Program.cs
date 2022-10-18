using PointOfSale;

namespace Point_of_Sale_Terminal
{
    public class Program
    {

        static void Main(string[] args)
        {


            bool runAgain = true;
            POS storeVisit = new POS();
            string logo = @"
                                 _____      _               ____                                                    
                                |  __ \    | |             |  _ \                                               
                                | |__) |___| |_ _ __ ___   | |_) | ___  _   _ ___                               
                                |  _  // _ \ __| '__/ _ \  |  _ < / _ \| | | / __|                              
                                | | \ \  __/ |_| | | (_) | | |_) | (_) | |_| \__ \                              
                                |_|  \_\___|\__|_|  \___/  |____/ \___/ \__, |___/                              
                                  _____                         _____ _  __/ |                              
                                 / ____|                       / ____| ||___/                               
                                | |  __  __ _ _ __ ___   ___  | (___ | |_ ___  _ __ ___                     
                                | | |_ |/ _` | '_ ` _ \ / _ \  \___ \| __/ _ \| '__/ _ \                    
                                | |__| | (_| | | | | | |  __/  ____) | || (_) | | |  __/                    
                                 \_____|\__,_|_| |_| |_|\___| |_____/ \__\___/|_|  \___|                    ";
            
            string logo2 = @"

           ;
       .==\""/==.                        
      ((+) .  .:)
      |`.-(o)-.'|
      \/  \_/  \/                    ";
            string logo3 = @"

                		     ,---.U                      ________________
                		 .==\""/==. 			|   |,""    `.|   | 
                		((+) .  .:)	                |   /  SONY  \   |
                		|`.-(o)-.'|			|O _\   />   /_  |    ___ _
                		\/  \_/  \/			|_(_)'.____.'(_)_|  ("")__("")
                					        [___|[=]__[=]|___]  //    \\
                							\         ;
                							 `-.___.-'   ";
                
            
            
            string format1 = "∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞";
            string formatGreeting2 = "¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Browse our products below ¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤";
            //Console.SetCursorPosition((Console.WindowWidth - logo.Length) / 2, Console.CursorTop);
            Console.WriteLine(logo + logo3);

            while (runAgain)
            {

                //Console.SetCursorPosition((Console.WindowWidth - greeting2.Length) / 2, Console.CursorTop
                Console.WriteLine(format1);
                Console.WriteLine(formatGreeting2);
                Console.WriteLine(format1);

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