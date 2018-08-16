using System;
using System.ComponentModel.DataAnnotations;

namespace HummingBoxApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specity a password between 4 and 8 characters")]
        public string Password { get; set; }
        [Required]
        [Phone]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter 10 digit mobile number")]
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}