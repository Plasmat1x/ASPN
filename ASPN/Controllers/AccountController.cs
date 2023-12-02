using ASPN.Domain.Entities.Identity;
using ASPN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ASPN.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userMgr;
        private readonly SignInManager<User> signinMgr;
        private readonly RoleManager<Role> roleMgr;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this.userMgr = userManager;
            this.signinMgr = signInManager;
            this.roleMgr = roleManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var user = await userMgr.GetUserAsync(User);
            UserViewModel model = new UserViewModel
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                CreatedAt = user.CreatedAt,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };

            if (user != null)
            {
                var userRole = await userMgr.GetRolesAsync(user);

                bool check = (userRole.FirstOrDefault(x => x == "admin") == null ? false : true);

                if (check)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin", id = user.Id });
                }
            }

            return await Task.Run(() => View(model), ct);
        }

        [Authorize]
        public async Task<IActionResult> Logout(CancellationToken ct)
        {
            await signinMgr.SignOutAsync();
            return await Task.Run(() => RedirectToAction("Index", "Home"));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(CancellationToken ct)
        {
            return await Task.Run(() => View(), ct);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(SignupUserViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };

                var Result = await userMgr.CreateAsync(user, model.Password);

                userMgr.AddToRoleAsync(user, "default");

                if (Result.Succeeded)
                {
                    await signinMgr.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Account");
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(CancellationToken ct)
        {
            var user = await userMgr.GetUserAsync(User);

            if (user != null)
            {
                return RedirectToAction("Index", "Account");
            }

            return await Task.Run(() => View(new SigninUserViewModel()), ct);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(SigninUserViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                User user = await userMgr.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await signinMgr.SignOutAsync();
                    SignInResult result = await signinMgr.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return await Task.Run(() => RedirectToAction("Index", "Account"));
                    }
                }
                ModelState.AddModelError(nameof(SigninUserViewModel.Email), "Incorrect email or/and password");
            }
            return await Task.Run(() => View(model), ct);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(CancellationToken ct)
        {
            var user = await userMgr.GetUserAsync(User);

            var model = new EditUserViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday.Value,
            };

            return await Task.Run(() => View(model), ct);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditUserViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var user = await userMgr.GetUserAsync(User);

                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Birthday = model.Birthday;

                var result = await userMgr.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.ToString());
                }
            }

            return await Task.Run(() => View(model), ct);
        }
    }
}
