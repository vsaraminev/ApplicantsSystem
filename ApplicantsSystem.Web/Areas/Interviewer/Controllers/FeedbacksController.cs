namespace ApplicantsSystem.Web.Areas.Interviewer.Controllers
{
    using Common.Interviewer.BindingModels;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interviewer;
    using System;
    using System.Threading.Tasks;

    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class FeedbacksController : InterviewerController
    {
        private readonly IInterviewerFeedbacksService feedbacks;

        public FeedbacksController(IInterviewerFeedbacksService feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public IActionResult Index()
        {
            var interviewerInterviews = this.feedbacks.Index(this.User);

            return View(interviewerInterviews);
        }

        [HttpGet]
        public IActionResult LeaveFeedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LeaveFeedback(InterviewerFeedbackBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.feedbacks.LeaveFeedback(model, this.User);

            TempData.AddSuccessMessage(String.Format(LeaveFeedbackMessage, model.Interview.Applicant.FirstName, model.Interview.Applicant.LastName));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var feedback = await this.feedbacks.Details(id, this.User);

            return View(feedback);
        }
    }
}