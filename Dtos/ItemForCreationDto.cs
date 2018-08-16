using System;

namespace HummingBoxApp.API.Dtos
{
    public class ItemForCreationDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double QuantityPrice { get; set; }
        public int Quantity { get; set; }
        public int ItemTypeId { get; set; }
        public DateTime Created { get; set; }

        public ItemForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}
