using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Common;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {      
        private readonly IProductStore productStore;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductStore productStore, ICartsRepository cartsRepository)
        {
            this.productStore = productStore;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(Mapping.ToCartViewModel(cart));
        }
        public IActionResult Add(Guid productId)
        {
            var product = productStore.TryGetById(productId);


            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Decrease(Guid productId)
        {
            cartsRepository.Decrease(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
