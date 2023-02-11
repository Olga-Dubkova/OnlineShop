using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShopWebApp.Common;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoritesProductsCount
{
    public class CalcFavoritesProductsCountViewComponent : ViewComponent
    {
        private readonly IFavotiteRepository favotiteRepository;

        public CalcFavoritesProductsCountViewComponent(IFavotiteRepository favotiteRepository)
        {
            this.favotiteRepository = favotiteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favotiteRepository.GetAll(Constants.UserId).Count;  
            return View("CalcFavoritesProductsCountView", productsCount);
        }

    }
}
