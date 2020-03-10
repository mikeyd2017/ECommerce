using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Helpers;
using Microsoft.Extensions.Configuration;
using ECommerce.SqlCommands;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        //We create a new Factory on every controller. The Factory will have optional class parameters for whichever classes we will be using in the controllers. Later we will
        //have more class options such as ItemCommands, UserCommands, ViewModel to DataModel converters/helpers, etc. This will give us the best way to have all our classes together for
        //each controller.
        private Factory oFactory = new Factory();

        public HomeController(IConfiguration iConfig)
        {
            //here we set all classes needed for the controller, IConfig is built in to get our connection string. We will need to set DataHelper of the oFactory in any database controller.
            oFactory.DataHelper = new DataHelper(iConfig);
            oFactory.TableCommands = new TableCommands(oFactory.DataHelper);
        }

        public IActionResult Index()
        {
            oFactory.TableCommands.CreateTestTable();
            //oFactory.TableCommands.DropTestTable();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult bigMad()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
