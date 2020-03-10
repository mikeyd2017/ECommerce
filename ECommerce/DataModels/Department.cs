using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class Department
    {
        private int DepartmentID { get; set; }
        private string Name { get; set; }
        private DateTime DateCreated { get; set; }

        //Optional when creating the department, because the ID will be set by SQL and the dateTime will be set automatically. But I want them in the parameter so when we get
        //Them from the database we can still easily instaniate the dataModel with one constructor. Still wondering if this works correctly.
        public Department([Optional] int departmentID, string name, [Optional] DateTime dateCreated)
        {
            Name = name;
            DepartmentID = departmentID;
            if (dateCreated != null)
            {
                DateCreated = dateCreated;
            }
            else
            {
                DateCreated = DateTime.Now;
            }
        }
    }
}
