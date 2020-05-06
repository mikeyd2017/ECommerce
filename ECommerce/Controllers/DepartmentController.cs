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
    public class DepartmentController : Controller
    {
        private Factory _Factory = new Factory();

        public DepartmentController(IConfiguration iConfig)
        {
            _Factory.DataHelper = new DataHelper(iConfig);
            _Factory.DepartmentCommands = new DepartmentCommands(_Factory.DataHelper);
            _Factory.DepartmentHelper = new DepartmentHelper(_Factory);
        }
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult CreateDept()
        {
            Department newDepartment = new Department();
            

            return View(newDepartment);
        }

        [HttpPost]
        public IActionResult CreateDept(string departmentID, string name, string dateCreated)
        {
            string errorMessage = _Factory.DepartmentHelper.CheckCreate(departmentID, name, dateCreated);
            if (!String.IsNullOrEmpty(errorMessage))
            {
                Department createDepartment = new Department();
                createDepartment.DepartmentError = errorMessage;

                return View(createDepartment);
            }

            return View("Departments");

        }

        public IActionResult Department(string departmentID)
        {

            return View("Department");
        }





    }
}