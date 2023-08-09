using System;
using System.Collections.Generic;

namespace corsTesting.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Productname { get; set; } = null!;
        public int Stock { get; set; }
        public string Status { get; set; } = null!;
    }
}
