﻿namespace ApplicantsSystem.Web.Areas.Admin.Controllers
{
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Services.Admin;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class ApplicantsController : BaseAdminController
    {
        private readonly IAdminApplicantService applicants;

        public ApplicantsController(IAdminApplicantService applicants)
        {
            this.applicants = applicants;
        }

        public IActionResult Index()
        {
            var allApplicants = this.applicants.All();

            var model = allApplicants.Where(a => a.CurrentStatus == InInterviewStatusId).ToList();

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

            if (applicant == null)
            {
                return BadRequest();
            }

            return View(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(AdminChangeApplicantsStatus model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await this.applicants.ChangeStatus(model);
            }
            catch (Exception e)
            {
                if (e.InnerException is InvalidOperationException)
                {
                    return RedirectToAction(nameof(ChangeStatus));
                }

                throw e;
            }

            TempData.AddSuccessMessage(ChangeApplicantStatusMessage);

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

        public IActionResult HiredOrRejected(int page = 1)
        {
            var allApplicants = this.applicants.All();

            var model = allApplicants.Where(a => a.CurrentStatus != InInterviewStatusId).ToList();

            var statuses = this.applicants.GetStatuses();

            return View(new AdminApplicantIndexViewModel
            {
                Applicants = model,
                Statuses = statuses
            });
        }
    }
}
