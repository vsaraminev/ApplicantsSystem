namespace ApplicantsSystem.Web.Areas.Admin.Pages
{
    using Common.Interviewer.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;

    public class AllTests : PageModel
    {
        private readonly ApplicantsSystemDbContext db;

        public AllTests(ApplicantsSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AllTestListingModel> Tests { get; set; }

        public IActionResult OnGet()
        {
            this.Tests = this.db
                .Tests
                .Select(AllTestListingModel.FromTest)
                .ToList();

            return Page();
        }
    }
}