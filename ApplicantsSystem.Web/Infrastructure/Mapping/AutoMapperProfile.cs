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
            //this.CreateMap<Applicant, AdminApplicantListingViewModel>();
            this.CreateMap<User, AdminInterviewerListingViewModel>();
            //this.CreateMap<Interview, AdminInterviewsListingViewModel>();
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
