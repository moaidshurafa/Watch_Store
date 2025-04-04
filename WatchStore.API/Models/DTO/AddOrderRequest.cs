namespace WatchStore.API.Models.DTO
{
    public class AddOrderRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
