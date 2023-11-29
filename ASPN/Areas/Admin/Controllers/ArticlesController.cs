using ASPN.Domain;
using ASPN.Domain.Entities;
using ASPN.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly DataManager dataManager;
        public ArticlesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<ActionResult<IQueryable<Article>>> Index(CancellationToken ct)
        {
            return await Task.Run(() => View(dataManager.Articles.GetArticles()), ct);
        }

        public async Task<IActionResult> Show(Guid id, CancellationToken ct)
        {
            Article entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            return await Task.Run(() => View(entity), ct);
        }

        public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
        {
            Article entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            return await Task.Run(() => View(entity), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                dataManager.Articles.SaveArticle(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return await Task.Run(() => View(model), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            dataManager.Articles.DeleteArticle(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
