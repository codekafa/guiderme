using Business.Service;
using Business.Service.Common;
using Business.Service.Infrastructure;
using Data.BaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Base;
using Repository.ConCreate;

namespace ServiceBuilder
{
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


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ITokenEngine, TokenEngine>();

            services.AddControllers();
            services.AddDbContext<ServiceBuilderContext>(o => o.UseMySQL(Configuration.GetConnectionString("ServiceBuilderDB")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //      name: "default",
            //      pattern: "{controller=Werenda}/{action=Index}/{id?}");
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
