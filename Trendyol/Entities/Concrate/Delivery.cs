using System;
namespace Trendyol.Entities.Concrate
{
	public class Delivery
	{
		public Delivery(decimal costPerDelivery, decimal costPerProduct)
		{
			this.CostPerDelivery = costPerDelivery;

			this.CostPerProduct = costPerProduct;
		}

		public decimal CostPerDelivery { get; set; }

		public decimal CostPerProduct { get; set; }

		public decimal FixedCost { get { return 2.99m; } }
	}
}
