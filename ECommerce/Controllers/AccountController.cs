using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce;
using ECommerce.Helpers;
using ECommerce.DataModels;
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
            HttpContext.Session.SetString("uriBeforeLogin", Request.Headers["Referer"].ToString());

            User newUser = new User();
            return View(newUser);
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            string errorOrPassword = _Factory.AccountHelper.CheckLogin(username, password);

            if (password != errorOrPassword)
            {
                User loginUser = new User();
                loginUser.LoginError = errorOrPassword;

                return View(loginUser);
            }

            HttpContext.Session.SetString("role", _Factory.AccountCommands.GetUserRole(username));
            HttpContext.Session.SetString("userID", Convert.ToString(_Factory.AccountCommands.GetUserID(username)));
            HttpContext.Session.SetString("username", username);

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("uriBeforeLogin")))
            {
                return Redirect(HttpContext.Request.Headers["Referer"].ToString());
            }
            else
            {
                return Redirect(HttpContext.Session.GetString("uriBeforeLogin"));
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            password = _Factory.AccountHelper.HashPassword(password);

            _Factory.AccountHelper.CreateUser(username, password, email);
            return View();
        }

        public IActionResult Logout()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("role")))
            {
                HttpContext.Session.SetString("role", "");
            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                HttpContext.Session.SetString("userID", "");
            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                HttpContext.Session.SetString("username", "");
            }


            return Redirect(Request.Headers["Referer"].ToString());
        }




    }
}