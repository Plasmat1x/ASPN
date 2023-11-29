using ASPN.Domain;
using ASPN.Models;
using ASPN.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsersController(DataManager dataManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.dataManager = dataManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ActionResult<IQueryable<IdentityUser>>> Index(CancellationToken ct)
        {
            return await Task.Run(() => View(userManager.Users), ct);
        }

        public async Task<IActionResult> Edit(CancellationToken ct)
        {
            return await Task.Run(() => View(), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditUserViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByIdAsync(id.ToString());

                user.PhoneNumber = model.PhoneNumber.IsNullOrEmpty() ? null : model.PhoneNumber;

                IdentityResult result = await userManager.UpdateAsync(user);
                IdentityResult roleresult = await userManager.AddToRoleAsync(user, model.Role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(UsersController.Index), nameof(UsersController).CutController());
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.ToString());
                }
            }
            return await Task.Run(() => View(model), ct);
        }

        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id.ToString());
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(UsersController.Index), nameof(UsersController).CutController());
        }

        public async Task<IActionResult> Show(Guid id, CancellationToken ct)
        {
            IdentityUser user = id == default ? new IdentityUser() : userManager.Users.FirstOrDefault(x => x.Id == id.ToString());
            return await Task.Run(() => View(user), ct);
        }
    }
}
