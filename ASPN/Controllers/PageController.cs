using ASPN.Domain;
using ASPN.Models;
using ASPN.Services;

using Domain.Entities;
using Domain.Entities.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

/*
 Plans:
-Create claims for user-role (Moderator => admin,moder...)
-Make restriction by claims/role
-Create claims controll panel
-Make store functionality for practice
-Make comments moderation (Delete, edit)

 */

namespace ASPN.Controllers {
    public class PageController: Controller {
        private readonly DataManager dataMgr;
        private readonly UserManager<User> umgr;

        public PageController(DataManager dataMgr, UserManager<User> umgr) {
            this.dataMgr = dataMgr;
            this.umgr = umgr;
        }

        public async Task<IActionResult> Id(Guid id, CancellationToken ct) {
            var page = await dataMgr.Pages.GetPageAsync(id, ct);
            IEnumerable<Comment> comments = await dataMgr.Comments.GetCommentsAsync(page.Id);

            if(comments == null) {
                comments = new List<Comment>();
            }

            ViewData["Comments"] = comments;

            PageViewModel model = new PageViewModel {
                Id = page.Id.ToString(),
                CodeWord = page.CodeWord,
                Title = page.Title,
                Description = page.Description,
                Text = page.Text,
                Author = String.IsNullOrEmpty(page.Author) ? umgr.GetUserAsync(User).Result.UserName : page.Author,
                CreatedAt = page.CreatedAt,
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

            return View(model);
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

                dataMgr.Pages.SavePageAsync(page);
                return RedirectToAction(nameof(PageController.Id), nameof(PageController).CutController(), new {
                    id = page.Id
                });
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) {
            if(ModelState.IsValid) {
                await dataMgr.Pages.DeletePageAsync(id);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LeaveComment(Guid pageId, string comment, CancellationToken ct) {

            var data = new Comment {
                Id = new Guid(),
                Text = comment,
                Author = umgr.GetUserAsync(User).Result.UserName,
                CreatedAt = DateTime.UtcNow,
                PageId = pageId
            };

            await dataMgr.Comments.CreateCommentAsync(data, ct);

            return RedirectToAction(nameof(PageController.Id), nameof(PageController).CutController(), new { id = pageId });
        }
    }
}
