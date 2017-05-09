namespace ZooRestaurant.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        private ICollection<OrderDetails> ordersDetails;

        public Order()
        {
            this.ordersDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryTax { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrdersDetails
        {
            get { return this.ordersDetails; }
            set { this.ordersDetails = value; }
        }
    }
}