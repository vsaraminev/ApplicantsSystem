namespace ApplicantsSystem.Web.Areas.Interviewer.Controllers
{
    using Common.Interviewer.BindingModels;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interviewer;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    [Area(InterviewerArea)]
    [Authorize(Roles = InterviewerRole)]
    public class FeedbacksController : Controller
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

            TempData.AddSuccessMessage(LeaveFeedbackMessage);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var feedback = await this.feedbacks.Details(id, this.User);

            return View(feedback);
        }
    }
}