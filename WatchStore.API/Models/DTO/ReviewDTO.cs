﻿namespace WatchStore.API.Models.DTO
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public Guid WatchId { get; set; }
        public Guid CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
