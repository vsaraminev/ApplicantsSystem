namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class AdminApplicantInterviewsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
