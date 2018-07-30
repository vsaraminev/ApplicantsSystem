namespace ApplicantsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Interview
    {
        public Interview()
        {
            this.Interviewers = new List<InterviewInterviewer>();
        }

        public int Id { get; set; }

        [Required]
        public string ApplicantId { get; set; }

        public User Applicant { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required]
        public int TestId { get; set; }

        public Test Test { get; set; }

        public int ResultId { get; set; }

        public Result Result { get; set; }
        
        public ICollection<InterviewInterviewer> Interviewers { get; set; }
    }
}
