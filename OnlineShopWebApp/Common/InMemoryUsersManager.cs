using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Common
{
	public class InMemoryUsersManager : IUsersManager
	{
		private readonly List<UserAccount> users = new List<UserAccount>();

		public List<UserAccount> GetAll()
		{
			return users;
		}

		public void Add(UserAccount user)
		{
			users.Add(user);
		}

		public UserAccount TryGetByName(string login)
		{
			return users.FirstOrDefault(user => user.Login == login);
		}

		public void ChangePassword(string login, string newPassword)
		{
			var account = TryGetByName(login);
			account.Password = newPassword;
		}

		public void ChangeUser(UserAccount user)
		{
			var changeUser = TryGetByName(user.Login);

			changeUser.Login = user.Login;
			changeUser.Name = user.Name;
			changeUser.Phone = user.Phone;
		}

		public void Remove(string login)
		{
			users.RemoveAll(user => user.Login == login);	
		}
	}
}
