﻿namespace ZooRestaurant.Data.Models.AddressModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        private ICollection<Neighborhood> _neighborhoods;

        public Town()
        {
            this._neighborhoods = new HashSet<Neighborhood>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Neighborhood> Neighborhoods
        {
            get { return this._neighborhoods; }
            set { this._neighborhoods = value; }
        }
    }
}