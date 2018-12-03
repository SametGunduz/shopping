using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;

namespace Trendyol.Services.Concrate
{
	public class DeliveryCalculator
	{
		private readonly IDeliveryStrategy _deliveryStrategy;

		public DeliveryCalculator(IDeliveryStrategy deliveryStrategy)
		{
			_deliveryStrategy = deliveryStrategy;
		}

        public decimal GetDeliveryCost(int numberOfDelivery, int numberOfProduct)
		{
			return _deliveryStrategy.GetDeliveryCost(numberOfDelivery, numberOfProduct, new Delivery(DeliveryCostSettings.CostPerDelivery, DeliveryCostSettings.CostPerProduct));
		}

	}
}
