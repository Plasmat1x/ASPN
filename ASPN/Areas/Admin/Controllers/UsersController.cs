using ASPN.Domain;
using ASPN.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;
        private readonly RoleManager<Role> roleMgr;

        public UsersController(DataManager dataMgr, UserManager<User> userMgr, RoleManager<Role> roleMgr)
        {
            this.dataMgr = dataMgr;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            return await Task.Run(() => View(), ct);
        }

        public async Task<IActionResult> User(Guid id, CancellationToken ct)
        {
            return await Task.Run(async () => View(await userMgr.FindByIdAsync(id.ToString())), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var user = await userMgr.FindByIdAsync(id.ToString());

            var result = await userMgr.DeleteAsync(user);

            if (result.Succeeded)
            {
                return await Task.Run(() => View(), ct);

            }
            return RedirectToAction("Index", "Users", new { area = "Admin" });
        }
    }
}
