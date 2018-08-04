namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class AdminInterviewerDetailsViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<InterviewInterviewer> Interviews { get; set; }
    }
}
