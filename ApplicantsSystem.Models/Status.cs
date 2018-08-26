namespace ApplicantsSystem.Models
{
    using System.Collections.Generic;

    public class Status
    {
        public Status()
        {
            this.Applicants = new List<AplicantStatus>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AplicantStatus> Applicants { get; set; }
    }
}
