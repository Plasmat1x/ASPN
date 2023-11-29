using ASPN.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RolesController(DataManager dataManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.dataManager = dataManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ActionResult<IQueryable<IdentityRole>>> Index(CancellationToken ct)
        {
            return await Task.Run(() => View(roleManager.Roles), ct);
        }

    }
}
