using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProNatur_Biomarkt_GmbH
{
    public class Product
    {
        public int ID { get; set; }
        public int InventoryNumber { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        //constructor (no parameters). Allows the creation of an object without immediately initializing its properties
        public Product()
        { }

        // Constructor to directly initialize
        public Product(int id, int inventoryNumber, string name, string brand, string category, decimal price, int amount)
        {
            ID = id;
            InventoryNumber = inventoryNumber;
            Name = name;
            Brand = brand;
            Category = category;
            Price = price;
            Amount = amount;
        }
    }
}