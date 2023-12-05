using ASPN.Domain;
using ASPN.Domain.Entities;
using ASPN.Domain.Entities.Identity;
using ASPN.Models;
using ASPN.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Controllers {
    public class PageController:Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> umgr;

        public PageController(DataManager dataMgr, UserManager<User> umgr) {
            this.dataMgr = dataMgr;
            this.umgr = umgr;
        }

        public async Task<IActionResult> Id(Guid id, CancellationToken ct) {
            var page = await dataMgr.Pages.GetPageAsync(id, ct);

            PageViewModel model = new PageViewModel {
                Id = page.Id.ToString(),
                CodeWord = page.CodeWord,
                Title = page.Title,
                Description = page.Description,
                Text = page.Text,
                Author = String.IsNullOrEmpty(page.Author) ? umgr.GetUserAsync(User).Result.UserName : page.Author,
                CreatedAt = page.CreatedAt
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid id, CancellationToken ct) {
            var page = id == default ? new Page() : await dataMgr.Pages.GetPageAsync(id, ct);

            PageViewModel model = new PageViewModel {
                Id = page.Id == default ? new Guid().ToString() : page.Id.ToString(),
                CodeWord = page.CodeWord,
                Title = page.Title,
                Description = page.Description,
                Text = page.Text,
                Author = String.IsNullOrEmpty(page.Author) ? umgr.GetUserAsync(User).Result.UserName : page.Author,
                CreatedAt = page.CreatedAt
            };

            return await Task.Run(() => View(model), ct);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(PageViewModel model, CancellationToken ct) {
            if(ModelState.IsValid) {
                Page page = new Page {
                    Id = model.Id == default ? new Guid() : Guid.Parse(model.Id),
                    CodeWord = model.CodeWord,
                    Title = model.Title,
                    Description = model.Description,
                    Text = model.Text,
                    Author = String.IsNullOrEmpty(model.Author) ? umgr.GetUserAsync(User).Result.UserName : model.Author,
                    CreatedAt = model.CreatedAt
                };

                dataMgr.Pages.SavePage(page);
                return RedirectToAction(nameof(PageController.Id), nameof(PageController).CutController(), new {
                    id = page.Id
                });
            }

            return await Task.Run(() => View(model), ct);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) {
            if(ModelState.IsValid) {
                dataMgr.Pages.DeletePage(id);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return NotFound();
        }
    }
}
