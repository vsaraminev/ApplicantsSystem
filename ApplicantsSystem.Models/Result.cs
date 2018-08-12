namespace ApplicantsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Result
    {
        public int Id { get; set; }

        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        [Url]
        public string ResultUrl { get; set; }
    }
}
