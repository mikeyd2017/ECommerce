using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.DataModels
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string Role { get; set; }

        public string LoginError { get; set; }

        public User()
        {
        }

        public User(string username, string password, string email, string phone)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public enum Roles
        {
            Basic,
            Admin
        }

    }
}
