using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductStore productStore;

        public ProductController(IProductStore productStore)
        {
            this.productStore = productStore;
        }
        public IActionResult Index()
        {
            var products = productStore.GetAll();
			return View("Index", Mapping.ToProductViewModels(products));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new ProductModel
            {
                Name= product.Name,
                Cost= product.Cost,
                Description= product.Description,
            };

            productStore.Add(productDb);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            productStore.Remove(id);
            var products = productStore.GetAll();
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var product = productStore.TryGetById(id);
            return View(Mapping.ToProductViewModel(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

			var productDb = new ProductModel
			{
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagePath = product.ImagePath,
            };

			productStore.Update(productDb);
            return RedirectToAction("Index");
        }
    }

}
