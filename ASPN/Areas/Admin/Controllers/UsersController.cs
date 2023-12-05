using ASPN.Domain;
using ASPN.Domain.Entities.Identity;
using ASPN.Models;
using ASPN.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers {
    [Area("Admin")]
    public class UsersController:Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;
        private readonly RoleManager<Role> roleMgr;

        public UsersController(DataManager dataMgr, UserManager<User> userMgr, RoleManager<Role> roleMgr) {
            this.dataMgr = dataMgr;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task<IActionResult> Index(CancellationToken ct) {
            return await Task.Run(() => View(userMgr.Users), ct);
        }

        public async Task<IActionResult> User(Guid id, CancellationToken ct) {
            var user = await userMgr.FindByIdAsync(id.ToString());

            UserViewModel model = new UserViewModel {
                Id = Guid.Parse(user.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                CreatedAt = user.CreatedAt,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };

            model.Roles = await userMgr.GetRolesAsync(user);

            return await Task.Run(async () => View(model), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) {
            var user = await userMgr.FindByIdAsync(id.ToString());

            var result = await userMgr.DeleteAsync(user);

            if(result.Succeeded) {
                return await Task.Run(() => View(), ct);

            }

            return RedirectToAction("Index", "Users", new { area = "Admin" });
        }


        /*
        public async Task<IActionResult> AddRole(Guid id, CancellationToken ct)
        {
            var user = await userMgr.FindByIdAsync(id.ToString());

            List<UserRoleViewModel> list = new List<UserRoleViewModel>();

            foreach (var role in roleMgr.Roles)
            {
                UserRoleViewModel URVM;

                if (await userMgr.IsInRoleAsync(user, role.Name))
                {
                    URVM = new UserRoleViewModel { Id = id, UserName = user.UserName, RoleName = role.Name, IsSelected = true };
                }
                else
                {
                    URVM = new UserRoleViewModel { Id = id, UserName = user.UserName, RoleName = role.Name, IsSelected = false };
                }

                list.Add(URVM);
            }

            return await Task.Run(() => View(list), ct);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(IEnumerable<UserRoleViewModel> list, Guid id, CancellationToken ct)
        {

            var user = await userMgr.FindByIdAsync(id.ToString());

            if (ModelState.IsValid)
            {
                List<string> inroles = new List<string>();
                List<string> exroles = new List<string>();

                foreach (var entt in list)
                {
                    if (entt.IsSelected)
                        inroles.Append(entt.RoleName);
                    else
                        exroles.Append(entt.RoleName);
                }

                var exres = await userMgr.RemoveFromRolesAsync(user, exroles);
                var inres = await userMgr.AddToRolesAsync(user, inroles);

                if (exres.Succeeded && inres.Succeeded)
                {
                    return RedirectToAction(nameof(UsersController.User), nameof(UsersController).CutController(), new { area = "Admin", Id = id });
                }
            }

            return await Task.Run(() => View(list), ct);
        }
        */

        public async Task<IActionResult> AddRole(Guid id, CancellationToken ct) {
            var user = await userMgr.FindByIdAsync(id.ToString());

            var model = new UserRolesViewModel();

            model.Id = id;
            model.UserName = user.UserName;
            model.RoleChecked = new Dictionary<string, bool>();

            foreach(var role in roleMgr.Roles) {
                if(await userMgr.IsInRoleAsync(user, role.Name)) {
                    model.RoleChecked[role.Name] = true;
                }
                else {
                    model.RoleChecked[role.Name] = false;
                }
            }

            return await Task.Run(() => View(model), ct);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserRolesViewModel model, CancellationToken ct) {
            var user = await userMgr.FindByIdAsync(model.Id.ToString());

            if(ModelState.IsValid) {
                var inroles = new List<string>();
                var exroles = new List<string>();

                foreach(var rc in model.RoleChecked) {
                    if(rc.Value == false)
                        exroles.Add(rc.Key);
                    else
                        inroles.Add(rc.Key);
                }

                foreach(var role in exroles) {
                    await userMgr.RemoveFromRoleAsync(user, role);
                }
                foreach(var role in inroles) {
                    await userMgr.AddToRoleAsync(user, role);
                }

                return RedirectToAction(nameof(UsersController.User), nameof(UsersController).CutController(), new { area = "Admin", Id = user.Id });
            }

            return await Task.Run(() => View(model), ct);
        }
    }
}
