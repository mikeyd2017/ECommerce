using ECommerce.DataModels;
using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class DepartmentCommands
    {
        //Each Commands file will be created with a dataHelper loaded in from the Factory in the controller
        private DataHelper DataHelper;
        Department department = new Department();

        //Constructor used when instanciating the command file, we are using the dataHelper from the Factory in the controller
        public DepartmentCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool CreateDepartments()
        {
            List<Department> departments = new List<Department>
            {
                new Department(0, "Apparel", DateTime.Now),
                new Department(0, "Hats", DateTime.Now),
                new Department(0, "Shoes", DateTime.Now),
                new Department(0, "Jackets", DateTime.Now),
                new Department(0, "T-Shirts", DateTime.Now)
            };

            DataHelper.DbConn.Open();
            foreach (Department d in departments)
            {
                SqlCommand cmd = DataHelper.DbConn.CreateCommand();

                cmd.CommandText = "INSERT INTO Department VALUES(@dName, @dateCreated);";

                cmd.Parameters.Add(new SqlParameter("dName", d.Name));
                cmd.Parameters.Add(new SqlParameter("dateCreated", d.DateCreated));
                cmd.ExecuteNonQuery();
            }
            DataHelper.DbConn.Close();

            return true;
        }

        public List<Department> GetAllDepartments()
        {
            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * FROM Department;";

            DataHelper.DbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                departments.Add(new Department(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2)));
            }

            DataHelper.DbConn.Close();

            return departments;
        }

        public Department GetDepartment(int departmentID)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * From Department Where DepartmentID = @departmentID;";

            cmd.Parameters.Add(new SqlParameter("departmentID", departmentID));

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                department = new Department(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()));
            }

            DataHelper.DbConn.Close();

            return department;
        }

    }
}
