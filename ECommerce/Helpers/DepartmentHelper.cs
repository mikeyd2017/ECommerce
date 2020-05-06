using ECommerce.DataModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ECommerce.Helpers
{
    public class DepartmentHelper
    {
        private Factory _Factory;

        public const string noDepartmentIDOrName = "Please enter a Department ID and a Department name";
        public const string noDepartmentIDOrNameOrDateCreated = "Please enter a Department ID, Department Name, and Date Created";
        public const string noDepartmentID = "Please enter a Department ID";
        public const string noName = "Please enter a Department name";
        public const string noDateCreated = "Please enter a date created";
        public const string departmentNameTaken = "Department Name taken";
        public const string departmentIDTaken = "Department ID taken";
        public DepartmentHelper(Factory oFactory)
        {
            _Factory = oFactory;
        }


        public bool CreateDepartment(int departmentID, string departmentName, DateTime dateCreated)
        {
            Department newDepartment = new Department();
            newDepartment.DepartmentID = departmentID;
            newDepartment.Name = departmentName;
            newDepartment.DateCreated = dateCreated;

            //_Factory.DepartmentCommands.InsertDepartment(newDepartment);

            return true;
        }

        public string CheckCreate(string departmentID, string name, string dateCreated)
        {
            //    string errorMessage = "";
            //    List<string> errorMessages = new List<string>();

            //    if (string.IsNullOrEmpty(departmentID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dateCreated))
            //    {
            //        errorMessages.Add(noDepartmentIDOrNameOrDateCreated);
            //    }
            //    else
            //    {
            //        if (!String.IsNullOrEmpty(_Factory.DepartmentCommands.GetDepartmentID(departmentID)))
            //        {
            //            errorMessages.Add(departmentIDTaken);
            //        }

            //        if (!String.IsNullOrEmpty(_Factory.DepartmentCommands.CheckDepartmentName(name)))
            //        {
            //            errorMessages.Add(departmentNameTaken);
            //        }

            //    }

            //    if (errorMessages.Count > 0)
            //    {
            //        string lastString = errorMessages.Last();

            //        foreach (string message in errorMessages)
            //        {
            //            if (message.Equals(lastString))
            //            {
            //                errorMessage += message;
            //            }
            //            else
            //            {
            //                errorMessage += message + ", ";
            //            }
            //        }
            //    }

            //    return errorMessage;
            //}

            return "test";
        }
    }
}
