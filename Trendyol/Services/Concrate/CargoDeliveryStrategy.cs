using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;

namespace Trendyol.Services.Concrate
{
	public class CargoDeliveryStrategy : IDeliveryStrategy

	{

		public decimal GetDeliveryCost(int numberOfDeliveries, int numberOfProducts, Delivery delivery)

		{

			return (delivery.CostPerDelivery * numberOfDeliveries) + (delivery.CostPerProduct + numberOfProducts) + delivery.FixedCost;

		}

	}
}
