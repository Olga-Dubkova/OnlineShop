using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

		public UserController(IUsersManager usersManager)
		{
			this.usersManager = usersManager;
		}

		public IActionResult Index()
        {
            var userAccount = usersManager.GetAll();
            return View(userAccount);
        }

		public IActionResult Detail(string login)
		{
			var userAccount = usersManager.TryGetByName(login);
			return View(userAccount);
		}

		public IActionResult ChangePassword(string login)
		{
			var changePassword = new ChangePassword()
			{
				Login= login,
			};
			return View(changePassword);
		}

		[HttpPost]	
		public IActionResult ChangePassword(ChangePassword changePassword)
		{
			if (changePassword.Login == changePassword.Password)
			{
				ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
			}
			if (ModelState.IsValid)
			{
				usersManager.ChangePassword(changePassword.Login, changePassword.Password);
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(ChangePassword));
		}

		public IActionResult Update(string login)
		{
			var user = usersManager.TryGetByName(login);		
			return View(user);
		}

		[HttpPost]
		public IActionResult Update(UserAccount user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			usersManager.ChangeUser(user);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(string login)
		{
			usersManager.Remove(login);
			return RedirectToAction("Index");
		}

	}
}
