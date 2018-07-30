namespace ApplicantsSystem.Models
{
    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Test
    {
        public Test()
        {
            this.Interviews= new List<Interview>();
            //this.Results = new List<Result>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.TestNameMinLength)]
        [MaxLength(DataConstants.TestNameMaxLength)]
        public string Name { get; set; }

        [Url]
        public string Url { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
