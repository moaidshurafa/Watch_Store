namespace WatchStore.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }


        // navigation properties
        public Customer Customer { get; set; }
    }
}
