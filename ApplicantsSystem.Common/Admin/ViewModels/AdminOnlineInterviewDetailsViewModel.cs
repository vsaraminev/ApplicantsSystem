namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;
    using System;

    public class AdminOnlineInterviewDetailsViewModel
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; }

        public int? TestId { get; set; }

        public Test Test { get; set; }

        public Result Result { get; set; }

        public DateTime StartTime { get; set; }
    }
}
