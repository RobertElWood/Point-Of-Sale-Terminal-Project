using Point_of_Sale_Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class POS
    {

        //Property to create the List of our product for sale
        public List<Inventory> ListOfInventory { get; set; } = new List<Inventory>();
        public List<Inventory> PurchasedItems { get; set; } = new List<Inventory>();
        public List<int> ItemQuantity { get; set; } = new List<int>();



        //Constructor to populate or product list with actual product
        public POS()
        {

            string relPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
          
            string fixedRel = relPath.Substring(0, relPath.LastIndexOf("bin"));
            
            StreamReader reader = new StreamReader(fixedRel + @"\InventoryList.txt");

            string textDump = reader.ReadToEnd();

            LogItems(textDump);

            //method to add inventory objects to inventory list from string

            /*Inventory game1 = new Inventory(Condition.Used, "Super Mario 64", Category.Games, 52);
            ListOfInventory.Add(game1);
            Inventory game2 = new Inventory(Condition.Used, "Crash Bandicoot", Category.Games, 32);
            ListOfInventory.Add(game2);
            Inventory game3 = new Inventory(Condition.Used, "Mortal Kombat II", Category.Games, 28);
            ListOfInventory.Add(game3);
            Inventory game4 = new Inventory(Condition.Used, "Spyro: Year of the Dragon", Category.Games, 15);
            ListOfInventory.Add(game4);
            Inventory game5 = new Inventory(Condition.New, "NBA2K", Category.Games, 20);
            ListOfInventory.Add(game5);
            Inventory game6 = new Inventory(Condition.New, "Fallout 2", Category.Games, 19);
            ListOfInventory.Add(game6);
            Inventory game7 = new Inventory(Condition.Used, "Pokemon Yellow", Category.Games, 100);
            ListOfInventory.Add(game7);
            Inventory game8 = new Inventory(Condition.Used, "Sonic Adventure", Category.Games, 8);
            ListOfInventory.Add(game8);
            Inventory game9 = new Inventory(Condition.New, "Power Stone", Category.Games, 399);
            ListOfInventory.Add(game9);
            Inventory game10 = new Inventory(Condition.Used, "Soulcalibur II", Category.Games, 33);
            ListOfInventory.Add(game10);
            Inventory game11 = new Inventory(Condition.Used, "Goldeneye 007", Category.Games, 89);
            ListOfInventory.Add(game11);
            Inventory game12 = new Inventory(Condition.Used, "Battletoads", Category.Games, 79);
            ListOfInventory.Add(game12);
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
            Inventory accessory3 = new Inventory(Condition.New, "NES Cleaning Kit", Category.Accessories, 138);
            ListOfInventory.Add(accessory3);
            Inventory accessory4 = new Inventory(Condition.Used, "Nintendo 64 Controller", Category.Accessories, 20);
            ListOfInventory.Add(accessory4);
            Inventory accessory5 = new Inventory(Condition.Used, "Gameboy Game Shark", Category.Accessories, 12);
            ListOfInventory.Add(accessory5);*/

        }


        //Method to print inventory to the user.
        public void PrintInventory()
        {
            for (int i = 0; i < ListOfInventory.Count; i++)
            {
                Console.WriteLine($"{(i+1)+")",-3}"+$"|±|Name: {ListOfInventory[i].Name, -49}|±|Price: ${ListOfInventory[i].Price,-7}|±|Condition: {ListOfInventory[i].Condition,-5}|±|Descrp: {ListOfInventory[i].Description}");
            }
        }


        //Method by which the user can purchase multiple items. Item qty and type saved to dictionary
        public void Purchase()
        {
            int input = -1;
            int input2 = -1;

            Console.WriteLine("\nPlease enter the number of an item you'd like to purchase:\n");

                try 
                {
                    input = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine($"\nYou've selected: {ListOfInventory[input].Name}\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nI'm sorry, please enter a number corresponding to the item you want.\n");
                    Purchase();
                }
                catch (ArgumentOutOfRangeException f)
                {
                    Console.WriteLine("\nI'm sorry, we don't have an item in stock that matches that number. Please try again.\n");
                    Purchase();
                }

            Console.WriteLine("How many would you like to purchase?\n");

            try
            {
                input2 = int.Parse(Console.ReadLine());
            } 
            catch (FormatException f)
            {
                Console.Write("\nI'm sorry. Please enter a valid number for the amount you'd like.\n");
                Purchase();
            }
            
            if (input2 < 0) 
            {
                Console.WriteLine("\nI'm sorry. Please enter a positive number. You can't buy -1 of something!\n");
                Purchase();
            }

            ItemQuantity.Add(input2);
            PurchasedItems.Add(ListOfInventory[input]);
            Console.WriteLine($"\nYou've added: {input2}x {ListOfInventory[input].Name} to your cart.");
        }


        //Method to print receipt of purchase to the user.
        public void PrintReciept()
        {
            Console.WriteLine();
            Console.WriteLine("YOUR RECEIPT: \n");
            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                Console.WriteLine($"{i+1}- |±|QTY: {ItemQuantity.ElementAt(i)}  |±|{PurchasedItems.ElementAt(i).Name}   |±|Price: ${PurchasedItems.ElementAt(i).Price}\n");
            }
            double Total = 0;

            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                double ItemPrice = ItemQuantity.ElementAt(i) * PurchasedItems.ElementAt(i).Price;
                Total += ItemPrice;
            }
            double Total2 = Math.Round(Total * 1.06, 2);

            Console.WriteLine($"|±|Subtotal: ${Total}\n|±|Total: ${Total2}\n");
        }


        //Method to let user select their preferred payment type.
        public void ChoosePaymentMethod()
        {
            Console.WriteLine("What payment method would you like to use? Cash, Credit, or Check?\n");

            Console.WriteLine("1 - Cash");
            Console.WriteLine("2 - Credit");
            Console.WriteLine("3 - Check");

            Console.WriteLine();
            string input = Console.ReadLine(); //needs error handling

            if (input == "1")
            {
                CalculateChange();
            }
            else if (input == "2")
            {
                PayWithCard();
            }
            else if (input == "3")
            {
                PayWithCheck();
            } 
            else
            {
                Console.WriteLine("\nI'm sorry, please enter only 1, 2, or 3 depending on which payment type you'd like.\n");
                ChoosePaymentMethod();
            }

        }


        //Method for cash payment, calculates change for the user based on their input
        public void CalculateChange()
        {
            bool AskAgain = true;

            double total = 0;
            double input = 0;

            for (int i = 0; i < PurchasedItems.Count; i++)
            {
                double ItemPrice = ItemQuantity.ElementAt(i) * PurchasedItems.ElementAt(i).Price;
                total += ItemPrice;
            }

            double total2 = total * 1.06;

            while (AskAgain)
            {
                Console.WriteLine("\nYour total is: " + "$" + Math.Round(total2, 2));
                Console.WriteLine("\nPlease enter the amount of cash you'd like to pay with.\n");

                try
                {
                    input = double.Parse(Console.ReadLine());

                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nI'm sorry, please enter a valid payment number.\n");
                    input = 0;
                    continue;
                }

                if (input < total2)
                {
                    Console.WriteLine("\nI'm sorry, please enter a number that allows you to pay your entire total.\n");
                    input = 0;
                    continue;
                }

                AskAgain = false;
            }

            double change = Math.Round(input - total2, 2);

            Console.WriteLine($"\nYou paid ${input} in cash\n");
            Console.WriteLine($"Your change was: ${change}\n");
        }


        //Method which allows user to enter necessary credit card information (num, exp, CVV)
        public void PayWithCard()
        {
            bool runAgain = true;

            while (runAgain)
            {
                Console.WriteLine("\nPlease enter your credit card number: \n");

                string input2 = Console.ReadLine();

                bool isNumeric = input2.Any(Char.IsDigit);

                if (isNumeric == false)
                {
                    Console.WriteLine("\nI'm sorry, you need to enter a number.");
                    continue;
                }
                else if (input2.Count() > 16 || input2.Count() < 16)
                {
                    Console.WriteLine("\nPlease enter your sixteen digit credit card number.");
                    continue;
                }

                Console.WriteLine("\nPlease enter your card's expiration month: \n");

                string input3 = Console.ReadLine();

                bool isNumeric2 = input3.Any(Char.IsDigit);

                if (isNumeric2 == false)
                {
                    Console.WriteLine("\nI'm sorry, you need to enter a number.");
                    continue;
                }
                else if (int.Parse(input3) > 12 || int.Parse(input3) < 1)
                {
                    Console.WriteLine("\nPlease enter a valid month, 1-12.");
                    continue;
                }

                Console.WriteLine("\nPlease enter your card's expiration year: \n");

                string input4 = Console.ReadLine();

                bool isNumeric3 = input4.Any(Char.IsDigit);

                if (isNumeric3 == false)
                {
                    Console.WriteLine("\nI'm sorry, you need to enter a number.");
                    continue;
                }
                else if (int.Parse(input4) < 22)
                {
                    Console.WriteLine("\nI'm sorry, your card has expired. Please try a different card.");
                    continue;
                }
                Console.WriteLine("\nPlease enter your card's CVV Code: \n");

                string input5 = Console.ReadLine();

                bool isNumeric4 = input5.Any(Char.IsDigit);

                if (isNumeric4 == false)
                {
                    Console.WriteLine("\nI'm sorry, you need to enter a number.");
                    continue;
                }
                else if (input5.Length < 3 || input5.Length > 3)
                {
                    Console.WriteLine("\nI'm sorry, your CVV is invalid. Please try another card.");
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
                Console.WriteLine("\nPlease enter your nine digit check number: \n");

                string input6 = Console.ReadLine(); //error handling

                bool isNumeric = input6.Any(Char.IsDigit);

                if (isNumeric == false)
                {
                    Console.WriteLine("\nI'm sorry, please enter a valid check number.");
                    continue;
                }
                else if (input6.Count() < 9 || input6.Count() > 9)
                {
                    Console.WriteLine("\nPlease enter a check number that is exactly 9 digits.");
                    continue;
                } 
                else if (input6.Any(Char.IsSymbol) == true) 
                {
                    Console.WriteLine("\nI'm sorry, please enter a valid check number.");
                    continue;
                } 
                else if (input6.Any(Char.IsLetter) == true) 
                {
                    Console.WriteLine("\nI'm sorry, please enter a valid check number.");
                    continue;
                } 
                else if (input6.Any(Char.IsPunctuation) == true)
                {
                    Console.WriteLine("\nI'm sorry, please enter a valid check number.");
                    continue;
                }

                runAgain = false;
            }
        }

        //Method that converts items from text file into Inventory objects.
        //Splits into a list of strings at each ';' in text file. Each ';' represents a new object
        //Then splits to remove commas. Finally takes each string and adds it as a property for the new object.
        public void LogItems(string textdump) 
        {
            List <string> lineItems = textdump.Split(';').ToList();

            for (int i = 0; i < lineItems.Count()-1; i++)
            {
                string[] itemString = lineItems[i].Split(',');

                Inventory newItem = new Inventory ((Condition)Enum.Parse(typeof(Condition), itemString[0]), itemString[1], (Category)Enum.Parse(typeof(Category), itemString[2]), double.Parse(itemString[3]));

                ListOfInventory.Add(newItem);
            }
        }
    }
}