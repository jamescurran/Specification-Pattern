using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace SpecificationPattern.Tests
{
    [TestFixture]
    public class OrderSpecificationSamples
    {
        [Test]
        public void IsRush_under100dollars_shouldBeFalse()
        {
            var order = SampleOrder.WithTotalOf(50).HavingAddress(DomesticAddress);

            Assert.That(order.IsRush(), Is.False);
        }

        [Test]
        public void IsRush_should_be_false_when_for_non_domestic_orders()
        {
            var order = SampleOrder.WithTotalOf(200).HavingAddress(InternationalAddress);
            Assert.That(order.IsRush(), Is.False);
        }

        [Test]
        public void IsRush_should_be_true_when_all_conditions_are_met()
        {
            var order = SampleOrder
                .HavingAddress(DomesticAddress)
                .WithTotalOf(TwoHundredDollars)
                .Containing(SafeProduct.ThatIsInStock());

            Assert.That(order.IsRush(), Is.True);
        }

        [Test]
        public void IsRush_should_be_false_when_all_conditions_are_met()
        {
            var order = SampleOrder
                .WithTotalOf(200)
                .HavingAddress(DomesticAddress)
                .Containing(SafeProduct.ThatIsOutOfStock());

            Assert.That(order.IsRush(), Is.False);
        }

        #region Helpers

        public static int TwoHundredDollars
        {
            get { return 200; }
        }


        public Order SampleOrder
        {
            get { return new Order(); }
        }

        public Address DomesticAddress
        {
            get { return new Address() { AddressLine1 = "123 Oak Street", City = "Marion", State = "Iowa", Zip = "52302", Country = "USA" }; }
        }

        public Address InternationalAddress
        {
            get { return new Address() { AddressLine1 = "123 Oak Street", City = "Paris", State = "Iowa", Zip = "503xd8", Country = "FR" }; }
        }

        public Product HazardousProduct
        {
            get { return new Product {ContainsHazardousMaterial = true}; }
        }

        public Product SafeProduct
        {
            get { return new Product { ContainsHazardousMaterial = false }; }
        }

        #endregion
    }

    #region Extension Classes (Helpers)

    public static class OrderExtensions
    {
        public static Order WithTotalOf(this Order @this, int orderTotal)
        {
            @this.OrderTotal = orderTotal;
            return @this;
        }

        public static Order HavingAddress(this Order @this, Address address)
        {
            @this.ShippingAddress = address;
            return @this;
        }

        public static Order Containing(this Order @this, Product product)
        {
            @this.OrderItems.Add(product);
            return @this;
        }
    }

    public static class ProductExtensions
    {
        public static Product ThatIsInStock(this Product @this)
        {
            @this.IsInStock = true;
            return @this;
        }

        public static Product ThatIsOutOfStock(this Product @this)
        {
            @this.IsInStock = false;
            return @this;
        }
    }

    #endregion
}
