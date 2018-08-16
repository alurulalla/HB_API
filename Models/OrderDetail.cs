using System;

namespace HummingBoxApp.API.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double QuantityPrice { get; set; }
        public DateTime Created { get; set; }
    }
}