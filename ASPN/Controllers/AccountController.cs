using ASPN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [Authorize]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                var userRole = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();

                bool check = (userRole.FirstOrDefault(x => x == "admin") == null ? false : true);

                if (check)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }
            return await Task.Run(() => View(user), ct);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(CancellationToken ct)
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                return RedirectToAction("Index", "Account");
            }

            return await Task.Run(() => View(new LoginViewModel()), ct);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(model.Login);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return await Task.Run(() => RedirectToAction("Index", "Account"));
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Login), "Incorrect login or/and password");
            }
            return await Task.Run(() => View(model), ct);
        }

        [Authorize]
        public async Task<IActionResult> Logout(CancellationToken ct)
        {
            await signInManager.SignOutAsync();
            return await Task.Run(() => RedirectToAction("Index", "Home"));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CancellationToken ct)
        {
            return await Task.Run(() => View(), ct);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Login,
                    Email = model.Email,
                };

                var Result = await userManager.CreateAsync(user, model.Password);

                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Account", "Index");
                }
                else
                {
                    foreach (var Err in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Err.Description);
                    }
                }
            }

            return await Task.Run(() => View(model), ct);
        }
    }
}
