namespace ApplicantsSystem.Models
{
    using System;

    public class AplicantStatus
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public DateTime Time { get; set; }
    }
}
