using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notebook.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            //    services.AddDbContext<>(opt =>
            //    {
            //        opt.UseSqlServer(config.GetConnectionString("UsersDb"));
            //    });

            //    services.AddIdentityCore<CustomIdentityUser>(opt =>
            //    {
            //        opt.Password.RequireDigit = true;
            //        opt.Password.RequiredLength = 6;
            //        opt.Password.RequireNonAlphanumeric = false;
            //        opt.Password.RequireUppercase = false;
            //        opt.Password.RequireLowercase = false;
            //    })
            //        .AddRoles<CustomRoles>()
            //        .AddRoleManager<RoleManager<CustomRoles>>()
            //        .AddEntityFrameworkStores<UserDbContext>()
            //        .AddSignInManager<SignInManager<CustomIdentityUser>>()
            //        .AddErrorDescriber<CustomIdentityErrorDescriber>();

            //    services.Configure<AuthTokenParameters>(config.GetSection("Authentication:Token"));

            //    var authTokenParameters = new AuthTokenParameters();
            //    config.Bind("Authentication:Token", authTokenParameters);

            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authTokenParameters.SigningKey));

            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            //        {
            //            opt.SaveToken = true;
            //            opt.RequireHttpsMetadata = true;
            //            opt.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuerSigningKey = true,
            //                IssuerSigningKey = key,
            //                ValidateIssuer = true,
            //                ValidIssuer = authTokenParameters.Issuer,
            //                ValidateAudience = true,
            //                ValidAudience = authTokenParameters.Audience,
            //                //ValidateLifetime = true,
            //                //ClockSkew = TimeSpan.Zero
            //            };
            //        });

            //    services.AddAuthorization(opt =>
            //    {
            //        opt.AddPolicy(nameof(Policies.AdminAccess), policy => policy.RequireRole(nameof(Roles.Admin)));
            //        opt.AddPolicy(nameof(Policies.ManagerAccess), policy => policy.RequireAssertion(context =>
            //                                context.User.IsInRole(nameof(Roles.Admin)) ||
            //                                context.User.IsInRole(nameof(Roles.Bot)) ||
            //                                context.User.IsInRole(nameof(Roles.Manager))));
            //        opt.AddPolicy(nameof(Policies.CustomerAccess), policy => policy.RequireAssertion(context =>
            //                                context.User.IsInRole(nameof(Roles.Admin)) ||
            //                                context.User.IsInRole(nameof(Roles.Manager)) ||
            //                                context.User.IsInRole(nameof(Roles.Customer))));
            //    });

            //    services.AddTransient<ISeedEmployees, SeedEmployees>();

            //    services.AddScoped<TokenService>();

            return services;
        }
    }
}