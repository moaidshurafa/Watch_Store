namespace WatchStore.API.Models.DTO
{
    public class UpdateOrderRequestDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
