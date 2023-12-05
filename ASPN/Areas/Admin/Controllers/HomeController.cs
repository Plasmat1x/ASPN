using ASPN.Domain;
using ASPN.Domain.Entities.Identity;
using ASPN.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers {
    [Area("Admin")]
    public class HomeController:Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;

        public HomeController(DataManager dataMgr, UserManager<User> userMgr) {
            this.userMgr = userMgr;
            this.dataMgr = dataMgr;
        }

        public async Task<IActionResult> Index(Guid id, CancellationToken ct) {
            var user = await userMgr.FindByIdAsync(id.ToString());

            var roles = await userMgr.GetRolesAsync(user);

            UserViewModel model = new UserViewModel {
                Id = Guid.Parse(user.Id),
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
                CreatedAt = user.CreatedAt,
                Roles = roles,
            };

            return await Task.Run(() => View(model), ct);
        }
    }
}
