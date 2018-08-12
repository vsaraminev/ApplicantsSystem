namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AdminChangeApplicantsStatus
    {
        [Required]
        public int ApplicantId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
