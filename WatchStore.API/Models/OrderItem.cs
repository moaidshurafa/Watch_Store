namespace WatchStore.API.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid WatchId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        // navigation properties
        public Watch Watch { get; set; }
        public Order Order { get; set; }
    }
}
