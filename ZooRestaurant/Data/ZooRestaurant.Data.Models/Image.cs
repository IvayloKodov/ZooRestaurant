namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; 
    using Web.Common.Constants;

    public class Image
    {
        private ICollection<CartItem> _carts;

        public Image()
        {
            this._carts = new HashSet<CartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxFileExtensionLength)]
        public string FileExtension { get; set; }

        public byte[] Content { get; set; }

        public string UrlPath { get; set; }

        public virtual Meal Meal { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> Carts
        {
            get { return this._carts; }
            set { this._carts = value; }
        }
    }
}