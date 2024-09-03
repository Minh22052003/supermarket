namespace APISuperMarket.DTOs
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public double Price { get; set; }
        public string? brandName { get; set; }
        public string? Description { get; set; }
        public DateTime Expiry { get; set; }
        public int InventoryQuantity { get; set; }
    }
}
