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
            var allTests = this.tests.All();

            return View(allTests);
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

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.tests.Details(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.tests.PrepareTestForEdit(id);

            if (model==null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, InterviewerTestEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.tests.Edit(id, model);

            TempData.AddSuccessMessage(EditTestDescriptionMessage);
            
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