using ECommerce.DataModels;
using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class ItemCommands
    {
        private DataHelper DataHelper;

        public ItemCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool InsertItem(Item newItem)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Items Values(@categoryID, @name, @quantity, @price, @description);";

            cmd.Parameters.Add(new SqlParameter("categoryID", newItem.CategoryID));
            cmd.Parameters.Add(new SqlParameter("name", newItem.Name));
            cmd.Parameters.Add(new SqlParameter("quantity", newItem.Quantity));
            cmd.Parameters.Add(new SqlParameter("price", newItem.Price));
            cmd.Parameters.Add(new SqlParameter("description", newItem.Description));

            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }

        public List<Item> GetAllItems()
        {
            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * FROM Item;";

            DataHelper.DbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                items.Add(new Item(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetDouble(4), reader.GetString(5)));
            }

            DataHelper.DbConn.Close();

            return items;
        }
    }
}
