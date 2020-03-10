using ECommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class TableCommands
    {
        //Each Commands file will be created with a dataHelper loaded in from the Factory in the controller
        private DataHelper DataHelper;
        
        //Constructor used when instanciating the command file, we are using the dataHelper from the Factory in the controller
        public TableCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        //Examples of queries using this factory set up, they will be the same. Just using the DataHelper.DbConn string instead of setting it every time.
        public bool CreateTestTable()
        {
            string query = "Create Table Test (TestID int, Name varchar(255), Date date);";
            SqlCommand cmd = new SqlCommand(query, DataHelper.DbConn);
            DataHelper.DbConn.Open();
            cmd.ExecuteNonQuery();
            DataHelper.DbConn.Close();
            return true;
        }

        public bool DropTestTable()
        {
            string query = "IF Object_ID('dbo.Test', 'U') IS NOT NULL DROP TABLE dbo.Test;";
            SqlCommand cmd = new SqlCommand(query, DataHelper.DbConn);
            DataHelper.DbConn.Open();
            cmd.ExecuteNonQuery();
            DataHelper.DbConn.Close();
            return true;
        }
    }
}
