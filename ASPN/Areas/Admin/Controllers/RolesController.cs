using ASPN.Domain;
using ASPN.Models;
using ASPN.Services;
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

        [HttpGet]
        public async Task<IActionResult> Register(CancellationToken ct)
        {
            return await Task.Run(() => View(), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRoleViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController());
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.ToString());
                }
            }

            return View(model);
        }

        public async Task<ActionResult<IQueryable<IdentityRole>>> Index(CancellationToken ct)
        {
            return await Task.Run(() => View(roleManager.Roles), ct);
        }

        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var role = roleManager.Roles.FirstOrDefault(x => x.Id == id.ToString());
            await roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController());
        }

        public async Task<IActionResult> Show(Guid id, CancellationToken ct)
        {
            IdentityRole role = id == default ? new IdentityRole() : roleManager.Roles.FirstOrDefault(x => x.Id == id.ToString());
            return await Task.Run(() => View(role), ct);
        }
    }
}
