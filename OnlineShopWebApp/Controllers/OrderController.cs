using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Common;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Buy(UserOrderViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", user);   
            }
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);

			var order = new OrderModel
            {
                User = Mapping.ToUserOrderModel(user),
                Items = existingCart.Items,
            };
            ordersRepository.Add(order);

            cartsRepository.Clear(Constants.UserId);    
            return View();
        }
    }
}
