namespace ApplicantsSystem.Web.Areas.Interviewer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.Constants.WebConstants;

    [Area(InterviewerArea)]
    [Authorize(Roles = InterviewerRole)]
    public abstract class InterviewerController : Controller
    {
    }
}