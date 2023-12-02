using ASPN.Domain;
using ASPN.Domain.Entities;
using ASPN.Domain.Entities.Identity;
using ASPN.Models;
using ASPN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Controllers
{
    public class PageController : Controller
    {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> umgr;

        public PageController(DataManager dataMgr, UserManager<User> umgr)
        {
            this.dataMgr = dataMgr;
            this.umgr = umgr;
        }

        public async Task<IActionResult> Id(Guid id, CancellationToken ct)
        {
            var model = dataMgr.Pages.GetPage(id);
            PageViewModel page = new PageViewModel
            {
                Id = model.Id == default ? new Guid().ToString() : model.Id.ToString(),
                CodeWord = model.CodeWord,
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Author = String.IsNullOrEmpty(model.Author) ? umgr.GetUserAsync(User).Result.UserName : model.Author,
                CreatedAt = DateTime.UtcNow
            };
            return await Task.Run(() => View(page), ct);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
        {
            var model = id == default ? new Page() : dataMgr.Pages.GetPage(id);

            PageViewModel page = new PageViewModel
            {
                Id = model.Id == default ? new Guid().ToString() : model.Id.ToString(),
                CodeWord = model.CodeWord,
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Author = String.IsNullOrEmpty(model.Author) ? umgr.GetUserAsync(User).Result.UserName : model.Author,
                CreatedAt = DateTime.UtcNow
            };

            return await Task.Run(() => View(page), ct);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(PageViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                Page page = new Page
                {
                    Id = model.Id == default ? new Guid() : Guid.Parse(model.Id),
                    CodeWord = model.CodeWord,
                    Title = model.Title,
                    Description = model.Description,
                    Text = model.Text,
                    Author = String.IsNullOrEmpty(model.Author) ? umgr.GetUserAsync(User).Result.UserName : model.Author,
                    CreatedAt = DateTime.UtcNow
                };

                dataMgr.Pages.SavePage(page);
                return RedirectToAction(nameof(PageController.Id), nameof(PageController).CutController(), new
                {
                    id = page.Id
                });
            }

            return await Task.Run(() => View(model), ct);
        }
    }
}
