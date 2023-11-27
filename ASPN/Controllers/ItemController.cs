using ASPN.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPN.Controllers
{
    public class ItemController : Controller
    {
        private Storage items;
        public ItemController(Storage items)
        {
            this.items = items;
        }
        public IActionResult Index()
        {
            return View(items.Items.AsQueryable());
        }
    }
}
