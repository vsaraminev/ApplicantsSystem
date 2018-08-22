namespace ApplicantsSystem.Common.Interviewer.ViewModels
{
    using Models;
    using System;

    public class AllTestListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public static Func<Test, AllTestListingModel> FromTest
        {
            get
            {
                return test => new AllTestListingModel()
                {
                    Id = test.Id,
                    Name = test.Name,
                    Url = test.Url
                };
            }
        }
    }
}
