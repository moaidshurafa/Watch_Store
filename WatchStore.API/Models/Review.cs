﻿namespace WatchStore.API.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid WatchId { get; set; }
        public Guid CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
