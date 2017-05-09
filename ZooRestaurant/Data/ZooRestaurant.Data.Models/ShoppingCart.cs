namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        private ICollection<Cart> carts;

        public ShoppingCart()
        {
            this.carts = new HashSet<Cart>();
        }

        [Key]
        [ForeignKey("Customer")]
        public string Id { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Cart> Carts
        {
            get { return this.carts; }
            set { this.carts = value; }
        }
    }
}