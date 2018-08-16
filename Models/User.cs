using System;

namespace HummingBoxApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public double WalletBalance { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}