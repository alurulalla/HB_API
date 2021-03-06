using System;

namespace HummingBoxApp.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}