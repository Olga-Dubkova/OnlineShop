using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUsersManager usersManager;

		public AccountController(IUsersManager usersManager)
		{
			this.usersManager = usersManager;
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginModel login)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(Login));
			}

			var userAccount = usersManager.TryGetByName(login.Login);
			if (userAccount == null)
			{
				ModelState.AddModelError("", "Пользователя с таким логином не существует!");
				return RedirectToAction(nameof(Login));
			}

			if (userAccount.Password != login.Password)
			{
				ModelState.AddModelError("", "Не правильный пароль!");
				return RedirectToAction(nameof(Login));	
			}
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterModel register)
		{
			if (register.Login == register.Password)
			{
				ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
			}
			if (ModelState.IsValid)
			{
				usersManager.Add(new UserAccount
				{
					Login = register.Login,
					Password = register.Password,
					Phone = register.Phone,
					Name = register.Name,
				});
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			return RedirectToAction(nameof(Register));
		}
	}
}
