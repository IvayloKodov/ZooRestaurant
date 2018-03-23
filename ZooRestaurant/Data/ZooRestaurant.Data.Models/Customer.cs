namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; 
    using Web.Common.Constants;

    public class Customer
    {
        private ICollection<Order> _orders;

        public Customer()
        {
            this._orders = new HashSet<Order>();
        }

        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [StringLength(ValidationConstants.MaxCommentLength)]
        public string Comment { get; set; }

        public virtual User User { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this._orders; }
            set { this._orders = value; }
        }
    }
}