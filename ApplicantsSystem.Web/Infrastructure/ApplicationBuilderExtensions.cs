namespace ApplicantsSystem.Web.Infrastructure
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using ApplicantsSystem.Models;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicantsSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                
                Task
                    .Run(async () =>
                    {
                        var adminName = AdministratorRole;

                        var roles = new[]
                        {
                            adminName,
                            InterviewerRole
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@mysite.com";

                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminEmail,
                                FirstName = "Admin",
                                LastName = "Admin"
                            };

                            await userManager.CreateAsync(adminUser, "admin123");
                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }

                        var interviewerEmail = "interviewer@mysite.com";

                        var interviewerUser = await userManager.FindByEmailAsync(interviewerEmail);

                        if (interviewerUser == null)
                        {
                            interviewerUser = new User
                            {
                                Email = interviewerEmail,
                                UserName = interviewerEmail,
                                FirstName = "Interviewer",
                                LastName = "Interviewer"
                            };

                            await userManager.CreateAsync(interviewerUser, "int123");
                            await userManager.AddToRoleAsync(interviewerUser, InterviewerRole);
                        }
                    })
                    .Wait();
            }

            return app;
        }
    }
}
