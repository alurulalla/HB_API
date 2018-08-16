using System;
using System.Collections.Generic;
using HummingBoxApp.API.Models;

namespace HummingBoxApp.API.Dtos
{
    public class HistoryListDto
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public double price { get; set; }
        public ICollection<ReturnHistoryItemDto> items { get; set; }
        public DateTime created { get; set; }
    }
}