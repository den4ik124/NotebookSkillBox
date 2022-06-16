using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notebook.Core.Interfaces.Repositories;
using Notebook.Data;
using Notebook.Data.Repositories;

namespace Notebook.Extensions
{
    public static class NotesServicesExtensions
    {
        public static IServiceCollection AddNotesServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NotesDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("NotesDb"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddMediatR(typeof().Assembly);

            return services;
        }
    }
}