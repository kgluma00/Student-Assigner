using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sa.Repository;
using Sa.Repository.DI;
using Sa.Repository.Mappings;
using SA.Business.DI;
using SA.MVC.Mappings;

namespace SA.MVC
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
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.Name = "LoginCookie";
                    config.LoginPath = "/Home/NotFound";
                });

            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SAConnectionString")));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SaRepositoryMappingProfile());
                cfg.AddProfile(new ClientMappingProfile());

            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddRepositoriesCollection();
            services.AddBusinessServicesCollection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //who are you?
            app.UseAuthentication();

            //are you allowed?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
