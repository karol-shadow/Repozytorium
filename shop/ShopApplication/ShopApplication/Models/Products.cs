using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopApplication.Models
{
    public partial class Products
    {
        public Products()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
