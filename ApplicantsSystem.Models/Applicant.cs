namespace ApplicantsSystem.Models
{
    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Applicant
    {
        public Applicant()
        {
            this.Interviews = new List<Interview>();
            this.Statuses = new List<AplicantStatus>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = DataConstants.UserFirstName)]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = DataConstants.UserLastName)]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(DataConstants.PhoneRegex)]
        public string Phone { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        public int CurrentStatus { get; set; }

        public ICollection<AplicantStatus> Statuses { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
