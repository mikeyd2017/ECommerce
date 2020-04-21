using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce;
using ECommerce.Helpers;
using ECommerce.SqlCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FullStackFullTime.Controllers
{
    public class AccountController : Controller
    {
        private Factory _Factory = new Factory();

        public AccountController(IConfiguration iConfig)
        {
            _Factory.DataHelper = new DataHelper(iConfig);
            _Factory.AccountCommands = new AccountCommands(_Factory.DataHelper);
            _Factory.AccountHelper = new AccountHelper(_Factory);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            _Factory.AccountHelper.CheckAccount(username, password);

            HttpContext.Session.SetString("role", _Factory.AccountCommands.GetUserRole(username));
            HttpContext.Session.SetString("username", username);

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {

            _Factory.AccountHelper.CreateUser(username, _Factory.AccountHelper.HashPassword(password), email);
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("role", "");

            return RedirectToAction("Index", "Home");
        }




    }
}