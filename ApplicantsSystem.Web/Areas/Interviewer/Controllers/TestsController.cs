namespace ApplicantsSystem.Web.Areas.Interviewer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Common.Interviewer.BindingModels;

    public class TestsController : InterviewerController
    {
        public IActionResult All()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InterviewerTestBindingModel model)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            return View();
        }
    }
}