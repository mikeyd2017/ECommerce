using ECommerce.DataModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ECommerce.Helpers
{
    public class AccountHelper
    {
        private Factory _Factory;

        public const string passwordInvalid = "Password invalid";
        public const string hashInvalid = "Password hash invalid";
        public const string userNameInvalid = "Username invalid";
        public const string noUserOrPass = "Please enter a username and password";
        public const string noUserOrPassOrEmail = "Please enter a username, password, and email";
        public const string noUser = "Please enter a username";
        public const string noPassword = "Please enter a password";
        public const string noEmail = "Please enter an email";
        public const string emailInvalid = "Email invalid";
        public const string userNameTaken = "Username taken";
        public const string emailTaken = "Email taken";
        public AccountHelper(Factory oFactory)
        {
            _Factory = oFactory;
        }
        public bool CreateUser(string username, string password, string email)
        {
            User newUser = new User();
            newUser.Username = username;
            newUser.Password = password;
            newUser.Email = email;
            newUser.DateCreated = DateTime.Now;
            newUser.Role = Convert.ToString(User.Roles.Basic);

            _Factory.AccountCommands.InsertUser(newUser);

            return true;
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public string CheckLogin(string username, string password)
        {
            string errorMessage = "";
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorMessages.Add(noUserOrPass);
            }
            else
            {
                string hashedPassword = _Factory.AccountCommands.GetHashedPassword(username);

                if (String.IsNullOrEmpty(hashedPassword))
                {
                    errorMessages.Add(passwordInvalid);
                }
                else
                {
                    byte[] hashBytes = Convert.FromBase64String(hashedPassword);

                    byte[] salt = new byte[16];

                    Array.Copy(hashBytes, 0, salt, 0, 16);

                    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(20);

                    List<string> hashErrors = new List<string>();


                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                            hashErrors.Add(hashInvalid);
                    }

                    if (hashErrors.Count > 0)
                    {
                        errorMessages.Add(passwordInvalid);
                    }
                }



                string userNameFound = _Factory.AccountCommands.GetUserName(username);

                if (String.IsNullOrEmpty(userNameFound))
                {
                    errorMessages.Add(userNameInvalid);
                }
            }


            if (errorMessages.Count > 0)
            {
                string lastString = errorMessages.Last();

                foreach (string message in errorMessages)
                {
                    if (message.Equals(lastString))
                    {
                        errorMessage += message;
                    }
                    else
                    {
                        errorMessage += message + ", ";
                    }
                }

                return errorMessage;
            }

            return password;
        }

        public string CheckRegister(string username, string password, string email)
        {
            string errorMessage = "";
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                errorMessages.Add(noUserOrPassOrEmail);
            }
            else
            {
                if (!String.IsNullOrEmpty(_Factory.AccountCommands.GetUserName(username)))
                {
                    errorMessages.Add(userNameTaken);
                }

                if (!String.IsNullOrEmpty(_Factory.AccountCommands.CheckEmail(email)))
                {
                    errorMessages.Add(emailTaken);
                }

            }

            if (errorMessages.Count > 0)
            {
                string lastString = errorMessages.Last();

                foreach (string message in errorMessages)
                {
                    if (message.Equals(lastString))
                    {
                        errorMessage += message;
                    }
                    else
                    {
                        errorMessage += message + ", ";
                    }
                }
            }

            return errorMessage;
        }


    }
}
