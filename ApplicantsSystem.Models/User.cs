namespace ApplicantsSystem.Models
{
    using Constants;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        { 
            this.Interviews = new List<Interview>();
        }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        public bool IsHired { get; set; } 
        
        public ICollection<Interview> Interviews { get; set; }
    }
}
