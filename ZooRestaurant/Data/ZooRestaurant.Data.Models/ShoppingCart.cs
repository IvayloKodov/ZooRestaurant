namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart
    {
        private ICollection<CartItem> _carts;

        public ShoppingCart()
        {
            this._carts = new HashSet<CartItem>();
        }

        [Key]
        [ForeignKey("Customer")]
        public string Id { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<CartItem> Carts
        {
            get { return this._carts; }
            set { this._carts = value; }
        }
    }
}