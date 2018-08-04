using ApplicantsSystem.Common.Admin.ViewModels;
using ApplicantsSystem.Common.Interviewer.BindingModels;

namespace ApplicantsSystem.Web.Infrastructure.Mapping
{
    using ApplicantsSystem.Models;
    using AutoMapper;
    using Common.Admin.BindingModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //this.CreateMap<Applicant, AdminApplicantListingViewModel>();
            this.CreateMap<User, AdminInterviewerListingViewModel>();
            this.CreateMap<CreateApplicantBindingModel, Applicant>();
            this.CreateMap<CreateInterviewerBindingModel, User>();
            this.CreateMap<InterviewerTestBindingModel, Test>();
        }
    }
}
