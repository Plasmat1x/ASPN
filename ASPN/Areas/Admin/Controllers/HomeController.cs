using ASPN.Domain;
using ASPN.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> userMgr;

        public HomeController(DataManager dataMgr, UserManager<User> userMgr)
        {
            this.userMgr = userMgr;
            this.dataMgr = dataMgr;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var user = await userMgr.GetUserAsync(User);

            return await Task.Run(() => View(user), ct);
        }
    }
}
