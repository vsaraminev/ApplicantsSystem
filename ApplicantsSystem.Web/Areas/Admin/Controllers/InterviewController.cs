using ApplicantsSystem.Common.Admin.ViewModels;

namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using ApplicantsSystem.Models;
    using Common.Admin.BindingModels;
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin;
    using Services.Interviewer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class InterviewController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminInterviewService interviews;
        private readonly IAdminApplicantService applicants;
        private readonly IInterviewerTestsService tests;
        private readonly IEmailSender emailSender;

        public InterviewController(
            IAdminInterviewService interviews,
            IAdminApplicantService applicants,
            IInterviewerTestsService tests,
        ApplicantsSystemDbContext dbContext,
            UserManager<User> userManager,
            IEmailSender emailSender)
        {
            this.interviews = interviews;
            this.applicants = applicants;
            this.tests = tests;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = await this.interviews.All(page);

            return View(new AdminInterviewsListingViewModel()
            {
                Interviews = model,
                TotalInterviews = await this.interviews.TotalAsync(),
                CurrentPage = page
            });
        }

        public IActionResult CreateOnline()
        {
            var allTests = this.tests.GetTests();

            return View(new CreateOnlineInterviewBindingModel
            {
                Applicants = this.applicants.GetApplicants(),
                Tests = allTests
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOnline(CreateOnlineInterviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.interviews.CreateOnline(model);

            var applicant = this.applicants.All().FirstOrDefault(a => a.Id == model.ApplicantId);

            var test = this.tests.GetByIdAsync(model.TestId);

            if (applicant == null || test == null)
            {
                return BadRequest();
            }

            var testLink = test.Url;

            var subject = EmailSubject;

            var message = String.Format(EmailMessage, testLink);
            
            await emailSender.SendEmailAsync(applicant.Email, subject, message);

            TempData.AddSuccessMessage(String.Format(SendTestMessage, test.Name, applicant.Email));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateInPerson()
        {
            return View(new CreateInPersonInterviewBindingModel
            {
                Applicants = this.applicants.GetApplicants(),
                Interviewers = await this.GetInterviewers(),
                StartTime = DateTime.UtcNow.ToLocalTime(),
                EndTime = DateTime.UtcNow.ToLocalTime().AddMinutes(30)
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateInPerson(CreateInPersonInterviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Applicants = this.applicants.GetApplicants();
                model.Interviewers = await this.GetInterviewers();
                return View(model);
            }

            await this.interviews.CreateInPerson(model);

            TempData.AddSuccessMessage(InterviewMessage); //TODO better success message!

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OnlineDetails(int id)
        {
            var interview = await this.interviews.OnlineDetails(id);

            if (interview == null)
            {
                return BadRequest();
            }

            return View(interview);
        }

        public async Task<IActionResult> InPersonDetails(int id)
        {
            var interview = await this.interviews.InPersonDetails(id);

            if (interview == null)
            {
                return BadRequest();
            }

            return View(interview);
        }

        [HttpPost]
        public async Task<IActionResult> SetTestResult(AdminSetApplicantTestResult model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            await this.interviews.SetTestResult(model);

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>> GetInterviewers()
        {
            var interviewers = await this.userManager
                .GetUsersInRoleAsync(InterviewerRole);

            var interviewersListItems = interviewers
                .Select(t => new SelectListItem
                {
                    Text = $"{t.FirstName} {t.LastName}",
                    Value = t.Id
                })
                .ToList();

            return interviewersListItems;
        }
    }
}