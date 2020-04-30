using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public string DepartmentError { get; set; }

        //Optional when creating the department, because the ID will be set by SQL and the dateTime will be set automatically. But I want them in the parameter so when we get
        //Them from the database we can still easily instaniate the dataModel with one constructor. Still wondering if this works correctly.
        public Department([Optional] int departmentID, string name, DateTime dateCreated)
        {
            Name = name;
            DepartmentID = departmentID;
            DateCreated = dateCreated;
        }
    }
}
