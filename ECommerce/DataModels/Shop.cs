using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class Shop
    {
        public int ShopID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }

        public Shop([Optional] int shopID, int userID, int departmentID, string name)
        {
            ShopID = shopID;
            UserID = userID;
            DepartmentID = departmentID;
            Name = name;
        }
    }
}
