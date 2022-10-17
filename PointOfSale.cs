using Point_of_Sale_Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS

{
    public class POS
    {
        public List< Inventory> ListOfInventory { get; set; } = new List <Inventory> { };
        public Dictionary <int, Inventory> PurchasedItems { get; set; } = new Dictionary <int, Inventory>();

        //public enum PayType
        //{
        //    Cash,
        //    Credit,
        //    Check
        //}

        public POS()
        {
       
            Inventory game1 = new Inventory(Condition.Used, "Super Mario 64", Category.Games, 52);
            ListOfInventory.Add(game1);
            Inventory game2 = new Inventory(Condition.Used, "Crash Bandicoot", Category.Games, 32);
            ListOfInventory.Add(game2);
            Inventory game3 = new Inventory(Condition.Used, "Mortal Kombat II", Category.Games, 28);
            ListOfInventory.Add(game3);
            Inventory game4 = new Inventory(Condition.Used, "Spyro: Year of the Dragon", Category.Games, 15);
            ListOfInventory.Add(game4);
            Inventory game5 = new Inventory(Condition.New, "NBA2K", Category.Games, 20);
            ListOfInventory.Add(game5);
            Inventory game6= new Inventory(Condition.New, "Fallout 2", Category.Games, 19);
            ListOfInventory.Add(game6);
            Inventory game7 = new Inventory(Condition.Used, "Pokemon Yellow", Category.Games, 100);
            ListOfInventory.Add(game7);
            Inventory game8 = new Inventory(Condition.Used, "Sonic Adventure", Category.Games, 8);
            ListOfInventory.Add(game8);
            Inventory game9 = new Inventory(Condition.New, "Power Stone", Category.Games, 399);
            ListOfInventory.Add(game9);
            Inventory game10 = new Inventory(Condition.Used, "Soulcalibur II", Category.Games, 33);
            ListOfInventory.Add(game10);
            Inventory console1 = new Inventory(Condition.Used, "Sega Dreamcast", Category.Consoles, 160);
            ListOfInventory.Add(console1);
            Inventory console2 = new Inventory(Condition.Used, "PlayStation 2", Category.Consoles, 155);
            ListOfInventory.Add(console2);
            Inventory console3 = new Inventory(Condition.New, "Super Nintendo Entertainment System", Category.Consoles, 200);
            ListOfInventory.Add(console3);
            Inventory console4 = new Inventory(Condition.Used, "Nintendo 64", Category.Consoles, 140);
            ListOfInventory.Add(console4);
            Inventory accessory1 = new Inventory(Condition.Used, "PlayStation 2 Dualshock 2 Wired Controller", Category.Accessories, 60);
            ListOfInventory.Add(accessory1);
            Inventory accessory2 = new Inventory(Condition.Used, "Super Nintendo Entertainment System AC Adapter", Category.Accessories, 15);
            ListOfInventory.Add(accessory2);
            Inventory accessory3 = new Inventory(Condition.Used, "NES Cleaning Kit", Category.Accessories, 138);
            ListOfInventory.Add(accessory3);
            Inventory accessory4 = new Inventory(Condition.Used, "Nintendo 64 Controller", Category.Accessories, 20);
            ListOfInventory.Add(accessory4);
            Inventory accessory5 = new Inventory(Condition.Used, "Gameboy Game Shark", Category.Accessories, 12);
            ListOfInventory.Add(accessory5);

        }

        //Method to print inventory to the user.
        public void PrintInventory()
        {
            for (int i = 0; i < ListOfInventory.Count; i++)
            {
                Console.WriteLine($"condition: {ListOfInventory[i].Condition}\tname: {ListOfInventory[i].Name}\tprice: {ListOfInventory[i].Price}\tdescription: {ListOfInventory[i].Description}");
            }
        }

        //Method by which the user can purchase multiple items. Item qty and type saved to dictionary
        public void Purchase()
        {
            Console.WriteLine("Which item would you like to purchase?");
            int input = int.Parse(Console.ReadLine());  //needs error handling
            Console.WriteLine("How many would you like to purchase?");
            int input2 = int.Parse(Console.ReadLine()); //needs error handling

            PurchasedItems.Add(input2, ListOfInventory[input]);
            Console.WriteLine($"Congrats on purchasing: {input2}\tname: {ListOfInventory[input].Name}");
        }

        //Method to print receipt of purchase to the user.
        public void PrintReciept()
        {
            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                Console.WriteLine($"amount: {PurchasedItems.ElementAt(i).Key}name: {PurchasedItems.ElementAt(i).Value.Name}\tprice: {PurchasedItems.ElementAt(i).Value.Price}");
            }
            int Total = 0;

            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                int ItemPrice = PurchasedItems.ElementAt(i).Key * PurchasedItems.ElementAt(i).Value.Price;
                Total += ItemPrice;
            }
            double Total2 = Math.Round(Total * 1.06, 2);

            Console.WriteLine($"Your subtotal is {Total} and your total after tax is {Total2}");
        }
        
        //Method to let user select their preferred payment type.
        public void ChoosePaymentMethod()
        {
            Console.WriteLine("What payment method would you like to use? Cash, Credit, or Check?");

            Console.WriteLine("1 - Cash");
            Console.WriteLine("2 - Credit");
            Console.WriteLine("3 - Check");

            int input = int.Parse(Console.ReadLine()); //needs error handling

            if (input == 1)
            {
                CalculateChange();
            }
            else if (input == 2)
            {
                PayWithCard();
            }
            else
            {
                PayWithCheck();
            }

        }

        //Method for cash payment, calculates change for the user based on their input
        public void CalculateChange() 
        {
            int total = 0;

            double total2 = total * 1.06;

            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                int ItemPrice = PurchasedItems.ElementAt(i).Key * PurchasedItems.ElementAt(i).Value.Price;
                total += ItemPrice;
            }

            Console.WriteLine("Your total is: " + "$" + total2);
            Console.WriteLine("Please enter the amount of cash you'd like to pay with.");   

            int input = int.Parse(Console.ReadLine()); //needs error handling

            double change = Math.Round(total2 - input, 2);

            Console.WriteLine($"You paid ${input} in cash");
            Console.WriteLine($"Your change was: ${change}");

        }

        //Method which allows user to enter necessary credit card information (num, exp, CVV)
        public void PayWithCard()
        {
            bool runAgain = true;

            while (runAgain)
            {
                Console.WriteLine("Please enter your credit card number: ");

                string input2 = Console.ReadLine();

                bool isNumeric = int.TryParse(input2, out int creditnumber);

                if (isNumeric == false)
                {
                    Console.WriteLine("I'm sorry, you need to enter a number.");
                    continue;
                }
                else if (input2.Count() < 16)
                {
                    Console.WriteLine("Please enter your sixteen digit credit card number.");
                    continue;
                }

                Console.WriteLine("Please enter your card's expiration month: ");

                string input3 = Console.ReadLine();

                bool isNumeric2 = int.TryParse(input3, out int expMonth);

                if (isNumeric2 == false)
                {
                    Console.WriteLine("I'm sorry, you need to enter a number.");
                    continue;
                }
                else if (expMonth > 12 || expMonth < 1)
                {
                    Console.WriteLine("Please enter a valid month, 1-12.");
                    continue;
                }

                Console.WriteLine("Please enter your card's expiration year: ");

                string input4 = Console.ReadLine();

                bool isNumeric3 = int.TryParse(input4, out int expYear);

                if (isNumeric3 == false)
                {
                    Console.WriteLine("I'm sorry, you need to enter a number.");
                    continue;
                }
                else if (expYear < 22)
                {
                    Console.WriteLine("I'm sorry, your card has expired. Please try a different card.");
                    continue;
                }

                string input5 = Console.ReadLine();

                bool isNumeric4 = int.TryParse(input5, out int CVV);

                if (isNumeric4 == false)
                {
                    Console.WriteLine("I'm sorry, you need to enter a number.");
                    continue;
                }
                else if (input5.Count() < 3 || input5.Count() > 3)
                {
                    Console.WriteLine("I'm sorry, your CVV is invalid. Please try another card.");
                    continue;
                }

                runAgain = false;
            }
        }

        //Method which prompts user to enter their routing number if paying by check.
        public void PayWithCheck()
        {
            bool runAgain = true;

            while (runAgain)
            {
                Console.WriteLine("Please enter your nine digit check number: ");

                string input6 = Console.ReadLine();

                bool isNumeric = int.TryParse(input6, out int checknumber);

                if (isNumeric == false)
                {
                    Console.WriteLine("I'm sorry, please enter a number.");
                    continue;
                }
                else if (input6.Count() < 9 || input6.Count() > 9)
                {
                    Console.WriteLine("Please enter your nine digit check number.");
                    continue;
                }

                runAgain = false;
            }
        }
    }
}