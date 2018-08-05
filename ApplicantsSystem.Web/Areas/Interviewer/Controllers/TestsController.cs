namespace ApplicantsSystem.Web.Areas.Interviewer.Controllers
{
    using Common.Interviewer.BindingModels;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interviewer;
    using System;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class TestsController : InterviewerController
    {
        private readonly IInterviewerTestsService tests;

        public TestsController(IInterviewerTestsService tests)
        {
            this.tests = tests;
        }

        public IActionResult All()
        {
            var tests = this.tests.All();

            return View(tests);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewerTestBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.tests.Create(model);

            TempData.AddSuccessMessage(String.Format(CreateTestMessage, model.Name));


            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.tests.Remove(id);

            TempData.AddSuccessMessage(RemoveTestMessage);

            return RedirectToAction(nameof(All));
        }
    }
}