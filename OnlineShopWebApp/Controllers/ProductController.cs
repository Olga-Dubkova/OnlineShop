using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStore productStore;

        public ProductController(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public IActionResult Index(Guid id)
        {
            var product = productStore.TryGetById(id);

            return View(Mapping.ToProductViewModel(product));   
        }
    }
}
