namespace ApplicantsSystem.Services.Admin.Implementations
{
    using ApplicantsSystem.Data;
    using ApplicantsSystem.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService : IAdminUserService
    {
        private readonly ApplicantsSystemDbContext db;
        private readonly IMapper mapper;

        public AdminUserService(ApplicantsSystemDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<AdminUserListingServiceModel> All()
        {
            return this.mapper.Map<IEnumerable<AdminUserListingServiceModel>>(this.db.Users.ToList());
        }
    }
}
