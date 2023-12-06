using ASPN.Domain;
using ASPN.Models;
using ASPN.Services;

using Domain.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers {
    [Area("Admin")]
    public class RolesController: Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;
        private readonly RoleManager<Role> roleMgr;

        public RolesController(DataManager dataMgr, UserManager<User> userMgr, RoleManager<Role> roleMgr) {
            this.dataMgr = dataMgr;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task<IActionResult> Index(CancellationToken ct) {
            IEnumerable<RoleViewModel> model = new List<RoleViewModel>();

            foreach(var role in roleMgr.Roles) {
                model.Append(new RoleViewModel { Id = role.Id, Name = role.Name, Description = role.Description });
            }

            return View(model);
        }

        public async Task<IActionResult> Role(Guid id, CancellationToken ct) {
            var role = await roleMgr.FindByIdAsync(id.ToString());

            var model = new RoleViewModel {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) {
            var role = await roleMgr.FindByIdAsync(id.ToString());

            var result = await roleMgr.DeleteAsync(role);

            if(result.Succeeded) {
                return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController(), new { area = "Admin" });
            }
            return View();

        }

        public async Task<IActionResult> Edit(Guid id, CancellationToken ct) {
            var role = id == default ? new Role() : await roleMgr.FindByIdAsync(id.ToString());
            return View(role);
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
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description
                    };

                    await roleMgr.CreateAsync(role);
                    return RedirectToAction(nameof(RolesController.Index), nameof(RolesController).CutController(), new { area = "Admin" });
                }
            }
            return View(model);
        }
    }
}
