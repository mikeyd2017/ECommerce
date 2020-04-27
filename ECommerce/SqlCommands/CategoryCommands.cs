using ECommerce.DataModels;
using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class CategoryCommands
    {
        private DataHelper DataHelper;

        public CategoryCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool InsertCategory(Category newCategory)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Categories Values(@name, @shopID);";

            cmd.Parameters.Add(new SqlParameter("name", newCategory.Name));
            cmd.Parameters.Add(new SqlParameter("shopID", newCategory.ShopID));
            
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }
    }
}
