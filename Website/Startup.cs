using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Website.CustomIdentity;
using Website.Repository.Abstract;
using Website.Repository.Concrete;
using Website.Repository.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Website
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

            services.AddScoped<IUrunRepository, EfUrunRepository>();
            //services.AddScoped<IUrunResimRepository,EfUrunResimRepository>();
            services.AddScoped<IUrunGrupRepository, EfUrunGrupRepository>();
            services.AddScoped<IBlogRepository, EfBlogRepository>();
            services.AddScoped<IKategoriRepository, EfKategoriRepository>();
            services.AddScoped<IResimRepository, EfResimRepository>();
            services.AddScoped<IVideoRepository, EfVideoRepository>();
            services.AddScoped<IEtiketRepository, EfEtiketRepository>();
            services.AddScoped<IYaziRepository, EfYaziRepository>();
            services.AddScoped<ISliderRepository, EfSliderRepository>();
            services.AddScoped<ISSSRepository, EfSSSRepository>();
            services.AddScoped<IAyarRepository, EfAyarRepository>();

           
            services.AddDbContext<WebsiteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true; //Parolada sayı olsun.
                options.Password.RequiredLength = 6; // minimum 6 karakter olsun.

                options.Lockout.MaxFailedAccessAttempts = 5; // Şifre denemesi max 5 olsun sonra kilitlensin.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Ard arda yanlış şifrede kilitlensin.
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".AspNetCoreDemo.Account.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });

            services.AddSession();
            services.AddDistributedMemoryCache();


            services.AddSingleton<IFileProvider>(
           new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc();

           


            app.UseStatusCodePages();   
            
            //app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Admin}/{action=Index}/{id?}");
            });
            //SeedData.Seed(app);
        }
    }
}
