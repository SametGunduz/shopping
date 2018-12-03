using System.Collections.Generic;
using Trendyol.Entities.Abstract;
using Trendyol.Entities.Concrate;

namespace Trendyol.Services.Abstract
{
	public interface IShoppingCartContext
	{
        void AddItem(Product product);

		void Apply(List<IDiscount> discounts);

		int GetItemCount();

		decimal GetTotalAmount();

		decimal GetTotalAmountAfterDistance();

		decimal GetTotalDiscount();

		decimal GetTotalCouponDiscount();

		decimal GetDeliveryCost();

		void Print();
	}
}
