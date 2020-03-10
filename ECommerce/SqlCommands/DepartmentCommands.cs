using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class DepartmentCommands
    {
        //Each Commands file will be created with a dataHelper loaded in from the Factory in the controller
        private DataHelper DataHelper;

        //Constructor used when instanciating the command file, we are using the dataHelper from the Factory in the controller
        public DepartmentCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool CreateDepartments()
        {
            return true;
        }
    }
}
