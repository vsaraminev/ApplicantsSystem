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
            this.Interviews = new List<InterviewInterviewer>();
            this.Feedbacks = new List<Feedback>();
        }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        public ICollection<InterviewInterviewer> Interviews { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
