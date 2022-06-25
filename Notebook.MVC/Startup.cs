using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notebook.Application.Notes.Queries;
using Notebook.Core.Interfaces.Repositories;
using Notebook.Data;
using Notebook.Data.Repositories;
using Notebook.MVC.Extensions;

namespace Notebook.MVC
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
            services.AddControllersWithViews();
            services.AddDbContext<NotesDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("NotesDb"));
            });
            services.AddNotesServices(Configuration);
            services.AddIdentityServices(Configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));

            var context = services.BuildServiceProvider().GetService<NotesDbContext>();
            context.Database.Migrate();

            services.AddMediatR(typeof(GetNotesQueryHandler).Assembly);

            //services.AddIdentityCore<IdentityUser>(opt =>
            //{
            //    opt.Password.RequireDigit = true;
            //    opt.Password.RequiredLength = 6;
            //    opt.Password.RequireNonAlphanumeric = false;
            //    opt.Password.RequireUppercase = false;
            //    opt.Password.RequireLowercase = false;
            //})
            //    .AddRoles<IdentityRole>()
            //    .AddRoleManager<RoleManager<IdentityRole>>()
            //    .AddEntityFrameworkStores<UserDbContext>()
            //    .AddSignInManager<SignInManager<IdentityUser>>()
            //    .AddErrorDescriber<IdentityErrorDescriber>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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