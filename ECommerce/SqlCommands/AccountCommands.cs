using ECommerce.Helpers;
using ECommerce.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.SqlCommands
{
    public class AccountCommands
    {
        private DataHelper DataHelper;
        private string password;
        private string role;
        private int userID;

        public AccountCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }


        public bool InsertUser(User newUser)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Users Values(@userName, @password, @email, @role, @dateCreated);";

            cmd.Parameters.Add(new SqlParameter("userName", newUser.Username));
            cmd.Parameters.Add(new SqlParameter("password", newUser.Password));
            cmd.Parameters.Add(new SqlParameter("email", newUser.Email));
            cmd.Parameters.Add(new SqlParameter("dateCreated", newUser.DateCreated));
            cmd.Parameters.Add(new SqlParameter("role", newUser.Role));

            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }

        public string GetHashedPassword(string username)
        {

            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select Password From Users Where Username = @username;";

            cmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                password = dr[0].ToString();
            }
            DataHelper.DbConn.Close();
            return password;
        }

        public string GetUserRole(string username)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select Role From Users Where Username = @username;";

            cmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                role = dr[0].ToString();
            }
            DataHelper.DbConn.Close();
            return role;
        }

        public int GetUserID(string username)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select UserID From Users Where Username = @username;";

            cmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                userID = Convert.ToInt32(dr[0].ToString());
            }
            DataHelper.DbConn.Close();
            return userID;
        }

        public string GetUserName(string username)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select Username From Users Where Username = @username;";

            cmd.Parameters.Add(new SqlParameter("username", username));

            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.HasRows)
            {
                username = null;
            }
            else
            {
                while (dr.Read())
                {
                    username = dr[0].ToString();
                }
            }


            DataHelper.DbConn.Close();
            return username;
        }

    }
}
