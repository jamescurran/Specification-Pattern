using System;
using System.Linq;
using System.Collections.Generic;
using SpecificationPattern.Specifications;

namespace SpecificationPattern
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<Product>();
        }

        public virtual Address ShippingAddress { get; set; }
        public int OrderTotal{ get; set; }
        public IList<Product> OrderItems { get; set; }

        public bool IsRush()
        {
            bool isRush = false;
            if (ShippingAddress.Country == "USA")
            {
                if (OrderTotal > 100)
                {
                    if (OrderItems.Count(item => !item.IsInStock) == 0)
                    {
                        if (OrderItems.Count(item => item.ContainsHazardousMaterial) == 0)
                        {
                            isRush = true;
                        }
                    }
                }
            }

            return isRush;

            #region

            var spec = new RushOrderSpecification();
            return spec.IsSatisfiedBy(this);

            #endregion
        }
    }
}