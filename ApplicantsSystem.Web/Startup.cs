namespace ApplicantsSystem.Web
{
    using ApplicantsSystem.Models;
    using AutoMapper;
    using Data;
    using Email;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Admin;
    using Services.Admin.Implementation;
    using Services.Interviewer;
    using Services.Interviewer.Implementation;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddResponseCaching();

            services.AddDbContext<ApplicantsSystemDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequireLowercase = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                })
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicantsSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services.AddSingleton<IEmailSender, SendGridEmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.SeedDatabase();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseResponseCaching();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name:"Identity",
                //    template:"Identity/Account/Login",
                //    defaults: new {area = "Identity", controller="Account", action="Login"}
                //    );
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IAdminApplicantService, AdminApplicantService>();
            services.AddScoped<IAdminInterviewerService, AdminInterviewerService>();
            services.AddScoped<IInterviewerTestsService, InterviewerTestsService>();
            services.AddScoped<IAdminInterviewService, AdminInterviewService>();
            services.AddScoped<IInterviewerFeedbacksService, InterviewerFeedbacksService>();
        }
    }
}
