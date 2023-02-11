using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Common;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {
        public IFavotiteRepository favoriteRepository;
        public IProductStore productStore;

        public FavoriteController(IFavotiteRepository favotiteRepository, IProductStore productStore)
        {
            this.favoriteRepository = favotiteRepository;
            this.productStore = productStore;
        }

        public IActionResult Index()
        {
            var favourites = favoriteRepository.GetAll(Constants.UserId);   
            return View(Mapping.ToProductViewModels(favourites));
        }

        public IActionResult Add(Guid productId)
        {
            var product = productStore.TryGetById(productId);
            favoriteRepository.Add(Constants.UserId, product);           
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productStore.TryGetById(productId);
            if (product != null)
            {
                favoriteRepository.Remove(Constants.UserId, productId);
            }
            return RedirectToAction("Index");
        }
    }
}
