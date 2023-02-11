using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Common
{
    public class InMemoryRolesRepository : IRolesRepository
	{
		private readonly List<RoleModel> roles = new List<RoleModel>();	
		public List<RoleModel> GetAll()
		{
			return roles;	
		}

		public RoleModel TryGetByName(string name)
		{
			return roles.FirstOrDefault(roles=> roles.Name == name);
		}

		public void AddRole(RoleModel role)
		{
			roles.Add(role);
		}

		public void Remove(string name)
		{
			roles.RemoveAll(role => role.Name == name);
		}
	}
}
