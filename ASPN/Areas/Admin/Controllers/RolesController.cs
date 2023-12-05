using ASPN.Domain;
using ASPN.Domain.Entities.Identity;
using ASPN.Models;
using ASPN.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers {
    [Area("Admin")]
    public class RolesController:Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;
        private readonly RoleManager<Role> roleMgr;

        public RolesController(DataManager dataMgr, UserManager<User> userMgr, RoleManager<Role> roleMgr) {
            this.dataMgr = dataMgr;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task<IActionResult> Index(CancellationToken ct) {
            var roles = roleMgr.Roles;
            return await Task.Run(() => View(roles), ct);
        }

        public async Task<IActionResult> Role(Guid id, CancellationToken ct) {
            var role = await roleMgr.FindByIdAsync(id.ToString());
            return await Task.Run(() => View(role), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) {
            var role = await roleMgr.FindByIdAsync(id.ToString());

            var result = await roleMgr.DeleteAsync(role);

            if(result.Succeeded) {
                return await Task.Run(() => View(), ct);

            }
            return RedirectToAction(nameof(RolesController.Index), nameof(RolesController), new { area = "Admin" });
        }

        public async Task<IActionResult> Edit(Guid id, CancellationToken ct) {
            var role = id == default ? new Role() : await roleMgr.FindByIdAsync(id.ToString());
            return await Task.Run(() => View(role), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model, CancellationToken ct) {
            if(ModelState.IsValid) {
                if(await roleMgr.RoleExistsAsync(model.Name)) {
                    var role = await roleMgr.FindByNameAsync(model.Name);

                    role.Name = model.Name;
                    role.Description = model.Description;

                    var res = await roleMgr.UpdateAsync(role);

                    return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController(), new { area = "Admin" });
                }
                else {
                    var role = new Role {
                        Id = new Guid().ToString(),
                        Name = model.Name,
                        Description = model.Description
                    };

                    await roleMgr.CreateAsync(role);
                    return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController(), new { area = "Admin" });
                }
            }
            return await Task.Run(() => View(model), ct);
        }
    }
}
