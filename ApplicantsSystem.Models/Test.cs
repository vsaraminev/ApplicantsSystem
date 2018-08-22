namespace ApplicantsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ApplicantsSystem.Models.Constants.DataConstants;

    public class Test
    {
        public Test()
        {
            this.Interviews = new List<Interview>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(TestNameMinLength)]
        [MaxLength(TestNameMaxLength)]
        public string Name { get; set; }

        [MinLength(TestDescriptionMinLength)]
        [MaxLength(TestDescriptionMaxLength)]
        public string Description { get; set; }

        [Url]
        public string Url { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
