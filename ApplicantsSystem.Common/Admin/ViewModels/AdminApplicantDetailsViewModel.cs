namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class AdminApplicantDetailsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string LinkedIn { get; set; }

        public bool IsHired { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
