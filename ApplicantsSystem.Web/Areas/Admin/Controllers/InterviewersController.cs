namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using Common.Admin.BindingModels;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Services.Admin;
    using System;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class InterviewersController : BaseAdminController
    {
        private readonly IAdminInterviewerService interviewers;

        public InterviewersController(IAdminInterviewerService interviewers)
        {
            this.interviewers = interviewers;
        }

        public async Task<IActionResult> All()
        {

            var interviewersModel = await this.interviewers.All();

            return View(interviewersModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInterviewerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.interviewers.Create(model);

            TempData.AddSuccessMessage(String.Format(AddInterviewertMessage, model.FirstName, model.LastName));

            return this.RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Details(string id)
        {
            var interviewer = await this.interviewers.Details(id);

            return View(interviewer);
        }

        public async Task<IActionResult> Remove(string id)
        {
            await this.interviewers.Remove(id);

            TempData.AddSuccessMessage(RemoveInterviewerMessage);

            return RedirectToAction(nameof(All));
        }
    }
}