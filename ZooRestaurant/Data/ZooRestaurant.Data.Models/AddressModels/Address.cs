namespace ZooRestaurant.Data.Models.AddressModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        private ICollection<User> _users;

        public Address()
        {
            this._users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AdditionalAddress { get; set; }

        public int NeighborhoodId { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this._users; }
            set { this._users = value; }
        }

        public override string ToString()
        {
            return $"гр. {this.Neighborhood.Town.Name},кв. {this.Neighborhood.Name}, {this.AdditionalAddress}";
        }
    }
}