namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class AdminApplicantListingViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
