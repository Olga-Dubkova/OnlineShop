using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
	public static class Mapping
	{
		public static List<ProductViewModel> ToProductViewModels(List<ProductModel> products)
		{
			var productsViewModel = new List<ProductViewModel>();
			foreach (var product in products)
			{
				productsViewModel.Add(ToProductViewModel(product));
			}
			return productsViewModel;
		}


		public static ProductViewModel ToProductViewModel(ProductModel product)
		{
			return new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Cost = product.Cost,
				Description = product.Description,
				ImagePath = product.ImagePath,
			};
		}

		public static CartViewModel ToCartViewModel(CartModel cart)
		{
			if(cart == null)
			{
				return null;	
			}

			return new CartViewModel
			{
				Id= cart.Id,
				UserId= cart.UserId,
				Items = ToCartItemViewModel(cart.Items)
			};
		}

		public static List<CartItemViewModel> ToCartItemViewModel(List<CartItem> cartDbItems)
		{
			var cartItems = new List<CartItemViewModel>();

			foreach (var cartDbItem in cartDbItems)
			{
				var cartItem = new CartItemViewModel
				{
					Id = cartDbItem.Id,
					Amount = cartDbItem.Amount,
					Product = ToProductViewModel(cartDbItem.Product)
				};
				cartItems.Add(cartItem);	
			}
			return cartItems;	
		}

		public static OrderViewModel ToOrderViewModel(OrderModel order)
		{
			return new OrderViewModel
			{
				Id = order.Id,
				CreateDataTime = order.CreateDataTime,
				Status = (OrderStatusViewModel)(int)order.Status,
				User = ToUserOrderViewModel(order.User),
				Items = ToCartItemViewModel(order.Items)
			};
		}

        public static List<OrderViewModel> ToOrderViewModels(List<OrderModel> orders)
        {
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var orderViewModel = ToOrderViewModel(order);
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }

        public static UserOrderViewModel ToUserOrderViewModel(UserOrderModel user)
		{
			return new UserOrderViewModel
			{
				Name = user.Name,
				Surname = user.Surname,
				Phone = user.Phone,
				Address = user.Address
			};
		}

        public static UserOrderModel ToUserOrderModel(UserOrderViewModel user)
        {
            return new UserOrderModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Address = user.Address
            };
        }
    }
}
