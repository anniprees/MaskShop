using System;

namespace BlazorApp.Shared.Models
{
    public class ProductCategory
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}