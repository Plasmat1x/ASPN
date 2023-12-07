using ASPN.Domain;
using ASPN.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace ASPN.Controllers {
    public class HomeController: Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;
        public HomeController(ILogger<HomeController> logger, DataManager dataManager) {
            _logger = logger;
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Index(CancellationToken ct) {

            var model = await dataManager.Pages.GetPagesAsync(ct);
            model = model.OrderByDescending(x => x.CreatedAt);
            return View(model);
        }

        public async Task<IActionResult> Privacy(CancellationToken ct) {
            return View();
        }

        public async Task<IActionResult> About(CancellationToken ct) {
            return View(Program.About_info);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(CancellationToken ct) {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}