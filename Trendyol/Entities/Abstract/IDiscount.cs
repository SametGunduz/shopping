using System;
using Trendyol.Entities.Concrate;

namespace Trendyol.Entities.Abstract
{
	public interface IDiscount
	{
		DiscountType DiscountType { get; set; }

		decimal DiscountValue { get; set; }

		int Quantity { get; set; }
	}
}
