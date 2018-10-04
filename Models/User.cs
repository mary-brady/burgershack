using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class UserLogin //Helper Model - info needed to actually create a user & keep password in user class Private
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class UserRegsistration
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        [Required]
        internal string Hash { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public bool Active { get; set; } = true;

    }
}