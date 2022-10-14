using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
​
namespace POS
{
    public class POS
    {
        public List<Inventory> ListOfInventory { get; set; }
        public Dictionary<int, Inventory> PurchasedItems { get; set; } = new Dictionary<int, Inventory>();
​
        //public enum PayType
        //{
        //    Cash,
        //    Credit,
        //    Check
        //}
​
        public POS(List<Inventory> listofinventory)
        {
            ListOfInventory = listofinventory;
        }
​
        public void PrintInventory()
        {
            for (int i = 0; i < ListOfInventory.Count; i++)
            {
                Console.WriteLine($"condition: {ListOfInventory[i].Condition}\tname: {ListOfInventory[i].Name}\tprice: {ListOfInventory[i].Price}\tdescription: {ListOfInventory[i].Description}");
            }
​
        }
        public void Purchase()
        {
            Console.WriteLine("Which item would you like to purchase?");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("How many would you like to purchase?");
            int input2 = int.Parse(Console.ReadLine());
​
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
​
​
}