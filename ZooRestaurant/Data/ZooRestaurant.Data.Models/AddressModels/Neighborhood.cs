namespace ZooRestaurant.Data.Models.AddressModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Neighborhood
    {
        private ICollection<Address> addresses;

        public Neighborhood()
        {
            this.addresses = new HashSet<Address>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return this.addresses; }
            set { this.addresses = value; }
        }
    }
}