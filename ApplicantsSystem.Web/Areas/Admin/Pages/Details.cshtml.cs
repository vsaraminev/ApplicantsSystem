namespace ApplicantsSystem.Web.Areas.Admin.Pages
{
    using ApplicantsSystem.Models;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class DetailsModel : PageModel
    {
        private readonly ApplicantsSystemDbContext db;
        private readonly UserManager<User> userManager;

        public DetailsModel(ApplicantsSystemDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public User Interviewer { get; set; }

        public IEnumerable<InterviewInterviewer> Interviews { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            var allInterviewers = await this.userManager.GetUsersInRoleAsync(InterviewerRole);

            this.Interviewer = allInterviewers.FirstOrDefault(i => i.Id == id);

            if (this.Interviewer == null)
            {
                return NotFound();
            }

            this.Interviews = this.db.InterviewInterviewers
                .Where(i => i.InterviewerId == id)
                .ToList();

            return Page();
        }
    }
}