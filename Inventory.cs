using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal
{



    //Enum is a constant list of values
    public enum Category
    {
        Games,
        Consoles,
        Accessories,

    }

    //Enum for item condition
    public enum Condition
    {
        Used,
        New
    }



    //Setting properties for Enums
    public class Inventory
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public Category Description { get; set; }

        public Condition Condition { get; set; }




        //Constructor to initialize properties
        public Inventory(Condition Condition, string Name, Category Description, double Price)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Condition = Condition;
        }


    }

}
