namespace ZooRestaurant.Web.Models.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ViewModels.ShoppingCart;

    public class CartSizeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList<CartViewModel>;
            return list?.Count > 0;
        }
    }
}