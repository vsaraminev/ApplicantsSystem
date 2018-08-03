namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using ApplicantsSystem.Models;
    using Common.Admin.BindingModels;
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Admin;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly ApplicantsSystemDbContext db;
        private readonly IAdminApplicantService users;
        private readonly UserManager<User> userManager;

        public UsersController(ApplicantsSystemDbContext db, IAdminApplicantService users, UserManager<User> userManager)
        {
            this.db = db;
            this.users = users;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = this.users.All();

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

            var interviewer = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this.userManager.CreateAsync(interviewer, model.Password);

            await this.userManager.AddToRoleAsync(interviewer, WebConstants.InterviewerRole);

            this.db.Users.Add(interviewer);
            this.db.SaveChanges();

            return this.RedirectToAction(nameof(Index));
        }
    }
}
