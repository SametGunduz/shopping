using System;
using Trendyol.Entities.Concrate;
using Trendyol.Services.Concrate;
using Xunit;

namespace Test
{
    public class CouponTests
    {
		[Fact]
		public void Coupon_Code_Validation()
		{
			//Arrange
            var expectedString = "This coupon is not valid";

			//Act
            Exception act = Assert.Throws<Exception>(() => new Coupon().Initialize("samet", DiscountType.Amount, 5, 2));

			//Assert
			Assert.Equal(expectedString, act.Message);
		}

        [Fact]
        public void Coupon_Apply_Discount_Calculate()
        {
            //Arrange
            var couponCalc = new CouponDiscountCalculator();
            var coupon = new Coupon().Initialize("samt", DiscountType.Amount, 5, 2);
            var expectedAmount = 5;

            //Act
            var act = couponCalc.Calculate(coupon, 2, 100);

            //Assert
            Assert.Equal(expectedAmount,act);
        }
    }
}
