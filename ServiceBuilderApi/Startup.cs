

using Business.Service;
using Business.Service.Common;
using Business.Service.Infrastructure;
using Data.BaseContext;
using GuiderMeApi.Attrubutes.BaseAttr;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Base;
using Repository.ConCreate;
using Repository.Infrastructure;
using Repository.Infrastructure.Interface;
using System;
using System.Text;
using ViewModel.Core;
using ViewModel.Views;

namespace GuiderMeApi
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


            services.AddControllers();
            services.AddCors();

            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            services.AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                         In = ParameterLocation.Header,
                         Name = "Authorization",
                         Type = SecuritySchemeType.ApiKey,

                    },new string[] {}
                }});
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    },
                });
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
            services.AddScoped<IPaymentService, PaymentService>();


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
            services.AddScoped<IExceptionManager, ExceptionService>();


            services.AddScoped<IWebContext,WebContext>();
            services.AddScoped<ServiceMethodAuth>();
            services.AddScoped<ITokenEngine, TokenService>();
            IOC.CurrentProvider = services.BuildServiceProvider();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
