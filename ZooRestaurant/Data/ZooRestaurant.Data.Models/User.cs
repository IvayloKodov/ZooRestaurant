namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AddressModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Web.Common.Constants;

    public class User : IdentityUser
    {
        private ICollection<Image> images;

        public User()
        {
            this.images = new HashSet<Image>();
        }

        [Required]
        [StringLength(ValidationConstants.MaxUserNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ValidationConstants.MaxUserNameLength)]
        public string LastName { get; set; }
        
        public virtual Customer Customer { get; set; }

        public int DeliveryAddressId { get; set; }
        
        public virtual Address Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public  virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}