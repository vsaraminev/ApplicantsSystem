namespace ApplicantsSystem.Services.Admin
{
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();
    }
}
