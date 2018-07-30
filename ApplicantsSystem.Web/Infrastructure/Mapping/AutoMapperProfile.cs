namespace ApplicantsSystem.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using ApplicantsSystem.Models;
    using Services.Admin;
    using Areas.Admin.Models.Users;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, AdminUserListingServiceModel>();
            this.CreateMap<CreateUserBindingModel, User>();
        }
    }
}
