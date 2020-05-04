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

        public List<Category> GetAllCategories()
        {
            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * FROM Category;";

            DataHelper.DbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(new Category(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }

            DataHelper.DbConn.Close();

            return categories;
        }
    }
}
