using System;
using System.Collections.Generic;
using System.Text;

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