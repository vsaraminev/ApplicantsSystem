namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static ApplicantsSystem.Models.Constants.DataConstants;

    public class CreateApplicantBindingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = UserFirstName)]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = UserLastName)]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Url]
        public string LinkedIn { get; set; }
    }
}
