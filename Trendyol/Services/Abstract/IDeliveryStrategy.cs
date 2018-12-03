using System;
using Trendyol.Entities.Concrate;

namespace Trendyol.Services.Abstract
{
	public interface IDeliveryStrategy
	{
		decimal GetDeliveryCost(int numberOfDeliveries, int numberOfProducts, Delivery delivery);
	}
}
