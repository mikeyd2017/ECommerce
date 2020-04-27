using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShopID { get; set; }

        public Category([Optional] int categoryID, string name, int shopID)
        {
            CategoryID = categoryID;
            Name = name;
            ShopID = shopID;
        }
    }
}
