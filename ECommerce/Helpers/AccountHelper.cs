using ECommerce;
using ECommerce.Models;
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

        public string CheckAccount(string username, string password)
        {
            string hashedPassword = _Factory.AccountCommands.GetHashedPassword(username);

            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];

            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();
            }

            return password;
        }

    }
}
