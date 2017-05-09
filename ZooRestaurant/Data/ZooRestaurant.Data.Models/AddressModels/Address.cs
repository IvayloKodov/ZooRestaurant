namespace ZooRestaurant.Data.Models.AddressModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        private ICollection<User> users;

        public Address()
        {
            this.users = new HashSet<User>();
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
            get { return this.users; }
            set { this.users = value; }
        }

        public override string ToString()
        {
            return string.Format("гр. {0},кв. {1}, {2}",
                this.Neighborhood.Town.Name, this.Neighborhood.Name, this.AdditionalAddress);
        }
    }
}