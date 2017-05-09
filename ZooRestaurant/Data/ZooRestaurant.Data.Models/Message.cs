namespace ZooRestaurant.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;
    using Web.Common.Enums;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.MaxContactNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ValidationConstants.MaxContactNameLength)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public MessageSubjectType Subject { get; set; }

        [Required]
        [StringLength(ValidationConstants.MaxMessageContentLength)]
        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public bool IsRead { get; set; }
    }
}