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

        //Examples of queries using this factory set up, they will be the same. Just using the DataHelper.DbConn SqlConnection object instead of setting it every time.
        //USE DEPARTMENT COMMANDS SYNTAX, USE DBConn.CreateCommand 
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
                                                     
        public bool CreateDepartmentTable()
        {
            string query = "Create Table Department (DepartmentID int NOT NULL IDENTITY PRIMARY KEY, Name varchar(200) NOT NULL, CreateDate date NOT NULL);";
            SqlCommand cmd = new SqlCommand(query, DataHelper.DbConn);
            DataHelper.DbConn.Open();
            cmd.ExecuteNonQuery();
            DataHelper.DbConn.Close();
            return true;
        }

        public bool DropDepartmentTable()
        {
            string query = "IF Object_ID('dbo.Department', 'U') IS NOT NULL DROP TABLE dbo.Department;";
            SqlCommand cmd = new SqlCommand(query, DataHelper.DbConn);
            DataHelper.DbConn.Open();
            cmd.ExecuteNonQuery();
            DataHelper.DbConn.Close();
            return true;
        }

        public bool CreateUserTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Users (UserID int IDENTITY PRIMARY KEY, Username varchar(20) NOT NULL, Password varchar(40) NOT NULL, Email varchar(60) NOT NULL, Role varchar(30) NOT NULL, CreateDate date NOT NULL);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool CreateShopTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Shop (ShopID int IDENTITY(1,1) PRIMARY KEY, UserID int NOT NULL, DepartmentID int NOT NULL, Name varchar(254) NOT NULL, CONSTRAINT FK_USER_SHOP FOREIGN KEY(UserID) REFERENCES Users(UserID), CONSTRAINT FK_SHOP_DEPARTMENT FOREIGN KEY(DepartmentID) REFERENCES Department(DepartmentID) ON DELETE CASCADE ON UPDATE CASCADE);"; 
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool CreateCategoryTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Category (CategoryID int IDENTITY PRIMARY KEY, Name varchar(254) NOT NULL, ShopID int NOT NULL, CONSTRAINT FK_Shop_Category FOREIGN KEY (ShopID) REFERENCES Shop(ShopID) ON DELETE CASCADE ON UPDATE CASCADE);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool AddHashedPassToUserTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "ALTER TABLE Users Alter Column Password char(300);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }
    }
}
