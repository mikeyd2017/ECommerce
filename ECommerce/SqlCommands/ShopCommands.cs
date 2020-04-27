using ECommerce.DataModels;
using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class ShopCommands
    {
        private DataHelper DataHelper;

        public ShopCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool InsertShop(Shop newShop)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Shops Values(@userID, @departmentID, @name);";

            cmd.Parameters.Add(new SqlParameter("userID", newShop.UserID));
            cmd.Parameters.Add(new SqlParameter("departmentID", newShop.DepartmentID));
            cmd.Parameters.Add(new SqlParameter("name", newShop.Name));
            

            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }
    }
}
