using System;
using System.Collections.Generic;

namespace HummingBoxApp.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public double Price { get; set; }
    }
}