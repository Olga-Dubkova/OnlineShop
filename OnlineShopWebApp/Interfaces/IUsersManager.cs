using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
	public interface IUsersManager
	{
		List<UserAccount> GetAll();

		void Add(UserAccount user);

		UserAccount TryGetByName(string name);

		void ChangePassword(string login, string newPassword);

		void ChangeUser(UserAccount user);
		void Remove(string login);
	}
}
