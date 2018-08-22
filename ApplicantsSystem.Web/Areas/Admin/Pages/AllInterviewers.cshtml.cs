namespace ApplicantsSystem.Web.Areas.Admin.Pages
{
    using ApplicantsSystem.Models;
    using Common.Admin.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AllInterviewersModel : PageModel
    {
        private readonly ApplicantsSystemDbContext db;
        private readonly UserManager<User> userManager;

        public AllInterviewersModel(ApplicantsSystemDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IEnumerable<AllInterviewersListingViewModelRazor> Interviewers { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var allInterviewers = await this.userManager.GetUsersInRoleAsync(InterviewerRole);

            this.Interviewers = allInterviewers
                .Select(i => new AllInterviewersListingViewModelRazor()
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName
                })
                .ToList();

            return Page();
        }
    }
}