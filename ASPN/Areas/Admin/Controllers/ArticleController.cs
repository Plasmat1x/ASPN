using ASPN.Domain;
using ASPN.Domain.Entities;
using ASPN.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly DataManager dataManager;
        public ArticleController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<IActionResult> Show(Guid id)
        {
            Article entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            return await Task.Run(() => View(entity));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Article entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            return await Task.Run(() => View(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Articles.SaveArticle(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return await Task.Run(() => View(model));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            dataManager.Articles.DeleteArticle(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
