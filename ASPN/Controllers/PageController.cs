using ASPN.Domain;
using ASPN.Domain.Entities;
using ASPN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Controllers
{
    public class PageController : Controller
    {
        private readonly DataManager dataMgr;

        public PageController(DataManager dataMgr)
        {
            this.dataMgr = dataMgr;
        }

        public async Task<IActionResult> Id(Guid id, CancellationToken ct)
        {
            return await Task.Run(() => View(dataMgr.Pages.GetPage(id)), ct);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Page page, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                dataMgr.Pages.SavePage(page);
                return RedirectToAction(nameof(PageController.Id), nameof(PageController).CutController(), new { id = page.Id });
            }

            return await Task.Run(() => View(page), ct);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
        {
            var entity = id == default ? new Page() : dataMgr.Pages.GetPage(id);

            return await Task.Run(() => View(entity), ct);
        }
    }
}
