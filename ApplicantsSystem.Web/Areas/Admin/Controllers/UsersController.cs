using ApplicantsSystem.Models;

namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services.Admin;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using MyApplicants.Models;
    using Data;
    using Infrastructure;

    public class UsersController : BaseAdminController
    {
        private readonly MyApplicantsDbContext db;
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(MyApplicantsDbContext db, IAdminUserService users, UserManager<User> userManager)
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
        public async Task<IActionResult> Create(CreateUserBindingModel model)
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
