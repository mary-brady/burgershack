using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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

        public ClaimsPrincipal _principal { get; private set; }
        public bool Active { get; set; } = true;

        internal void SetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Id)
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            _principal = new ClaimsPrincipal(userIdentity);
        }
    }
}