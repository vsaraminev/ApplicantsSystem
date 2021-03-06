﻿namespace ApplicantsSystem.Web.Infrastructure.Mapping
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
            this.CreateMap<Interview, AdminOnlineInterviewDetailsViewModel>()
                .ForMember(i => i.ApplicantName, cfg => cfg.MapFrom(a => a.Applicant.FirstName + " " + a.Applicant.LastName));
            this.CreateMap<Interview, AdminInPersonInterviewDetailsViewModel>()
                .ForMember(i => i.ApplicantName, cfg => cfg.MapFrom(a => a.Applicant.FirstName + " " + a.Applicant.LastName));
            this.CreateMap<User, AdminInterviewerListingViewModel>();
            this.CreateMap<Interview, AdminInterviewsViewModel>()
                .ForMember(i => i.ApplicantName, cfg => cfg.MapFrom(a => a.Applicant.FirstName + " " + a.Applicant.LastName));
            this.CreateMap<InterviewInterviewer, InterviewerInterviewsListingModel>();
            this.CreateMap<Feedback, InterviewerFeedbackDetailsViewModel>();
            this.CreateMap<Test, InterviewerTestDetailsViewModel>();
            this.CreateMap<CreateApplicantBindingModel, Applicant>();
            this.CreateMap<CreateInterviewerBindingModel, User>();
            this.CreateMap<InterviewerTestBindingModel, Test>();
            this.CreateMap<CreateInPersonInterviewBindingModel, Interview>();
            this.CreateMap<CreateOnlineInterviewBindingModel, Interview>();
            this.CreateMap<InterviewerTestEditBindingModel, Test>();
        }
    }
}
