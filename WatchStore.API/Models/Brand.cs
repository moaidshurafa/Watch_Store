﻿namespace WatchStore.API.Models
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string LogoUrl { get; set; }
    }
}
