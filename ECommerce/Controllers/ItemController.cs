using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.DataModels;
using ECommerce.Helpers;
using ECommerce.SqlCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Controllers
{

    public class ItemController : Controller
    {
        private Factory oFactory = new Factory();

        public ItemController(IConfiguration iConfig)
        {
            //here we set all classes needed for the controller, IConfig is built in to get our connection string. We will need to set DataHelper of the oFactory in any database controller.
            oFactory.DataHelper = new DataHelper(iConfig);
            oFactory.TableCommands = new TableCommands(oFactory.DataHelper);
            oFactory.DepartmentCommands = new DepartmentCommands(oFactory.DataHelper);
            oFactory.AccountCommands = new AccountCommands(oFactory.DataHelper);
            oFactory.ItemCommands = new ItemCommands(oFactory.DataHelper);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllItems(int categoryID)
        {
            List<Item> allItems = new List<Item>();

            allItems = oFactory.ItemCommands.GetAllItems(categoryID);

            return RedirectToAction("Items", "Item", allItems);
        }

        public IActionResult GetItem(int itemID)
        {
            Item selectedItem = oFactory.ItemCommands.GetItem(itemID);

            return View("Item", selectedItem);
        }
    }
}