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
    using Microsoft.EntityFrameworkCore;
    using Services.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class InterviewController : BaseAdminController
    {
        private readonly ApplicantsSystemDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly IAdminInterviewService interviews;
        private readonly IEmailSender emailSender;

        public InterviewController(
            IAdminInterviewService interviews,
            ApplicantsSystemDbContext dbContext,
            UserManager<User> userManager,
            IEmailSender emailSender)
        {
            this.interviews = interviews;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var model = this.interviews.All();

            return View(model);
        }

        public async Task<IActionResult> CreateOffSite()
        {
            var tests = await this.dbContext
                .Tests
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
                .ToListAsync();

            return View(new CreateOffsiteInterviewBindingModel
            {
                Applicants = await this.GetApplicants(),
                Tests = tests
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffSite(CreateOffsiteInterviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.interviews.CreateOffSite(model);

            //var user = await this.dbContext.Applicants.FirstOrDefaultAsync(a => a.Id == model.ApplicantId);

            //var test = await this.dbContext.Tests.FirstOrDefaultAsync(t => t.Id == model.TestId);

            //var testLink = test.Url;

            //var subject = EmailSubject;

            //var message = String.Format(EmailMessage, testLink);

            //await emailSender.SendEmailAsync(user.Email, subject, message);

            //TempData.AddSuccessMessage(String.Format(SendTestMessage, test.Name, user.Email));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateOnSite()
        {
            return View(new CreateOnsiteInterviewBindingModel
            {
                Applicants = await this.GetApplicants(),
                Interviewers = await this.GetInterviewers(),
                StartTime = DateTime.UtcNow.ToLocalTime(),
                EndTime = DateTime.UtcNow.ToLocalTime().AddMinutes(30)
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOnSite(CreateOnsiteInterviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Applicants = await this.GetApplicants();
                model.Interviewers = await this.GetInterviewers();
                return View(model);
            }

            await this.interviews.CreateOnSite(model);

            TempData.AddSuccessMessage(InterviewMessage); //TODO better success message!

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var interview = await this.interviews.Details(id);

            return View(interview);
        }
        
        [HttpPost]
        public async Task<IActionResult> SetTestResult(AdminSetApplicantTestResult model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var interview = await this.dbContext.Interviews.FindAsync(model.InterviewId);

            interview.Result = new Result()
            {
                InterviewId = interview.Id
            };
            
            if (interview.ApplicantId != model.ApplicantId)
            {
                return NotFound();
            }

            interview.Result.ResultUrl = model.ResultUrl;

            await this.dbContext.SaveChangesAsync();
            
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

        private async Task<IEnumerable<SelectListItem>> GetApplicants()
        {
            return await this.dbContext
                .Applicants
                .Select(t => new SelectListItem
                {
                    Text = $"{t.FirstName} {t.LastName}",
                    Value = t.Id.ToString()
                })
                .ToListAsync();
        }
    }
}