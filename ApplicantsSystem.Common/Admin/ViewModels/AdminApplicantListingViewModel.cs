namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class AdminApplicantListingViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int CurrentStatus { get; set; }

        public string Phone { get; set; }

        public string LinkedIn { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
