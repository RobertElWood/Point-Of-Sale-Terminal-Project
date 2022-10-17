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
        public List<Inventory> ListOfInventory { get; set; } = new List<Inventory> { };
        public Dictionary<int, Inventory> PurchasedItems { get; set; } = new Dictionary<int, Inventory>();

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

        public void PrintInventory()
        {
            for (int i = 0; i < ListOfInventory.Count; i++)
            {
                Console.WriteLine($"condition: {ListOfInventory[i].Condition}\tname: {ListOfInventory[i].Name}\tprice: {ListOfInventory[i].Price}\tdescription: {ListOfInventory[i].Description}");
            }

        }

        public void Purchase()
        {
            Console.WriteLine("Which item would you like to purchase?");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("How many would you like to purchase?");
            int input2 = int.Parse(Console.ReadLine());

            PurchasedItems.Add(input2, ListOfInventory[input]);
            Console.WriteLine($"Congrats on purchasing: {input2}\tname: {ListOfInventory[input].Name}");
        }

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
            double Total2 = Total * 1.06;
            Console.WriteLine($"Your subtotal is {Total} and your total after tax is {Total2}");
        }
    }
}