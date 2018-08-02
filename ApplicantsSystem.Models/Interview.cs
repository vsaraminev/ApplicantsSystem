using System.ComponentModel.DataAnnotations;

namespace ApplicantsSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Interview
    {
        public Interview()
        {
            this.Feedbacks = new List<Feedback>();
            this.Interviewers = new List<InterviewInterviewer>();
        }

        public int Id { get; set; }

        [Required]
        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        [Required]
        public int TestId { get; set; }

        public Test Test { get; set; }

        public int ResultId { get; set; }

        public Result Result { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<InterviewInterviewer> Interviewers { get; set; }
    }
}
