using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStore productStore;

        public HomeController(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public IActionResult Index()
        {
            var products = productStore.GetAll();
            return View(Mapping.ToProductViewModels(products));  
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
