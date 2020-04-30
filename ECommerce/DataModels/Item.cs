using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }

        public string ItemError { get; set; }

        public Item([Optional] int itemID, int categoryID, string name, int quantity, double price, string description)
        {
            ItemID = itemID;
            CategoryID = categoryID;
            Name = name;
            Quantity = quantity;
            Price = price;
            Description = description;
        }
    }
}
