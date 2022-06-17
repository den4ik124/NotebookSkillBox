using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Notebook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseIdentityController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public BaseIdentityController(UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public UserManager<IdentityUser> UserManager => userManager;

        public RoleManager<IdentityRole> RoleManager => roleManager;
    }
}