using System;
using System.Collections.Generic;
using HummingBoxApp.API.Models;

namespace HummingBoxApp.API.Dtos
{
    public class OrderForCreationDto
    {
        public int UserId { get; set; }
        public ICollection<ItemForCreationDto> Items { get; set; }
        public DateTime Created { get; set; }
        public double Price { get; set; }

        public OrderForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}