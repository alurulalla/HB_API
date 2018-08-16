using System;

namespace HummingBoxApp.API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }
        public DateTime Created { get; set; }
    }
}