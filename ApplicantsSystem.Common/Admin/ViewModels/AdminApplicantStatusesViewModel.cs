namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class AdminApplicantStatusesViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<AplicantStatus> Statuses { get; set; }
    }
}
