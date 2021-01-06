using Business.Service;
using Business.Service.Infrastructure;
using Data.BaseContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Base;
using Repository.ConCreate;
using Repository.Infrastructure;
using Repository.Infrastructure.Interface;
using ServiceBuilderUI.Models;
using System;
using ViewModel.Views;

namespace ServiceBuilderUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDbContext<ServiceBuilderContext>(options => options.UseMySql(appSettings.DefaultConnection, mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(3),
                errorNumbersToAdd: null);
            }));
            services.AddMvc();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                                                             .AddCookie(options =>
                                                             {
                                                                 options.LoginPath = "/Account/Login/";
                                                             });


            services.AddTransient(typeof(IEntityRepository<>), typeof(EFEntityRepositoryBase<>));
            services.AddScoped<IQuerableRepository, QuerableRepositoryBase>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileServiceCloudinary>();
            services.AddScoped<ILexiconService, LexiconService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IMailService, GmailMailService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ICacheService, CacheService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ILexiconRepository, LexiconRepository>();
            services.AddScoped<IServiceCategoryPropertyRepository, ServiceCategoryPropertyRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
            services.AddScoped<IServicePhotoRepository, ServicePhotoRepository>();
            services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
            services.AddScoped<IOtpTransactionRepository, OtpTransactionRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IRequestPropertyRepository, RequestPropertyRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IServiceRequestRelationRepository, ServiceRequestRelationRepository>();
            services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
            services.AddScoped<IOrderPaymentRequestRepository, OrderPaymentRequestRepository>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
