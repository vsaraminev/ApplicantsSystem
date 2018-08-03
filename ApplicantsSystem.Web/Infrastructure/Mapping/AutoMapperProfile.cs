namespace ApplicantsSystem.Web.Infrastructure.Mapping
{
    using ApplicantsSystem.Models;
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, AdminApplicantListingViewModel>();
            this.CreateMap<CreateApplicantBindingModel, User>();
        }
    }
}
