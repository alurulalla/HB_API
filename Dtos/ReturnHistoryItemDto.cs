namespace HummingBoxApp.API.Dtos
{
    public class ReturnHistoryItemDto
    {
        public int OrderId { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double QuantityPrice { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
    }
}