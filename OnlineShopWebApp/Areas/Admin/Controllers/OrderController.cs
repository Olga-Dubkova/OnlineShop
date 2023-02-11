using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfases;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Common;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(Mapping.ToOrderViewModels(orders));
        }

        public IActionResult Detail(Guid id)
        {
            var order = ordersRepository.TryGetById(id);
            return View(Mapping.ToOrderViewModel(order));
        }

        public IActionResult UpdateStatus(Guid id, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(id, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }

}
