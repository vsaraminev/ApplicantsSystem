namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System;

    public class AllInterviewersListingViewModelRazor
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public static Func<User, AllInterviewersListingViewModelRazor> FromTest
        {
            get
            {
                return interviewer => new AllInterviewersListingViewModelRazor()
                {
                    Id = interviewer.Id,
                    FirstName = interviewer.FirstName,
                    LastName = interviewer.LastName
                };
            }
        }
    }
}
