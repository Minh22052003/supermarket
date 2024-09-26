namespace APISuperMarket.DTOs
{
    public class OrderDTO
    {
        public int CustomerID { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public int AddressID { get; set; }
        public int? DiscountCodeId { get; set; }
        public DateTime? OrderDate { get; set; }

    }
}
