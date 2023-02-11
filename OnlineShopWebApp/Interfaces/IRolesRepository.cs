using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRolesRepository
	{
		List<RoleModel> GetAll();

		RoleModel TryGetByName(string name);	

		void AddRole(RoleModel role);

		void Remove(string name);
	}
}
