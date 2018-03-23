namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Web.Common.Constants;

    public class CartItem
    {
        private ICollection<ShoppingCart> _shoppingCarts;

        public CartItem()
        {
            this._shoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(ValidationConstants.MaxMealNameLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalPrice => this.Quantity * this.Price;

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int MealId { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get { return this._shoppingCarts; }
            set { this._shoppingCarts = value; }
        }
    }
}