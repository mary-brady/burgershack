using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        private string Password { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public User()
        {
            new User() { };
        }
    }
}