using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopApplication.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public double? TotalCost {
            get
            {
                double? totalCost=0;
                foreach (OrdersDetails details in this.OrdersDetails)
                {
                    totalCost += (details.Product.Price * details.Amount);
                }
                return totalCost;
            }
        }
        public virtual Clients Client { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
