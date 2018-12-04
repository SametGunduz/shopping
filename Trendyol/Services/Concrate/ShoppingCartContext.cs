using System.Collections.Generic;
using System.Linq;
using Trendyol.Entities.Abstract;
using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;

namespace Trendyol.Services.Concrate
{
	public class ShoppingCartContext : IShoppingCartContext
	{
		ShoppingCart cart;

        List<IDiscount> discounts;

		IDeliveryStrategy _deliveryStrategy;

		public ShoppingCartContext(IDeliveryStrategy deliveryStrategy)
		{
			cart = new ShoppingCart();

			_deliveryStrategy = deliveryStrategy;
		}

		public void AddItem(Product product)
		{
			cart.Products.Add(product);
		}

        public void Apply(List<IDiscount> discounts)
        {

            this.discounts = discounts;

            var _campaings = discounts.Where(d => d.GetType() == typeof(Campaign)).OrderByDescending(c => c.DiscountValue).OrderByDescending(c => c.Quantity).ToList();

            if(_campaings!=null)
            {
				//Campaigns
				foreach (var product in cart.Products)
				{
					int catQuentity = cart.Products.GroupBy(c => c.Category.Title == product.Category.Title).Select(group => group.Sum(c => c.Quantity)).FirstOrDefault();

					IDiscount maxRateCampaign = _campaings.Where(d => d.GetType() == typeof(Campaign) && d.DiscountType == DiscountType.Rate).OrderByDescending(c => c.Quantity).FirstOrDefault();

					IDiscount maxAmountCampaign = _campaings.Where(d => d.GetType() == typeof(Campaign) && d.DiscountType == DiscountType.Amount).OrderByDescending(c => c.Quantity).FirstOrDefault();

					if (maxRateCampaign != null)
						product.CampaignDistanceAmount += new DiscountCalculator(new RateDiscountCalculator()).Calculate(maxRateCampaign, catQuentity, product.UnitPrice);

					if (maxAmountCampaign != null)
						product.CampaignDistanceAmount += new DiscountCalculator(new AmountDiscountCalculator()).Calculate(maxAmountCampaign, catQuentity, product.UnitPrice);
				}

				IDiscount coupon = discounts.Where(d => d.GetType() == typeof(Coupon) && d.DiscountType == DiscountType.Amount).OrderByDescending(c => c.Quantity).FirstOrDefault();

                if(coupon != null)
                {
					//Coupon
					cart.TotalCoupon = new DiscountCalculator(new CouponDiscountCalculator()).Calculate(coupon, GetItemCount(), GetTotalAmount());
                }
            }

            //Delivery
            cart.DeliveryCost = new DeliveryCalculator(_deliveryStrategy).GetDeliveryCost(cart.NumberOfDeliveries, cart.NumberOfProducts);
        }

		public int GetItemCount()
		{
			return cart.TotalItems;
		}

		public decimal GetTotalAmount()
		{
			return cart.TotalAmount;
		}

		public decimal GetTotalAmountAfterDistance()
		{
			return cart.TotalAmountAfterDistance;
		}

		public decimal GetTotalDiscount()
		{
			return cart.TotalDiscount;
		}

		public decimal GetTotalCouponDiscount()
		{
			return cart.TotalCoupon;
		}

		public decimal GetDeliveryCost()
		{
			return cart.DeliveryCost;
		}

		public void Print()
		{
			cart.Print();
		}

	}
}
