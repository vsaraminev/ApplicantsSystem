namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Admin;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class ApplicantsController : BaseAdminController
    {
        private readonly ApplicantsSystemDbContext db;
        private readonly IAdminApplicantService applicants;

        public ApplicantsController(ApplicantsSystemDbContext db, IAdminApplicantService applicants, IMemoryCache cache)
        {
            this.db = db;
            this.applicants = applicants;
        }

        public IActionResult Index()
        {
            var allApplicants = this.applicants.ApplicantsAll();

            var inIntreviewStatusId = this.db.Statuses.FirstOrDefault(s => s.Name == InInterviewStatus).Id;

            var model = allApplicants.Where(a => a.CurrentStatus == inIntreviewStatusId).ToList();

            var statuses = this.applicants.GetStatuses();

            return View(new AdminApplicantIndexViewModel
            {
                Applicants = model,
                Statuses = statuses
            });
        }

        public IActionResult HiredOrRejected()
        {
            var allApplicants = this.applicants.ApplicantsAll();

            var inIntreviewStatusId = this.db.Statuses.FirstOrDefault(s => s.Name == InInterviewStatus).Id;

            var model = allApplicants.Where(a => a.CurrentStatus != inIntreviewStatusId).ToList();

            var statuses = this.applicants.GetStatuses();

            return View(new AdminApplicantIndexViewModel
            {
                Applicants = model,
                Statuses = statuses
            });
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

            TempData.AddSuccessMessage(string.Format(AddApplicantMessage, model.FirstName, model.LastName));

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var applicant = await this.applicants.Details(id);

            return View(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(AdminChangeApplicantsStatus model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.applicants.ChangeStatus(model);

            TempData.AddSuccessMessage(ChangeApplicantStatusMessage); //TODO: To finish success message


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetStatuses(int id)
        {
            var statuses = await this.applicants.GetStatuses(id);

            return View(statuses);
        }

        public async Task<IActionResult> GetInterviews(int id)
        {
            var interviews = await this.applicants.GetInterviews(id);

            return View(interviews);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.applicants.Remove(id);

            TempData.AddSuccessMessage(RemoveApplicantMessage);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
