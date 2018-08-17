namespace ApplicantsSystem.Web.Infrastructure.Mapping
{
    using ApplicantsSystem.Models;
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<AplicantStatus, AdminApplicantStatusesViewModel>()
                .ForMember(a => a.ApplicantName, cfg => cfg.MapFrom(s => s.Applicant.FirstName + " " + s.Applicant.LastName))
                .ForMember(a => a.StatusName, cfg => cfg.MapFrom(s => s.Status.Name));
            this.CreateMap<User, AdminInterviewerListingViewModel>();
            this.CreateMap<Interview, AdminInterviewsListingViewModel>()
                .ForMember(i => i.ApplicantName, cfg => cfg.MapFrom(a => a.Applicant.FirstName + " " + a.Applicant.LastName));
            this.CreateMap<Interview, AdminInterviewDetailsViewModel>();
            this.CreateMap<InterviewInterviewer, InterviewerInterviewsListingModel>();
            this.CreateMap<Feedback, InterviewerFeedbackDetailsViewModel>();
            this.CreateMap<CreateApplicantBindingModel, Applicant>();
            this.CreateMap<CreateInterviewerBindingModel, User>();
            this.CreateMap<InterviewerTestBindingModel, Test>();
            this.CreateMap<CreateOnsiteInterviewBindingModel, Interview>();
            this.CreateMap<CreateOffsiteInterviewBindingModel, Interview>();
        }
    }
}
