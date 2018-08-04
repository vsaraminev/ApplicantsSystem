namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using Common.Admin.BindingModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Admin;
    using System.Threading.Tasks;

    public class ApplicantsController : BaseAdminController
    {
        private readonly IAdminApplicantService applicants;

        public ApplicantsController(IAdminApplicantService applicants)
        {
            this.applicants = applicants;
        }

        public IActionResult Index()
        {
            var model = this.applicants.ApplicantsAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateApplicantBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.applicants.Create(model);

            // TODO : Message for successfully create applicant! 

            return this.RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Details(int id)
        {
            var applicant = await this.applicants.Details(id);

            return View(applicant);
        }

        public async Task<IActionResult> Hire(int id)
        {
            await this.applicants.Hire(id);

            // TODO : Message for hired applicant! 

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.applicants.Remove(id);

            // TODO : Alert Message for removed applicant! 

            return this.RedirectToAction(nameof(Index));
        }
    }
}
